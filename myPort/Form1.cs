using Microsoft.Win32;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace myPort
{
    public partial class Form1 : Sunny.UI.UIForm
    {
        public List<RecObj> recObjs = new List<RecObj>();
        public List<SendObj> sendObjs = new List<SendObj>();
        public List<CmdObj> cmdObjs = new List<CmdObj>();
        public List<ParsingObj> parsingObjs = new List<ParsingObj>();
        UILineOption option = new UILineOption();
        public Form1()
        {
            InitializeComponent();
            GetComList();


            option.ToolTip.Visible = true;
            option.Title = null;

            option.XAxis.AxisLabel.DecimalCount = 1;
            option.XAxis.AxisLabel.AutoFormat = false;
            option.YAxis.AxisLabel.DecimalCount = 1;
            option.YAxis.AxisLabel.AutoFormat = false;

            LineChart.SetOption(option);


            if (cmbPort.Items.Count > 0)
            {
                cmbPort.SelectedIndex = 0;
            }
            baudCombo.SelectedIndex = 3;


            sendList.Columns[0].Width = (int)(0.5 * sendList.Width);
            sendList.Columns[1].Width = (int)(0.49 * sendList.Width);
            //sendList.Columns[0].DataPropertyName = "sendName";
            //sendList.Columns[1].DataPropertyName = "sendValue";

            recList.Columns[0].DataPropertyName = "recName";
            recList.Columns[1].DataPropertyName = "recValue";
            recList.Columns[2].DataPropertyName = "recIsShow";
            recList.Columns[0].Width = (int)(0.42 * recList.Width);
            recList.Columns[1].Width = (int)(0.42 * recList.Width);
            recList.Columns[2].Width = (int)(0.15 * recList.Width);

            recList.AllowUserToAddRows = true;
            serialPort.ReadTimeout = 500;/*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/

        }
        #region 参数操作
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "myPort（*.myPort）|*.myPort";
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                saveParam(localFilePath);
            }


        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "myPort(*.myPort)|*.myPort";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loadParam(dialog.FileName);
            }

        }
        void loadParam(string path)
        {
            XmlDocument doc = new XmlDocument();//创建一个XML文档
            XmlReaderSettings settings = new XmlReaderSettings();//设置读取XML时的属性。
            settings.IgnoreComments = true;//XML忽略注释。

            XmlReader xmlReader = XmlReader.Create(path, settings);//实例化一个XmlReader对象，解析XML文件
            doc.Load(xmlReader);//从指定的 XmlReader 加载 XML 文档。
            XmlNode root = doc.SelectSingleNode("setup");//读取根元素下的子元素集合
            XmlNode dataformatNode = root.SelectSingleNode("dataformat");//取仅有的一个元素
            if (dataformatNode != null)
            {
                XmlElement dataformat = (XmlElement)dataformatNode;//为了可以使用属性存储信息，我们把XmlNode转化为XmlElement。
                if (dataformat.GetAttribute("format") == "False")
                {
                    高位在前ToolStripMenuItem.Checked = false;
                    低位在前ToolStripMenuItem.Checked = true;
                }
                else
                {
                    高位在前ToolStripMenuItem.Checked = true;
                    低位在前ToolStripMenuItem.Checked = false;
                }
            }

            XmlNode serialNode = root.SelectSingleNode("serial");//取仅有的一个元素
            if (serialNode != null)
            {
                XmlElement serial = (XmlElement)serialNode;//为了可以使用属性存储信息，我们把XmlNode转化为XmlElement。
                baudCombo.Text = serial.GetAttribute("baud");
                string com = serial.GetAttribute("com");
                if (cmbPort.Items.Contains(com))
                {
                    cmbPort.Text = com;
                }
            }

            XmlNode node = root.SelectSingleNode("recList");//取仅有的一个元素
            if (node != null)
            {
                XmlElement element = (XmlElement)node;//为了可以使用属性存储信息，我们把XmlNode转化为XmlElement。
                XmlNodeList recs = element.ChildNodes;
                recObjs.Clear();
                recList.Rows.Clear();
                foreach (XmlElement xml in recs)
                {
                    RecObj rec = new RecObj();
                    rec.recName = xml.GetAttribute("recName");
                    rec.recSeriseName = rec.recName;
                    rec.recIsShow = xml.GetAttribute("recIsShow") == "True" ? true : false;
                    if (rec.recIsShow)
                    {
                        option.AddSeries(rec.recSeriseName);
                    }
                    recObjs.Add(rec);
                    recList.Rows.Add(rec.recName, 0, rec.recIsShow);
                }
            }

            XmlNode parsingNode = root.SelectSingleNode("parsingList");//取仅有的一个元素
            if (parsingNode != null)
            {
                XmlElement parsingelement = (XmlElement)parsingNode;//为了可以使用属性存储信息，我们把XmlNode转化为XmlElement。
                XmlNodeList parsings = parsingelement.ChildNodes;
                parsingObjs.Clear();
                foreach (XmlElement xml in parsings)
                {
                    ParsingObj parsing = new ParsingObj();
                    parsing.parsingName = xml.GetAttribute("parsingName");
                    parsing.parsingStr = xml.GetAttribute("parsingStr");
                    parsing.parsingCmdName = xml.GetAttribute("parsingCmdName");
                    parsing.parsingName = xml.GetAttribute("parsingName");
                    parsing.parsingCmd = xml.GetAttribute("parsingCmd") == "True" ? true : false;
                    parsingObjs.Add(parsing);
                }
            }

            XmlNode sendNode = root.SelectSingleNode("sendList");//取仅有的一个元素
            if (sendNode != null)
            {
                XmlElement sendelement = (XmlElement)sendNode;//为了可以使用属性存储信息，我们把XmlNode转化为XmlElement。
                XmlNodeList sends = sendelement.ChildNodes;
                sendObjs.Clear();
                sendList.Rows.Clear();
                foreach (XmlElement xml in sends)
                {
                    SendObj send = new SendObj();
                    send.sendName = xml.GetAttribute("sendName");
                    send.sendValue = Convert.ToInt32(xml.GetAttribute("sendValue"), 16);
                    sendObjs.Add(send);
                    sendList.Rows.Add(send.sendName, xml.GetAttribute("sendValue"));
                }
            }

            XmlNode cmdNode = root.SelectSingleNode("cmdList");//取仅有的一个元素
            if (cmdNode != null)
            {
                XmlElement cmdelement = (XmlElement)cmdNode;//为了可以使用属性存储信息，我们把XmlNode转化为XmlElement。
                XmlNodeList cmds = cmdelement.ChildNodes;
                cmdObjs.Clear();
                cmdList.Rows.Clear();
                foreach (XmlElement xml in cmds)
                {
                    CmdObj cmd = new CmdObj(this);
                    string temp = null;
                    temp = xml.GetAttribute("cmdName");
                    if (!String.IsNullOrEmpty(temp))
                        cmd.cmdName = xml.GetAttribute("cmdName");
                    temp = xml.GetAttribute("cmdStr");
                    if (!String.IsNullOrEmpty(temp))
                        cmd.cmdStr = xml.GetAttribute("cmdStr");

                    temp = xml.GetAttribute("time");
                    if (!String.IsNullOrEmpty(temp))
                        cmd.time = Convert.ToInt32(temp);

                    temp = xml.GetAttribute("timerNeed");
                    if (!String.IsNullOrEmpty(temp))
                        cmd.timerNeed = temp == "True" ? true : false;

                    parseCmd(cmd);
                    cmdObjs.Add(cmd);
                    cmdList.Rows.Add(cmd.cmdName, cmd.cmdStr);

                }
            }
            xmlReader.Close();
        }
        void saveParam(string path)
        {
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement root = document.CreateElement("setup");
            document.AppendChild(root);
            XmlElement dataFormat = document.CreateElement("dataformat");
            dataFormat.SetAttribute("format", 高位在前ToolStripMenuItem.Checked.ToString());
            root.AppendChild(dataFormat);

            XmlElement serial = document.CreateElement("serial");
            serial.SetAttribute("baud", baudCombo.Text);
            serial.SetAttribute("com", cmbPort.Text);
            root.AppendChild(serial);

            // recList
            XmlElement recs = document.CreateElement("recList");
            root.AppendChild(recs);
            for (int i = 0; i < recObjs.Count; i++)
            {
                XmlElement rec = document.CreateElement("rec");

                rec.SetAttribute("recName", recObjs[i].recName);
                rec.SetAttribute("recIsShow", recObjs[i].recIsShow.ToString());
                recs.AppendChild(rec);
            }

            XmlElement parsings = document.CreateElement("parsingList");
            root.AppendChild(parsings);
            for (int i = 0; i < parsingObjs.Count; i++)
            {
                XmlElement parsing = document.CreateElement("parsing");

                parsing.SetAttribute("parsingName", parsingObjs[i].parsingName);
                parsing.SetAttribute("parsingStr", parsingObjs[i].parsingStr);
                parsing.SetAttribute("parsingCmd", parsingObjs[i].parsingCmd.ToString());
                parsing.SetAttribute("parsingCmdName", parsingObjs[i].parsingCmdName);
                parsings.AppendChild(parsing);
            }

            XmlElement sends = document.CreateElement("sendList");
            root.AppendChild(sends);
            for (int i = 0; i < sendObjs.Count; i++)
            {
                XmlElement send = document.CreateElement("send");

                send.SetAttribute("sendName", sendObjs[i].sendName);
                send.SetAttribute("sendValue", Convert.ToString(sendObjs[i].sendValue, 16));
                sends.AppendChild(send);
            }

            XmlElement cmds = document.CreateElement("cmdList");
            root.AppendChild(cmds);
            for (int i = 0; i < cmdObjs.Count; i++)
            {
                XmlElement cmd = document.CreateElement("cmd");

                cmd.SetAttribute("cmdName", cmdObjs[i].cmdName);
                cmd.SetAttribute("cmdStr", cmdObjs[i].cmdStr);
                cmd.SetAttribute("time", Convert.ToString(cmdObjs[i].time));
                cmd.SetAttribute("timerNeed", cmdObjs[i].timerNeed.ToString());
                cmds.AppendChild(cmd);
            }

            document.Save(path);

        }
        #endregion
        #region 串口操作
        /// <summary>
        /// 从注册表获取系统串口列表
        /// </summary>
        public void GetComList()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            string[] sSubKeys = keyCom.GetValueNames();
            string[] str = new string[sSubKeys.Length];
            for (int i = 0; i < sSubKeys.Length; i++)
            {
                str[i] = (string)keyCom.GetValue(sSubKeys[i]);
            }
            cmbPort.Items.Clear();
            for (int i = 0; i < str.Length; i++)
            {
                cmbPort.Items.Add(str[i]);
            }

        }
        bool isReceiving = false;/*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {

                cmbPort.Enabled = true;
                baudCombo.Enabled = true;
                button1.Text = "打开串口";
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                while (isReceiving) Application.DoEvents();
                serialPort.Close();

            }
            else
            {
                serialPort.BaudRate = Convert.ToInt32(baudCombo.Text);
                serialPort.PortName = cmbPort.Text;
                serialPort.Open();
                isReceiving = false;
                cmbPort.Enabled = false;
                baudCombo.Enabled = false;
                button1.Text = "关闭串口";
            }
        }
        string byteArrayToString(byte[] vs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.TimeOfDay.ToString());
            sb.Append(':');
            foreach (byte b in vs)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(' ');
            }
            sb.AppendLine();
            return sb.ToString();
        }
        StreamWriter sw;
        void writeFile(string data)
        {
            sw.Write(data);
        }
        /**
         *  数据接收
         */
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                int len = serialPort.BytesToRead;
                if (len <= 0)
                {
                    return;
                }
                byte[] vs = new byte[len];
                serialPort.Read(vs, 0, len);

                Task.Factory.StartNew(new Action(() =>
                {
                    string bs = byteArrayToString(vs);
                    UIControl.AddTextBoxValue(recBox, "<---");
                    UIControl.AddTextBoxValue(recBox, bs);
                    if (needSave)
                    {
                        writeFile("<---" + bs);
                    }
                    dataParsing(vs, parsingObjs, recObjs);
                }));


            }
            catch (Exception exp)
            {

            }

            finally
            {
                isReceiving = false;/*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
            }
        }

        private void 刷新端口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectStr = cmbPort.Text;
            GetComList();
            if (cmbPort.Items.Contains(selectStr) == false)
            {
                if (cmbPort.Items.Count > 0)
                {
                    cmbPort.SelectedIndex = 0;
                }
                else
                {
                    cmbPort.SelectedIndex = -1;
                }
            }
            else
            {
                cmbPort.Text = selectStr;
            }
        }
        private void sendData(byte[] vs)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(vs, 0, vs.Length);
                string bs = byteArrayToString(vs);
                UIControl.AddTextBoxValue(recBox, "--->");
                UIControl.AddTextBoxValue(recBox, bs);
                if (needSave)
                {
                    writeFile("--->" + bs);
                }
            }

        }
        #endregion

        #region 界面逻辑

        private void LineChart_MouseEnter(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(chart1_MouseEnter);//调用滚轮事件
        }
        private void chart1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)//鼠标向上
            {
                if (UIControl.index > 200 && UIControl.index > UIControl.show)
                {
                    UIControl.show += 1;
                    LineChart.Option.XAxis.Max += 1;
                    LineChart.Option.XAxis.Min += 1;
                    LineChart.Option.XAxis.Max = UIControl.show + 20;
                    LineChart.Option.XAxis.MaxAuto = false;
                    LineChart.Option.XAxis.Min = UIControl.show - 200;
                }


            }
            else//鼠标向下滚动
            {
                if (UIControl.index > 200 && UIControl.show > 200)
                {
                    UIControl.show -= 1;
                    LineChart.Option.XAxis.Max -= 1;
                    LineChart.Option.XAxis.Min -= 1;
                    LineChart.Option.XAxis.Max = UIControl.show + 20;
                    LineChart.Option.XAxis.MaxAuto = false;
                    LineChart.Option.XAxis.Min = UIControl.show - 200;
                }
            }
        }

        private bool needSave = false;
        private void 开始保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (开始保存ToolStripMenuItem.Text.Equals("开始保存"))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt（*.txt）|*.txt";
                //设置默认文件类型显示顺序 
                sfd.FilterIndex = 1;
                //保存对话框是否记忆上次打开的目录 
                sfd.RestoreDirectory = true;
                //点了保存按钮进入 
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string dataSavePath;
                    dataSavePath = sfd.FileName.ToString(); //获得文件路径 
                    sw = File.AppendText(dataSavePath);
                    needSave = true;
                    开始保存ToolStripMenuItem.Text = "停止保存";
                }

            }
            else
            {
                needSave = false;
                开始保存ToolStripMenuItem.Text = "开始保存";
                sw.Close();
            }
        }
        /// 将DataTable中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        public void SaveDataTableCSV(string path, DataTable dt)
        {
            FileStream fs = new FileStream(path, FileMode.Truncate| FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            //写出列名称
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].ColumnName.ToString());
                if (i < dt.Columns.Count - 1)
                {
                    sb.Append("\t");
                }
            }
            sw.WriteLine(sb.ToString());

            //写出各行数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Clear();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sb.Append(dt.Rows[i][j].ToString());
                    if (j < dt.Columns.Count - 1)
                    {
                        sb.Append("\t");
                    }
                }
                sw.WriteLine(sb.ToString());
            }

            sw.Close();
            fs.Close();
        }
        private void 保存图像数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "cvs（*.cvs）|*.cvs";
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            //点了保存按钮进入 

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                int maxlen = 0;
                DataTable dt = new DataTable();
                foreach (string key in LineChart.Option.Series.Keys)
                {
                    dt.Columns.Add(key, typeof(int));
                    if (maxlen < LineChart.Option.Series[key].YData.Count)
                        maxlen = LineChart.Option.Series[key].YData.Count;
                }
                for (int i = 0; i < maxlen; i++)
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }

                foreach (string key in LineChart.Option.Series.Keys)
                {
                    for (int i = 0; i < LineChart.Option.Series[key].DataCount; i++)
                    {
                        int x = (int)LineChart.Option.Series[key].YData[i];
                        dt.Rows[(int)LineChart.Option.Series[key].XData[i] - 1][key] = x;
                    }
                }
                
                SaveDataTableCSV(sfd.FileName.ToString(), dt);
            }


        }
        private void 高位在前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            高位在前ToolStripMenuItem.Checked = true;
            低位在前ToolStripMenuItem.Checked = false;
        }

        private void 低位在前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            高位在前ToolStripMenuItem.Checked = false;
            低位在前ToolStripMenuItem.Checked = true;
        }
        // 发送按钮
        private void button2_Click(object sender, EventArgs e)
        {
            string hex = sendBox.Text.Trim(' ');
            if(string.IsNullOrEmpty(hex))
            {
                return;
            }
            string[] hexarray = hex.Split(' ');
            List<byte> bs = new List<byte>();
            try
            {
                foreach (string a in hexarray)
                {
                    
                    bs.Add(Convert.ToByte(a, 16));
                }
                sendData(bs.ToArray());
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }

        // 清空接收
        private void button3_Click(object sender, EventArgs e)
        {
            UIControl.ClearTextBoxValue(recBox);
        }

        private void recBox_TextChanged(object sender, EventArgs e)
        {

        }
        #region 界面配置
        private void 收发配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (收发配置ToolStripMenuItem.Checked)
            {
                收发配置ToolStripMenuItem.Checked = false;
                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                收发配置ToolStripMenuItem.Checked = true;
                splitContainer1.Panel2Collapsed = false;
            }
        }
        private void menuUpdata()
        {
            int x = 200;
            if (!曲线ToolStripMenuItem.Checked)
            {
                x -= 100;
                tableLayoutPanel1.ColumnStyles[0].Width = 0;
            }
            if (!命令ToolStripMenuItem.Checked)
            {
                x -= 50;
                tableLayoutPanel1.ColumnStyles[1].Width = 0;
            }
            if (!设置参数ToolStripMenuItem.Checked)
            {
                x -= 25;
                tableLayoutPanel1.ColumnStyles[2].Width = 0;
            }
            if (!接收参数ToolStripMenuItem.Checked)
            {
                x -= 25;
                tableLayoutPanel1.ColumnStyles[3].Width = 0;
            }


            if (曲线ToolStripMenuItem.Checked)
            {
                tableLayoutPanel1.ColumnStyles[0].Width = tableLayoutPanel1.Width * 100 / x;
            }
            if (命令ToolStripMenuItem.Checked)
            {
                tableLayoutPanel1.ColumnStyles[1].Width = tableLayoutPanel1.Width * 50 / x;
            }
            if (设置参数ToolStripMenuItem.Checked)
            {
                tableLayoutPanel1.ColumnStyles[2].Width = tableLayoutPanel1.Width * 25 / x;
            }
            if (接收参数ToolStripMenuItem.Checked)
            {
                tableLayoutPanel1.ColumnStyles[3].Width = tableLayoutPanel1.Width * 25 / x;
            }

        }
        private void 关闭图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            曲线ToolStripMenuItem.Checked = !曲线ToolStripMenuItem.Checked;
            menuUpdata();

        }
        private void 仅显示图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            命令ToolStripMenuItem.Checked = !命令ToolStripMenuItem.Checked;
            menuUpdata();
        }
        private void 设置参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            设置参数ToolStripMenuItem.Checked = !设置参数ToolStripMenuItem.Checked;
            menuUpdata();
        }

        private void 接收参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            接收参数ToolStripMenuItem.Checked = !接收参数ToolStripMenuItem.Checked;
            menuUpdata();
        }
        #endregion

        private void 接收协议ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Protocols(this).Show();
        }
        private void cmdList_Resize(object sender, EventArgs e)
        {
            cmdList.Columns[0].Width = (int)(0.2 * cmdList.Width);
            cmdList.Columns[1].Width = (int)(0.35 * cmdList.Width);
            cmdList.Columns[2].Width = (int)(0.15 * cmdList.Width);
            cmdList.Columns[3].Width = (int)(0.15 * cmdList.Width);
            cmdList.Columns[4].Width = (int)(0.15 * cmdList.Width);
        }
        private void sendList_Resize(object sender, EventArgs e)
        {
            sendList.Columns[0].Width = (int)(0.5 * sendList.Width);
            sendList.Columns[1].Width = (int)(0.49 * sendList.Width);
        }

        private void recList_Resize(object sender, EventArgs e)
        {
            recList.Columns[0].Width = (int)(0.4 * recList.Width);
            recList.Columns[1].Width = (int)(0.3 * recList.Width);
            recList.Columns[2].Width = (int)(0.3 * recList.Width);
        }

        #endregion

        #region 数据匹配
        private void sendTempClear(List<SendObj> ls)
        {
            foreach (SendObj rec in ls)
            {
                rec.tempIndex = 0;
                rec.tempValue = rec.sendValue;
                rec.tempIndex = 0;
            }
        }
        // 发送命令
        public void sendCmd(CmdObj obj)
        {
            string[] hexArray = obj.cmdStr.Trim().Split(' ');
            List<byte> vs = new List<byte>();
            sendTempClear(sendObjs);
            int chk = 0;
            int chkindex = 0;
            for (int i = 0; i < hexArray.Length; ++i)
            {
                byte num = 0;

                if (hexArray[i].Contains('%'))
                {
                    if (hexArray[i].Contains("chksum"))//校验和
                    {
                        if (高位在前ToolStripMenuItem.Checked)
                        {
                            chkindex++;
                            num = (byte)((chk >> (obj.cmdLs[hexArray[i]] - chkindex) * 8) & 0xff);
                        }
                        else
                        {
                            num = (byte)(chk & 0xff);
                            chk >>= 8;
                        }
                    }
                    else
                    {
                        string name = hexArray[i].Trim('%');
                        foreach (SendObj send in sendObjs)
                        {
                            if (name.Equals(send.sendName))
                            {
                                if (高位在前ToolStripMenuItem.Checked)
                                {
                                    send.tempIndex++;
                                    num = (byte)((send.sendValue >> (obj.cmdLs[hexArray[i]] - send.tempIndex) * 8) & 0xff);
                                }
                                else
                                {
                                    num = (byte)(send.tempValue & 0xff);
                                    send.tempValue >>= 8;
                                }
                            }
                        }
                    }
                }
                else
                {
                    num = Convert.ToByte(hexArray[i], 16);
                }
                vs.Add(num);
                if (obj.cmdLs.ContainsKey("_chksum_param1"))
                {
                    if (i >= obj.cmdLs["_chksum_param1"] && i <= obj.cmdLs["_chksum_param2"])
                    {
                        chk += num;
                    }
                }
            }
            byte[] data = vs.ToArray();
            sendData(data);
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
        private void recTempClear(List<RecObj> ls)
        {
            foreach (RecObj rec in ls)
            {
                rec.tempIndex = 0;
                rec.tempValue = 0;
                rec.valueChanged = false;
            }
        }
        List<int> chartI = new List<int>();
        private void addPointToChart()
        {
            if (chartI.Count > 0)
            {
                int i = chartI[0];
                UILineSeries series = option.Series[recObjs[i].recName];
                if (series != null)
                {
                    UIControl.AddSeriesPoint(LineChart, recObjs[i].recName, recObjs[i].recValue);
                    //series.Points.AddY(ls[i].recValue);
                }
                chartI.RemoveAt(0);
            }
        }

        private void recTempApply(List<RecObj> ls)
        {
            for (int i = 0; i < ls.Count; ++i)
            {

                if (ls[i].valueChanged)
                {
                    ls[i].recValue = ls[i].tempValue;
                    recList.Rows[i].Cells[1].Value = (object)(Convert.ToString(ls[i].recValue, 16));

                    if (ls[i].recIsShow)
                    {

                        UILineSeries series = option.Series[recObjs[i].recName];
                        if (series != null)
                        {
                            UIControl.AddSeriesPoint(LineChart, recObjs[i].recName, recObjs[i].recValue);
                            //series.Points.AddY(ls[i].recValue);
                        }


                        //chartI.Add(i);
                        //Task t = Task.Factory.StartNew(()=>addPointToChart());
                    }
                }
            }
        }

        private void dataParsing(byte[] data, List<ParsingObj> ls, List<RecObj> recLs)
        {
            recTempClear(recLs);
            foreach (ParsingObj obj in ls)
            {
                int i = 0;
                string hex = obj.parsingStr.Trim();
                string[] hexArray = hex.Split(' ');
                if (hexArray.Length != data.Length)
                {
                    return;
                }
                byte value = 0;
                RecObj rec = null;

                for (i = 0; i < hexArray.Length; ++i)
                {
                    string temp = hexArray[i];

                    if (temp.Contains('%'))// 变量匹配
                    {
                        string name = temp.Trim('%');
                        rec = findRecObjByName(recLs, name);

                        if (rec != null)
                        {
                            rec.valueChanged = true;
                            if (高位在前ToolStripMenuItem.Checked)
                            {
                                rec.tempValue = rec.tempValue << 8;
                                rec.tempValue += data[i];

                            }
                            else
                            {
                                rec.tempValue += data[i] << (8 * rec.tempIndex);
                                rec.tempIndex++;
                            }

                        }
                    }
                    else // 数值匹配
                    {
                        value = Convert.ToByte(temp, 16);
                        if (value != data[i])
                        {
                            break;
                        }
                    }
                }
                if (i == hexArray.Length)// 匹配成功
                {
                    recTempApply(recLs);
                    if (obj.parsingCmd)
                    {
                        CmdObj cmd = findCmdObjByName(cmdObjs, obj.parsingCmdName);
                        if (cmd != null)
                        {
                            sendCmd(cmd);
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
        #endregion
        #region recList

        // 是否显示曲线操作
        private void recList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void recList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex < recObjs.Count)
            {
                recObjs.RemoveAt(e.RowIndex);
            }

        }

        private void recList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.RowIndex >= recObjs.Count)
                {
                    recObjs.Add(new RecObj());
                }

                if (e.ColumnIndex == 0)
                {
                    recObjs[e.RowIndex].recName = (string)recList.Rows[e.RowIndex].Cells[0].FormattedValue;
                    if(String.IsNullOrEmpty(recObjs[e.RowIndex].recName))
                    {
                        recObjs[e.RowIndex].recSeriseName = recObjs[e.RowIndex].recName;
                    }
                }

                else if (e.ColumnIndex == 2)
                {
                    if ((bool)recList.Rows[e.RowIndex].Cells[2].EditedFormattedValue == false)
                    {

                        //选中改为不选中
                        recObjs[e.RowIndex].recIsShow = false;
                        // 删除曲线
                        if (option.Series.ContainsKey(recObjs[e.RowIndex].recName))
                        {
                            UILineSeries series = option.Series[recObjs[e.RowIndex].recSeriseName];
                            option.Series.TryRemove(recObjs[e.RowIndex].recSeriseName, out series);
                        }
                    }
                    else
                    {
                        //不选中改为选中
                        recObjs[e.RowIndex].recIsShow = true;
                        // 添加曲线
                        var series = option.AddSeries(new UILineSeries(recObjs[e.RowIndex].recSeriseName));
                        if(series != null)
                        {
                            series.Smooth = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region sendList
        private void sendList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.RowIndex >= sendObjs.Count)
                {
                    sendObjs.Add(new SendObj());
                }

                if (e.ColumnIndex == 0)
                {
                    sendObjs[e.RowIndex].sendName = (string)sendList.Rows[e.RowIndex].Cells[0].FormattedValue;
                }
                else if (e.ColumnIndex == 1)
                {

                    sendObjs[e.RowIndex].sendValue = Int32.Parse((string)sendList.Rows[e.RowIndex].Cells[1].FormattedValue, System.Globalization.NumberStyles.HexNumber);
                }
            }
        }
        private void sendList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex < sendObjs.Count)
            {
                sendObjs.RemoveAt(e.RowIndex);
            }
        }
        #endregion

        #region cmdList
        public void parseCmd(CmdObj cmd)
        {
            // 解析出list
            if(string.IsNullOrEmpty(cmd.cmdStr))
            {
                return;
            }    
            string[] hexArray = cmd.cmdStr.Trim().Split(' ');
            cmd.cmdLs.Clear();
            for (int i = 0; i < hexArray.Length; ++i)
            {
                if (hexArray[i].Contains('%'))
                {
                    if (cmd.cmdLs.ContainsKey(hexArray[i]))
                    {
                        cmd.cmdLs[hexArray[i]] = (byte)(cmd.cmdLs[hexArray[i]] + 1);
                    }
                    else
                    {
                        cmd.cmdLs.Add(hexArray[i], 1);
                    }
                    // chksum(1,2)//数组下标
                    if (hexArray[i].Contains("chksum"))
                    {
                        if (!cmd.cmdLs.ContainsKey("_chksum_param1"))
                        {
                            string[] x = getFuncParam(hexArray[i]);
                            cmd.cmdLs.Add("_chksum_param1", Convert.ToByte(x[0]));
                            cmd.cmdLs.Add("_chksum_param2", Convert.ToByte(x[1]));
                        }
                    }
                }
            }
        }
        private void cmdList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.RowIndex >= cmdObjs.Count)
                {
                    cmdObjs.Add(new CmdObj(this));
                    cmdList.AddRow();
                }
                CmdForm cf = new CmdForm(this, e.RowIndex);
                cf.Show();
                
            }
        }
        public Sunny.UI.UIDataGridView getCmdList()
        {
            return cmdList;
        }
        
        private string[] getFuncParam(string x)
        {
            string temp = x.Replace(" ", "");
            int start = x.IndexOf('(');
            int end = x.IndexOf(')');
            string sub = x.Substring(start + 1, end - start - 1);
            return sub.Split(',');

        }

        private void cmdList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex < cmdObjs.Count)
            {
                cmdObjs.RemoveAt(e.RowIndex);
            }
        }

        private void cmdList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (cmdList.Columns[e.ColumnIndex].Name == "cmdSend" && cmdObjs.Count > 0 && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                sendCmd(cmdObjs[e.RowIndex]);
                if (cmdObjs[e.RowIndex].timerNeed)
                {
                    if (cmdObjs[e.RowIndex].timerIsStart == false)
                    {
                        cmdObjs[e.RowIndex].cmdTimer.Start();
                    }
                }
            }
        }
        public class CmdObj
        {
            private void TimerUp(object sender, EventArgs e)
            {
                parent.sendCmd(this);
            }
            public string cmdName { get; set; }
            public string cmdStr { get; set; }
            public Dictionary<string, byte> cmdLs { get; set; }
            public Timer cmdTimer { get; set; }
            public int time { get; set; }
            public bool timerNeed { get; set; }
            public bool timerIsStart { get; set; }
            public Form1 parent;
            public CmdObj(Form1 parent)
            {
                this.parent = parent;
                cmdTimer = new Timer();
                cmdLs = new Dictionary<string, byte>();
                timerIsStart = false;
                cmdTimer.Tick += new EventHandler(TimerUp);
                cmdTimer.Interval = 1000;
                time = 1000;

            }
        }

        #endregion
    }
}
