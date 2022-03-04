using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static myPort.Form1;

namespace myPort
{
    public class Parse
    {
        private Form1 form;
        public List<ParsingObj> parsingObjs = new List<ParsingObj>();
        public List<RecObj> recObjs = new List<RecObj>();
        public List<CmdObj> cmdObjs = new List<CmdObj>();
        public List<SendObj> sendObjs = new List<SendObj>();
        public Parse(Form1 form)
        {
            this.form = form;
        }

        #region 接收相关
        private void recTempClear(List<RecObj> ls)
        {
            foreach (RecObj rec in ls)
            {
                rec.tempIndex = 0;
                rec.tempValue = 0;
                rec.valueChanged = false;
            }
        }
        #region find函数
        private FileInfo find_py(string name)
        {
            string rootPath = Directory.GetCurrentDirectory() + "\\function";
            name = name + ".py";
            DirectoryInfo root = new DirectoryInfo(rootPath);
            foreach (FileInfo f in root.GetFiles())
            {
                if (name == f.Name)
                {
                    return f;
                }
            }
            return null;
        }
        private CmdObj findCmdObjByName(List<CmdObj> ls, string name)
        {
            foreach (CmdObj rec in ls)
            {
                if (rec.cmdName.Equals(name))
                {
                    return rec;
                }
            }
            return null;
        }
        private SendObj findSendObjByName(List<SendObj> ls, string name)
        {
            foreach (SendObj send in ls)
            {
                if (send.sendName.Equals(name))
                {
                    return send;
                }
            }
            return null;
        }
        private RecObj findRecObjByName(List<RecObj> ls, string name)
        {
            foreach (RecObj rec in ls)
            {
                if (rec.recName.Equals(name))
                {
                    return rec;
                }
            }
            return null;
        }
        #endregion
        // 接收匹配
        public void dataParsing(byte[] data, bool bigen)
        {
            recTempClear(recObjs);
            foreach (ParsingObj obj in parsingObjs)
            {
                int allLen = 0;
                int value = 0;
                for (int i = 0; i < obj.array.Count; ++i)
                {
                    if (obj.array[i].rec != null)// 变量匹配
                    {
                        obj.array[i].rec.valueChanged = true;
                        for (int j = 0; j < obj.array[i].valueLen; j++)
                        {
                            if (bigen)// 大小端
                            {
                                obj.array[i].rec.tempValue = obj.array[i].rec.tempValue << 8;
                                obj.array[i].rec.tempValue += data[i + j];

                            }
                            else
                            {
                                obj.array[i].rec.tempValue += data[i + j] << (8 * obj.array[i].rec.tempIndex);
                                obj.array[i].rec.tempIndex++;
                            }
                        }
                        allLen += obj.array[i].valueLen;
                    }
                    else if (obj.array[i].scriptPath != null)
                    {
                        try
                        {
                            ScriptEngine pyEngine = Python.CreateEngine();//创建Python解释器对象
                            dynamic pyFunc = pyEngine.ExecuteFile(obj.array[i].scriptPath);//读取脚本文件
                            if (pyFunc != null)
                            {
                                int pyValue = pyFunc.main(data, obj.array[i].pList);
                                
                                for (int j = 0; j < obj.array[i].valueLen; j++)
                                {
                                    byte num = 0;
                                    if (bigen)
                                    {
                                        num = (byte)((pyValue >> (obj.array[i].valueLen - j - 1) * 8) & 0xff);
                                    }
                                    else
                                    {
                                        num = (byte)(pyValue & 0xff);
                                        value >>= 8;
                                    }
                                    if (num != data[allLen + j])
                                    {
                                        goto unparse;
                                    }
                                }
                                allLen += obj.array[i].valueLen;
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("脚本运行错误" + e.Message);
                        }
                    }
                    else if(obj.array[i].num != -1) // 数值匹配
                    {
                        value = obj.array[i].num;
                        allLen++;
                        if (value != data[i])
                        {
                            break;
                        }
                    }
                    else
                    {
                        allLen += obj.array[i].valueLen;
                    }
                }
            unparse:
                if (allLen == data.Length)// 匹配成功
                {
                    recTempApply(recObjs);
                    if (obj.parsingCmd)
                    {
                        CmdObj cmd = findCmdObjByName(cmdObjs, obj.parsingCmdName);
                        if (cmd != null)
                        {
                            sendCmd(cmd,bigen);
                            if (cmd.timerNeed)
                            {
                                if (cmd.timerIsStart == false)
                                {
                                    cmd.cmdTimer.Start();
                                }
                            }
                        }
                    }
                    return;
                }
            }
        }

       
        
        // 接收数据应用
        private void recTempApply(List<RecObj> ls)
        {
            for (int i = 0; i < ls.Count; ++i)
            {

                if (ls[i].valueChanged)
                {
                    ls[i].recValue = ls[i].tempValue;
                    // 如果接收发送变量名称相同,则发送变量值变为接收变量的值
                    SendObj send = findSendObjByName(sendObjs, ls[i].recName);
                    if (send != null)
                    {
                        send.sendValue = ls[i].recValue;
                    }
                    form.update_rec_value(ls[i],i);
                }
            }
        }

        /// <summary>
        /// 清空匹配列表
        /// </summary>
        public void parse_rec_clear()
        {
            parsingObjs.Clear();
        }
        /// <summary>
        /// 预处理
        /// </summary>
        /// <param name="obj"></param>
        public bool parse_rec_per_prase(ParsingObj obj)
        {
            obj.array = new List<PerParse>();
            int i = 0;
            string hex = obj.parsingStr.Trim();
            string[] hexArray = hex.Split(' ');
            byte value = 0;
            RecObj reco = null;
            for (i = 0; i < hexArray.Length; ++i)
            {
                string temp = hexArray[i];

                if (temp.Contains('%'))// 变量匹配
                {
                    string nameTemp = temp.Trim('%');
                    int numIndex = nameTemp.IndexOf(':');
                    int num = 1;
                    string name;
                    if (numIndex >= 0)
                    {
                        name = nameTemp.Substring(0, numIndex);
                        num = Convert.ToInt32(nameTemp.Substring(numIndex + 1));
                    }
                    else
                    {
                        name = nameTemp;
                    }
                    reco = findRecObjByName(recObjs, name);
                    obj.array.Add(new PerParse() { rec = reco, valueLen = num });
                }
                else if (hexArray[i].Contains('$'))
                {
                    string nameTemp = hexArray[i].Trim('$');
                    int numIndex = nameTemp.IndexOf(':');
                    int byteNum = 1;
                    string name;
                    if (numIndex >= 0)
                    {
                        name = nameTemp.Substring(0, numIndex);
                        byteNum = Convert.ToInt32(nameTemp.Substring(numIndex + 1));
                    }
                    else
                    {
                        name = nameTemp;
                    }
                    int paramIndex = name.IndexOf('(');
                    string[] paramList = null;
                    if (paramIndex >= 0)
                    {
                        name = name.Substring(0, paramIndex);
                        int l = nameTemp.IndexOf('(');
                        int r = nameTemp.IndexOf(')');
                        string param = nameTemp.Substring(l + 1, r - l - 1);
                        paramList = param.Split(',');
                    }
                    // 执行脚本
                    FileInfo f = find_py(name);

                    if (f != null)
                    {
                        obj.array.Add(new PerParse() { scriptPath = f.FullName, pList = paramList, valueLen = byteNum });
                    }
                    else
                    {
                        obj.array.Add(new PerParse() { valueLen = byteNum });
                    }

                }
                else // 数值匹配
                {
                    try
                    {
                        value = Convert.ToByte(temp, 16);
                        obj.array.Add(new PerParse() { num = value, valueLen = 1 });
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }
                    
                }
            }
            return true;
        }
        /// <summary>
        /// 加入匹配列表并且预解析
        /// </summary>
        /// <param name="obj"></param>
        public void parse_rec_add(ParsingObj obj)
        {
            parse_rec_per_prase(obj);
            parsingObjs.Add(obj);
        }

        public void parse_rec_upgrade()
        {
            foreach(ParsingObj obj in parsingObjs)
            {
                parse_rec_per_prase(obj);
            }
        }

        #endregion
        
        #region 发送相关
        // 发送命令
        public void sendCmd(CmdObj obj, bool bigEn)
        {
            List<byte> vs = new List<byte>();
            sendTempClear(sendObjs);

            List<FuncObj> funcObjs = new List<FuncObj>();
            // 填入数值
            for (int i = 0; i < obj.array.Count; ++i)
            {
                byte num = 0;
                if (obj.array[i].send != null)
                {

                    

                    for (int j = 0; j < obj.array[i].valueLen; j++)
                    {
                        if (bigEn)
                        {
                            obj.array[i].send.tempIndex++;
                            num = (byte)((obj.array[i].send.sendValue >> (obj.array[i].valueLen - obj.array[i].send.tempIndex) * 8) & 0xff);
                        }
                        else
                        {
                            num = (byte)(obj.array[i].send.tempValue & 0xff);
                            obj.array[i].send.tempValue >>= 8;
                        }
                        vs.Add(num);
                    }
                        
                    
                }
                else if (obj.array[i].scriptPath != null)
                {
                    FuncObj func = new FuncObj();
                    func.arrIndex = vs.Count;
                    func.cmdFunc = obj.array[i];
                    funcObjs.Add(func);
                    for (int j = 0; j < obj.array[i].valueLen; j++)
                    {
                        vs.Add(0);
                    }
                }
                else if(obj.array[i].num != -1)
                {
                    vs.Add((byte)obj.array[i].num);
                }
                else
                {
                    for (int j = 0; j < obj.array[i].valueLen; j++)
                    {
                        vs.Add(0);
                    }
                }
            }

            // 查找func脚本
            foreach (FuncObj funcObj in funcObjs)
            {
                try
                {
                    ScriptEngine pyEngine = Python.CreateEngine();//创建Python解释器对象
                    dynamic pyFunc = pyEngine.ExecuteFile(funcObj.cmdFunc.scriptPath);//读取脚本文件
                    if (pyFunc != null)
                    {
                        int value = pyFunc.main(vs.ToArray(), funcObj.cmdFunc.pList);
                        for (int j = 0; j < funcObj.cmdFunc.valueLen; j++)
                        {
                            byte num = 0;
                            if (bigEn)
                            {
                                num = (byte)((value >> (funcObj.cmdFunc.valueLen - j - 1) * 8) & 0xff);
                            }
                            else
                            {
                                num = (byte)(value & 0xff);
                                value >>= 8;
                            }
                            vs[funcObj.arrIndex + j] = num;
                        }
                    }

                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("脚本运行错误" + e.Message);
                }
            }

            byte[] data = vs.ToArray();
            form.sendData(data);
        }
        private void sendTempClear(List<SendObj> ls)
        {
            foreach (SendObj rec in ls)
            {
                rec.tempIndex = 0;
                rec.tempValue = rec.sendValue;
                rec.tempIndex = 0;
            }
        }

        /// <summary>
        /// 清空匹配列表
        /// </summary>
        public void cmd_send_clear()
        {
            cmdObjs.Clear();
        }
        /// <summary>
        /// 预处理
        /// </summary>
        /// <param name="obj"></param>
        public bool cmd_send_per_prase(CmdObj obj)
        {
            obj.array = new List<CmdPerParse>();
            int i = 0;
            string[] hexArray = obj.cmdStr.Trim().Split(' ');
            byte value = 0;
            SendObj sendo = null;
            for (i = 0; i < hexArray.Length; ++i)
            {
                string temp = hexArray[i];

                if (temp.Contains('%'))// 变量匹配
                {
                    string nameTemp = temp.Trim('%');
                    int numIndex = nameTemp.IndexOf(':');
                    int num = 1;
                    string name;
                    if (numIndex >= 0)
                    {
                        name = nameTemp.Substring(0, numIndex);
                        num = Convert.ToInt32(nameTemp.Substring(numIndex + 1));
                    }
                    else
                    {
                        name = nameTemp;
                    }
                    sendo = findSendObjByName(sendObjs, name);
                    obj.array.Add(new CmdPerParse() { send = sendo, valueLen = num });
                }
                else if (hexArray[i].Contains('$'))
                {
                    string nameTemp = hexArray[i].Trim('$');
                    int numIndex = nameTemp.IndexOf(':');
                    int byteNum = 1;
                    string name;
                    if (numIndex >= 0)
                    {
                        name = nameTemp.Substring(0, numIndex);
                        byteNum = Convert.ToInt32(nameTemp.Substring(numIndex + 1));
                    }
                    else
                    {
                        name = nameTemp;
                    }
                    int paramIndex = name.IndexOf('(');
                    string[] paramList = null;
                    if (paramIndex >= 0)
                    {
                        name = name.Substring(0, paramIndex);
                        int l = nameTemp.IndexOf('(');
                        int r = nameTemp.IndexOf(')');
                        string param = nameTemp.Substring(l + 1, r - l - 1);
                        paramList = param.Split(',');
                    }
                    // 执行脚本
                    FileInfo f = find_py(name);

                    if (f != null)
                    {
                        obj.array.Add(new CmdPerParse() { scriptPath = f.FullName, pList = paramList, valueLen = byteNum });
                    }
                    else
                    {
                        obj.array.Add(new CmdPerParse() { valueLen = byteNum });
                    }

                }
                else // 数值匹配
                {
                    try
                    {
                        value = Convert.ToByte(temp, 16);
                        obj.array.Add(new CmdPerParse() { num = value, valueLen = 1 });
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }

                }
            }
            return true;
        }
        /// <summary>
        /// 加入匹配列表并且预解析
        /// </summary>
        /// <param name="obj"></param>
        public void cmd_send_add(CmdObj obj)
        {
            cmd_send_per_prase(obj);
            cmdObjs.Add(obj);
        }

        public void cmd_send_upgrade()
        {
            foreach (CmdObj obj in cmdObjs)
            {
                cmd_send_per_prase(obj);
            }
        }

        #endregion
    }
}
