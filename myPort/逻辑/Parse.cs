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
        private void sendTempClear(List<SendObj> ls)
        {
            foreach (SendObj rec in ls)
            {
                rec.tempIndex = 0;
                rec.tempValue = rec.sendValue;
                rec.tempIndex = 0;
            }
        }
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
                int i = 0;
                int allLen = 0;
                string hex = obj.parsingStr.Trim();
                string[] hexArray = hex.Split(' ');
                //if (hexArray.Length != data.Length)
                //{
                //    continue;
                //}
                byte value = 0;
                RecObj rec = null;
                List<FuncObj> funcObjs = new List<FuncObj>();
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

                        rec = findRecObjByName(recObjs, name);

                        if (rec != null)
                        {
                            rec.valueChanged = true;
                            for (int j = 0; j < num; j++)
                            {
                                if (bigen)
                                {
                                    rec.tempValue = rec.tempValue << 8;
                                    rec.tempValue += data[i + j];

                                }
                                else
                                {
                                    rec.tempValue += data[i + j] << (8 * rec.tempIndex);
                                    rec.tempIndex++;
                                }
                            }
                        }
                        allLen += num;
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
                        if (paramIndex >= 0)
                        {
                            name = name.Substring(0, paramIndex);
                        }
                        // 执行脚本
                        FileInfo f = find_py(name);
                        try
                        {
                            if (f != null)
                            {
                                ScriptEngine pyEngine = Python.CreateEngine();//创建Python解释器对象
                                dynamic pyFunc = pyEngine.ExecuteFile(f.FullName);//读取脚本文件
                                if (pyFunc != null)
                                {
                                    int l = nameTemp.IndexOf('(');
                                    int r = nameTemp.IndexOf(')');
                                    string param = nameTemp.Substring(l + 1, r - l - 1);
                                    string[] pList = param.Split(',');
                                    int pyValue = pyFunc.main(data, pList);
                                    for (int j = 0; j < byteNum; j++)
                                    {
                                        byte num = 0;
                                        if (bigen)
                                        {
                                            num = (byte)((pyValue >> (byteNum - j - 1) * 8) & 0xff);
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
                                    allLen += byteNum;
                                }

                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("脚本运行错误" + e.Message);
                        }
                    }
                    else // 数值匹配
                    {
                        value = Convert.ToByte(temp, 16);
                        allLen++;
                        if (value != data[i])
                        {
                            break;
                        }
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
                    break;
                }

            }

        }

        // 发送命令
        public void sendCmd(CmdObj obj,bool bigEn)
        {
            string[] hexArray = obj.cmdStr.Trim().Split(' ');
            List<byte> vs = new List<byte>();
            sendTempClear(sendObjs);

            List<FuncObj> funcObjs = new List<FuncObj>();
            // 填入数值
            for (int i = 0; i < hexArray.Length; ++i)
            {
                byte num = 0;
                if (hexArray[i].Contains('%'))
                {
                    string nameTemp = hexArray[i].Trim('%');
                    foreach (SendObj send in sendObjs)
                    {
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
                        if (name.Equals(send.sendName))
                        {
                            for (int j = 0; j < byteNum; j++)
                            {
                                if (bigEn)
                                {
                                    send.tempIndex++;
                                    num = (byte)((send.sendValue >> (byteNum - send.tempIndex) * 8) & 0xff);
                                }
                                else
                                {
                                    num = (byte)(send.tempValue & 0xff);
                                    send.tempValue >>= 8;
                                }
                                vs.Add(num);
                            }
                        }
                    }
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
                    FuncObj func = new FuncObj();
                    func.arrIndex = vs.Count;
                    func.arrLen = byteNum;
                    int paramIndex = name.IndexOf('(');
                    if (paramIndex >= 0)
                    {
                        name = name.Substring(0, paramIndex);
                    }
                    func.name = name;
                    func.str = nameTemp;
                    funcObjs.Add(func);
                    for (int j = 0; j < byteNum; j++)
                    {
                        vs.Add(0);
                    }
                }
                else
                {
                    num = Convert.ToByte(hexArray[i], 16);
                    vs.Add(num);
                }
            }

            // 查找func脚本
            foreach (FuncObj funcObj in funcObjs)
            {
                FileInfo f = find_py(funcObj.name);
                try
                {
                    if (f != null)
                    {
                        ScriptEngine pyEngine = Python.CreateEngine();//创建Python解释器对象
                        dynamic pyFunc = pyEngine.ExecuteFile(f.FullName);//读取脚本文件
                        if (pyFunc != null)
                        {
                            int l = funcObj.str.IndexOf('(');
                            int r = funcObj.str.IndexOf(')');
                            string param = funcObj.str.Substring(l + 1, r - l - 1);
                            string[] pList = param.Split(',');
                            int value = pyFunc.main(vs.ToArray(), pList);
                            for (int j = 0; j < funcObj.arrLen; j++)
                            {
                                byte num = 0;
                                if (bigEn)
                                {
                                    num = (byte)((value >> (funcObj.arrLen - j - 1) * 8) & 0xff);
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
                }
                catch (Exception e)
                {
                    MessageBox.Show("脚本运行错误" + e.Message);
                }
            }

            byte[] data = vs.ToArray();
            form.sendData(data);
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
    }
}
