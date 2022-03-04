using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Win32;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace myPort
{
    public partial class Form1 : Sunny.UI.UIForm
    {


        public Parse parse;
        public bool isRecHex = true; // 十六进制接收
        public bool isSendHex = true; // 十六进制发送

        dynamic pyScript; // py脚本
        string scriptPath; // py脚本路径
        bool needScript = false; // 需要调用py脚本

        private bool needSave = false; // 是否需要保存数据
        public Form1()
        {
            InitializeComponent();

            串口ToolStripMenuItem_Click(null, new EventArgs());
            GetComList();

            if (cmbPort.Items.Count > 0)
            {
                cmbPort.SelectedIndex = 0;
            }
            baudCombo.SelectedIndex = 3;

            chart_init();

            sendList.Columns[0].Width = (int)(0.5 * sendList.Width);
            sendList.Columns[1].Width = (int)(0.49 * sendList.Width);

            recList.Columns[0].DataPropertyName = "recName";
            recList.Columns[1].DataPropertyName = "recValue";
            recList.Columns[2].DataPropertyName = "recIsShow";
            recList.Columns[0].Width = (int)(0.42 * recList.Width);
            recList.Columns[1].Width = (int)(0.42 * recList.Width);
            recList.Columns[2].Width = (int)(0.15 * recList.Width);

            recList.AllowUserToAddRows = true;
            serialPort.ReadTimeout = 500;/*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/

            parse = new Parse(this);

        }

        #region 参数操作
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "myPort(*.myPort)|*.myPort";
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名,不带路径
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
            XmlReaderSettings settings = new XmlReaderSettings();//设置读取XML时的属性.
            settings.IgnoreComments = true;//XML忽略注释.

            XmlReader xmlReader = XmlReader.Create(path, settings);//实例化一个XmlReader对象,解析XML文件
            doc.Load(xmlReader);//从指定的 XmlReader 加载 XML 文档.
            XmlNode root = doc.SelectSingleNode("setup");//读取根元素下的子元素集合
            XmlNode dataformatNode = root.SelectSingleNode("dataformat");//取仅有的一个元素
            if (dataformatNode != null)
            {
                XmlElement dataformat = (XmlElement)dataformatNode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
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
            XmlNode scriptNode = root.SelectSingleNode("script");//取仅有的一个元素
            if (scriptNode != null)
            {
                XmlElement script = (XmlElement)scriptNode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                if (script.GetAttribute("needScript") == "False")
                {
                    needScript = false;
                    禁止加载ToolStripMenuItem.Checked = true;
                }
                else
                {
                    needScript = true;
                    禁止加载ToolStripMenuItem.Checked = false;
                }

                scriptPath = script.GetAttribute("path");
                if (scriptPath != null)
                {
                    if (!string.IsNullOrEmpty(scriptPath))
                    {
                        try
                        {
                            ScriptEngine pyEngine = Python.CreateEngine();//创建Python解释器对象
                            pyScript = pyEngine.ExecuteFile(scriptPath);//读取脚本文件
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                    }


                }
            }

            XmlNode serialNode = root.SelectSingleNode("serial");//取仅有的一个元素
            if (serialNode != null)
            {
                XmlElement serial = (XmlElement)serialNode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                baudCombo.Text = serial.GetAttribute("baud");
                string com = serial.GetAttribute("com");
                if (cmbPort.Items.Contains(com))
                {
                    cmbPort.Text = com;
                }
            }
            XmlNode tcpSerNode = root.SelectSingleNode("service");//取仅有的一个元素
            if (tcpSerNode != null)
            {
                XmlElement tcpSer = (XmlElement)tcpSerNode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                serIP.Text = tcpSer.GetAttribute("IP");
                serPort.Text = tcpSer.GetAttribute("port");
            }
            XmlNode tcpCliNode = root.SelectSingleNode("client");//取仅有的一个元素
            if (tcpCliNode != null)
            {
                XmlElement tcpCli = (XmlElement)tcpCliNode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                tcpCliIP.Text = tcpCli.GetAttribute("IP");
                tcpCliPort.Text = tcpCli.GetAttribute("port");
            }

            XmlNode UINode = root.SelectSingleNode("UI");//取仅有的一个元素
            if (UINode != null)
            {
                XmlElement UI = (XmlElement)UINode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                if (UI.GetAttribute("recHex") == "False")
                {
                    接收区十六进制ToolStripMenuItem.Checked = false;
                }
                else
                {
                    接收区十六进制ToolStripMenuItem.Checked = true;
                }

                if (UI.GetAttribute("sendHex") == "False")
                {
                    设置区十六进制ToolStripMenuItem.Checked = false;
                }
                else
                {
                    设置区十六进制ToolStripMenuItem.Checked = true;
                }

                if (UI.GetAttribute("recUI") == "False")
                {
                    接收参数ToolStripMenuItem.Checked = false;
                }
                else
                {
                    接收参数ToolStripMenuItem.Checked = true;
                }
                if (UI.GetAttribute("setUI") == "False")
                {
                    设置参数ToolStripMenuItem.Checked = false;
                }
                else
                {
                    设置参数ToolStripMenuItem.Checked = true;
                }
                if (UI.GetAttribute("chartUI") == "False")
                {
                    曲线ToolStripMenuItem.Checked = false;
                }
                else
                {
                    曲线ToolStripMenuItem.Checked = true;
                }
                if (UI.GetAttribute("cmdUI") == "False")
                {
                    命令ToolStripMenuItem.Checked = false;
                }
                else
                {
                    命令ToolStripMenuItem.Checked = true;
                }
                if (UI.GetAttribute("configUI") == "False")
                {
                    收发配置ToolStripMenuItem.Checked = false;
                }
                else
                {
                    收发配置ToolStripMenuItem.Checked = true;
                }
                splitContainer1.Panel2Collapsed = !收发配置ToolStripMenuItem.Checked;
                menuUpdata();
            }


            XmlNode portChooseNode = root.SelectSingleNode("portChoose");//取仅有的一个元素
            if (portChooseNode != null)
            {
                XmlElement portChoose = (XmlElement)portChooseNode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                int i = Convert.ToInt32(portChoose.GetAttribute("choose"));
                if (i == 1)
                {
                    串口ToolStripMenuItem_Click(null, new EventArgs());
                }
                else if (i == 2)
                {
                    tCP服务端ToolStripMenuItem_Click(null, new EventArgs());
                }
                else if (i == 3)
                {
                    tCP客户端ToolStripMenuItem_Click(null, new EventArgs());
                }
            }

            XmlNode node = root.SelectSingleNode("recList");//取仅有的一个元素
            if (node != null)
            {
                XmlElement element = (XmlElement)node;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                XmlNodeList recs = element.ChildNodes;
                parse.recObjs.Clear();
                recList.Rows.Clear();
                foreach (XmlElement xml in recs)
                {
                    RecObj rec = new RecObj();
                    rec.recName = xml.GetAttribute("recName");
                    rec.recSeriseName = rec.recName;
                    rec.recIsShow = xml.GetAttribute("recIsShow") == "True" ? true : false;
                    if (rec.recIsShow)
                    {
                        chart_add_series(rec.recSeriseName);
                    }
                    parse.recObjs.Add(rec);
                    recList.Rows.Add(rec.recName, 0, rec.recIsShow);
                }
            }

            XmlNode parsingNode = root.SelectSingleNode("parsingList");//取仅有的一个元素
            if (parsingNode != null)
            {
                XmlElement parsingelement = (XmlElement)parsingNode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                XmlNodeList parsings = parsingelement.ChildNodes;
                parse.parse_rec_clear();
                foreach (XmlElement xml in parsings)
                {
                    ParsingObj parsing = new ParsingObj();
                    parsing.parsingName = xml.GetAttribute("parsingName");
                    parsing.parsingStr = xml.GetAttribute("parsingStr");
                    parsing.parsingCmdName = xml.GetAttribute("parsingCmdName");
                    parsing.parsingName = xml.GetAttribute("parsingName");
                    parsing.parsingCmd = xml.GetAttribute("parsingCmd") == "True" ? true : false;
                    
                    parse.parse_rec_add(parsing);
                }
            }

            XmlNode sendNode = root.SelectSingleNode("sendList");//取仅有的一个元素
            if (sendNode != null)
            {
                XmlElement sendelement = (XmlElement)sendNode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                XmlNodeList sends = sendelement.ChildNodes;
                parse.sendObjs.Clear();
                sendList.Rows.Clear();
                foreach (XmlElement xml in sends)
                {
                    SendObj send = new SendObj();
                    send.sendName = xml.GetAttribute("sendName");
                    send.sendValue = Convert.ToInt32(xml.GetAttribute("sendValue"), 16);
                    parse.sendObjs.Add(send);
                    if (设置区十六进制ToolStripMenuItem.Checked)
                    {
                        sendList.Rows.Add(send.sendName, Convert.ToString(send.sendValue, 16));
                    }
                    else
                    {
                        sendList.Rows.Add(send.sendName, Convert.ToString(send.sendValue, 10));
                    }
                }
            }

            XmlNode cmdNode = root.SelectSingleNode("cmdList");//取仅有的一个元素
            if (cmdNode != null)
            {
                XmlElement cmdelement = (XmlElement)cmdNode;//为了可以使用属性存储信息,我们把XmlNode转化为XmlElement.
                XmlNodeList cmds = cmdelement.ChildNodes;
                parse.cmd_send_clear();
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
                    {
                        cmd.time = Convert.ToInt32(temp);
                        cmd.cmdTimer.Interval = cmd.time;
                    }


                    temp = xml.GetAttribute("timerNeed");
                    if (!String.IsNullOrEmpty(temp))
                        cmd.timerNeed = temp == "True" ? true : false;

                    parse.cmd_send_add(cmd);
                    cmdList.Rows.Add(cmd.cmdName, cmd.cmdStr, null, cmd.timerNeed, cmd.time);
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

            XmlElement script = document.CreateElement("script");
            script.SetAttribute("path", scriptPath);
            script.SetAttribute("needScript", needScript.ToString());
            root.AppendChild(script);

            XmlElement UI = document.CreateElement("UI");
            UI.SetAttribute("recHex", 接收区十六进制ToolStripMenuItem.Checked.ToString());
            UI.SetAttribute("sendHex", 设置区十六进制ToolStripMenuItem.Checked.ToString());
            UI.SetAttribute("recUI", 接收参数ToolStripMenuItem.Checked.ToString());
            UI.SetAttribute("setUI", 设置参数ToolStripMenuItem.Checked.ToString());
            UI.SetAttribute("chartUI", 曲线ToolStripMenuItem.Checked.ToString());
            UI.SetAttribute("cmdUI", 命令ToolStripMenuItem.Checked.ToString());
            UI.SetAttribute("configUI", 收发配置ToolStripMenuItem.Checked.ToString());
            root.AppendChild(UI);

            XmlElement serial = document.CreateElement("serial");
            serial.SetAttribute("baud", baudCombo.Text);
            serial.SetAttribute("com", cmbPort.Text);
            root.AppendChild(serial);

            XmlElement client = document.CreateElement("client");
            client.SetAttribute("IP", tcpCliIP.Text);
            client.SetAttribute("port", tcpCliPort.Text);
            root.AppendChild(client);
            XmlElement service = document.CreateElement("service");
            service.SetAttribute("IP", serIP.Text);
            service.SetAttribute("port", serPort.Text);
            root.AppendChild(service);
            XmlElement portChoose = document.CreateElement("portChoose");
            if (串口ToolStripMenuItem.Checked)
            {
                portChoose.SetAttribute("choose", "1");
            }
            else if (tCP服务端ToolStripMenuItem.Checked)
            {
                portChoose.SetAttribute("choose", "2");
            }
            else if (tCP客户端ToolStripMenuItem.Checked)
            {
                portChoose.SetAttribute("choose", "3");
            }
            root.AppendChild(portChoose);

            // recList
            XmlElement recs = document.CreateElement("recList");
            root.AppendChild(recs);
            for (int i = 0; i < parse.recObjs.Count; i++)
            {
                XmlElement rec = document.CreateElement("rec");

                rec.SetAttribute("recName", parse.recObjs[i].recName);
                rec.SetAttribute("recIsShow", parse.recObjs[i].recIsShow.ToString());
                recs.AppendChild(rec);
            }

            XmlElement parsings = document.CreateElement("parsingList");
            root.AppendChild(parsings);
            for (int i = 0; i < parse.parsingObjs.Count; i++)
            {
                XmlElement parsing = document.CreateElement("parsing");

                parsing.SetAttribute("parsingName", parse.parsingObjs[i].parsingName);
                parsing.SetAttribute("parsingStr", parse.parsingObjs[i].parsingStr);
                parsing.SetAttribute("parsingCmd", parse.parsingObjs[i].parsingCmd.ToString());
                parsing.SetAttribute("parsingCmdName", parse.parsingObjs[i].parsingCmdName);
                parsings.AppendChild(parsing);
            }

            XmlElement sends = document.CreateElement("sendList");
            root.AppendChild(sends);
            for (int i = 0; i < parse.sendObjs.Count; i++)
            {
                XmlElement send = document.CreateElement("send");

                send.SetAttribute("sendName", parse.sendObjs[i].sendName);
                send.SetAttribute("sendValue", Convert.ToString(parse.sendObjs[i].sendValue, 16));
                sends.AppendChild(send);
            }

            XmlElement cmds = document.CreateElement("cmdList");
            root.AppendChild(cmds);
            for (int i = 0; i < parse.cmdObjs.Count; i++)
            {
                XmlElement cmd = document.CreateElement("cmd");

                cmd.SetAttribute("cmdName", parse.cmdObjs[i].cmdName);
                cmd.SetAttribute("cmdStr", parse.cmdObjs[i].cmdStr);
                cmd.SetAttribute("time", Convert.ToString(parse.cmdObjs[i].time));
                cmd.SetAttribute("timerNeed", parse.cmdObjs[i].timerNeed.ToString());
                cmds.AppendChild(cmd);
            }

            document.Save(path);

        }
        #endregion

        #region 界面逻辑

       
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
                foreach (Client client in clientList)
                {
                    client.Close();
                }
                if (tcpServer != null)
                {
                    tcpServer.Close();
                }
                clientList.Clear();
                if (tcpSerThread != null)
                {
                    tcpSerThread.Abort();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        /// 接收到数据
        public void update_rec_value(RecObj ls, int rowIndex)
        {
            if (接收区十六进制ToolStripMenuItem.Checked)
            {
                recList.Rows[rowIndex].Cells[1].Value = (object)(Convert.ToString(ls.recValue, 16));
            }
            else
            {
                recList.Rows[rowIndex].Cells[1].Value = (object)(Convert.ToString(ls.recValue, 10));
            }

            if (ls.recIsShow)
            {
                chart_add_point(ls.recName, ls.recValue);
            }
        }
        private void LineChart_MouseEnter(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(chart1_MouseEnter);//调用滚轮事件
        }
        #region  曲线操作
        UILineOption option = new UILineOption(); // 画图函数
        private void chart_init()
        {
            option.ToolTip.Visible = true;
            option.Title = null;
            option.XAxis.AxisLabel.DecimalCount = 1;
            option.XAxis.AxisLabel.AutoFormat = false;
            option.YAxis.AxisLabel.DecimalCount = 1;
            option.YAxis.AxisLabel.AutoFormat = false;
            option.Grid.Bottom = 30;
            option.Grid.Top = 30;
            option.Grid.Left = 30;
            option.Grid.Right = 30;
            option.XAxis.Min = 0;
            option.XAxis.Max = 220;
            option.XAxis.MaxAuto = false;
            option.XAxis.MinAuto = false;
            LineChart.SetOption(option);
        }
        private void chart_add_series(string name)
        {
            UILineSeries ser = new UILineSeries(name);
            ser.Smooth = true;
            option.AddSeries(ser);
        }
        private void chart_del_series(string str)
        {
            if (option.Series.ContainsKey(str))
            {
                UILineSeries series = option.Series[str];
                option.Series.TryRemove(str, out series);
            }
        }
        private void chart_add_point(string str, int value)
        {
            if (!option.Series.ContainsKey(str))
            {
                chart_add_series(str);
            }
            UILineSeries series = option.Series[str];
            if (series != null)
            {
                UIControl.AddSeriesPoint(LineChart, str, value);
            }
        }

        private void chart_clear()
        {
            foreach (UILineSeries series in option.Series.Values)
            {
                series.Clear();
            }
            UIControl.SeriesClear();
            option.XAxis.Data.Clear();
            option.YAxis.Data.Clear();
            option.XAxis.Min = 0;
            option.XAxis.Max = 220;
            LineChart.Refresh();
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
                }
            }
            else//鼠标向下滚动
            {
                if (UIControl.index > 200 && UIControl.show > 200)
                {
                    UIControl.show -= 1;
                    LineChart.Option.XAxis.Max -= 1;
                    LineChart.Option.XAxis.Min -= 1;
                }
            }
            LineChart.Refresh();
        }

        private void 移至开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIControl.show = 0;
            option.XAxis.Min = 0;
            option.XAxis.Max = 220;
        }
        private void 移至最新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIControl.show = UIControl.index;
        }
        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineChart.ZoomBack();
        }
        private void 正常大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineChart.ZoomNormal();
        }
        #endregion

        private void 开始保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!needSave)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt(*.txt)|*.txt";
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
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            StringBuilder sb = new StringBuilder();
            fs.SetLength(0);
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
            sfd.Filter = "cvs(*.cvs)|*.cvs";
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
            if (string.IsNullOrEmpty(hex))
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
        private void uiButton7_Click(object sender, EventArgs e)
        {
            UIControl.ClearTextBoxValue(recBox);
        }
        private void uiButton8_Click(object sender, EventArgs e)
        {
            UIControl.ClearTextBoxValue(recBox);
        }
        #region 界面配置


        private void 加载脚本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "python文件(*.py)|*.py";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                ScriptEngine pyEngine = Python.CreateEngine();//创建Python解释器对象
                pyScript = pyEngine.ExecuteFile(file);//读取脚本文件
                scriptPath = file;
            }
        }

        private void 禁止加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (needScript)
            {
                needScript = false;
            }
            else
            {
                needScript = true;
            }
            禁止加载ToolStripMenuItem.Checked = !needScript;
        }

        private void 串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPanel.Visible = true;
            socketSerPanel.Visible = false;
            socketCliPanel.Visible = false;
            串口ToolStripMenuItem.Checked = true;
            tCP服务端ToolStripMenuItem.Checked = false;
            tCP客户端ToolStripMenuItem.Checked = false;
        }
        private void tCP服务端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPanel.Visible = false;
            socketSerPanel.Visible = true;
            socketCliPanel.Visible = false;
            串口ToolStripMenuItem.Checked = false;
            tCP服务端ToolStripMenuItem.Checked = true;
            tCP客户端ToolStripMenuItem.Checked = false;
        }
        private void tCP客户端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPanel.Visible = false;
            socketSerPanel.Visible = false;
            socketCliPanel.Visible = true;
            串口ToolStripMenuItem.Checked = false;
            tCP服务端ToolStripMenuItem.Checked = false;
            tCP客户端ToolStripMenuItem.Checked = true;
        }
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
        private void recList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            parse.parse_rec_upgrade();
        }

        private void sendList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            parse.cmd_send_upgrade();
        }
        private void uiButton9_Click(object sender, EventArgs e)
        {
            chart_clear();
        }

        private void 设置区十六进制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            设置区十六进制ToolStripMenuItem.Checked = !设置区十六进制ToolStripMenuItem.Checked;
        }
        private void 接收区十六进制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            接收区十六进制ToolStripMenuItem.Checked = !接收区十六进制ToolStripMenuItem.Checked;
        }
        private void 曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            曲线ToolStripMenuItem.Checked = !曲线ToolStripMenuItem.Checked;
            menuUpdata();

        }
        private void 命令ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void recData(byte[] vs)
        {
            if (needScript)
            {
                try
                {
                    if (pyScript == null)
                    {
                        MessageBox.Show("脚本未加载");
                    }
                    else
                    {
                        vs = pyScript.dataRec(vs);
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

            }
            string bs = byteArrayToString(vs);
            UIControl.AddTextBoxValue(recBox, "<---");
            UIControl.AddTextBoxValue(recBox, bs);
            if (needSave)
            {
                writeFile("<---" + bs);
            }

            parse.dataParsing(vs, 高位在前ToolStripMenuItem.Checked);
        }

        #endregion

        #region recList

        private void recList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex < parse.recObjs.Count)
            {
                parse.recObjs.RemoveAt(e.RowIndex);
            }
        }

        private void recList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.RowIndex >= parse.recObjs.Count)
                {
                    parse.recObjs.Add(new RecObj());
                }

                if (e.ColumnIndex == 0)
                {
                    parse.recObjs[e.RowIndex].recName = (string)recList.Rows[e.RowIndex].Cells[0].FormattedValue;
                    if (String.IsNullOrEmpty(parse.recObjs[e.RowIndex].recName))
                    {
                        parse.recObjs[e.RowIndex].recSeriseName = parse.recObjs[e.RowIndex].recName;
                    }
                }

                else if (e.ColumnIndex == 2)
                {
                    if ((bool)recList.Rows[e.RowIndex].Cells[2].EditedFormattedValue == false)
                    {

                        //选中改为不选中
                        parse.recObjs[e.RowIndex].recIsShow = false;
                        // 删除曲线
                        chart_del_series(parse.recObjs[e.RowIndex].recSeriseName);
                    }
                    else
                    {
                        // 添加曲线
                        chart_add_series(parse.recObjs[e.RowIndex].recSeriseName);
                        //不选中改为选中
                        parse.recObjs[e.RowIndex].recIsShow = true;
                        
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
                if (e.RowIndex >= parse.sendObjs.Count)
                {
                    parse.sendObjs.Add(new SendObj());
                }

                if (e.ColumnIndex == 0)
                {
                    parse.sendObjs[e.RowIndex].sendName = (string)sendList.Rows[e.RowIndex].Cells[0].FormattedValue;
                }
                else if (e.ColumnIndex == 1)
                {
                    if (设置区十六进制ToolStripMenuItem.Checked)
                    {
                        parse.sendObjs[e.RowIndex].sendValue = Int32.Parse((string)sendList.Rows[e.RowIndex].Cells[1].FormattedValue, System.Globalization.NumberStyles.HexNumber);
                    }
                    else
                    {
                        parse.sendObjs[e.RowIndex].sendValue = Int32.Parse((string)sendList.Rows[e.RowIndex].Cells[1].FormattedValue, System.Globalization.NumberStyles.Integer);
                    }
                }
            }
        }
        private void sendList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex < parse.sendObjs.Count)
            {
                parse.sendObjs.RemoveAt(e.RowIndex);
            }
        }
        #endregion

        #region cmdList
        
        private void cmdList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.RowIndex >= parse.cmdObjs.Count)
                {
                    parse.cmdObjs.Add(new CmdObj(this));
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
            if (e.RowIndex < parse.cmdObjs.Count)
            {
                parse.cmdObjs.RemoveAt(e.RowIndex);
            }
        }

        private void cmdList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (cmdList.Columns[e.ColumnIndex].Name == "cmdSend" && parse.cmdObjs.Count > 0 && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                parse.sendCmd(parse.cmdObjs[e.RowIndex], 高位在前ToolStripMenuItem.Checked);
                if (parse.cmdObjs[e.RowIndex].timerNeed)
                {
                    if (parse.cmdObjs[e.RowIndex].timerIsStart == false)
                    {
                        parse.cmdObjs[e.RowIndex].cmdTimer.Start();
                    }
                }
            }
        }
        public class CmdObj
        {
            private void TimerUp(object sender, EventArgs e)
            {
                parent.parse.sendCmd(this, parent.高位在前ToolStripMenuItem.Checked);
            }
            public string cmdName { get; set; }
            public string cmdStr { get; set; }
            public Dictionary<string, byte> cmdLs { get; set; }
            public System.Windows.Forms.Timer cmdTimer { get; set; }
            public int time { get; set; }
            public bool timerNeed { get; set; }
            public bool timerIsStart { get; set; }
            public Form1 parent;
            public List<CmdPerParse> array { get; set; }
            public CmdObj(Form1 parent)
            {
                this.parent = parent;
                cmdTimer = new System.Windows.Forms.Timer();
                cmdLs = new Dictionary<string, byte>();
                timerIsStart = false;
                cmdTimer.Tick += new EventHandler(TimerUp);
                cmdTimer.Interval = 1000;
                time = 1000;
            }
        }
        #endregion

        #region 端口选择

        #region TCP相关
        public List<Client> clientList = new List<Client>();
        Socket tcpServer;
        Socket ClientSocket;
        Thread tcpSerThread;
        Client tcpClient;

        // 服务端
        private void uiButton3_Click(object sender, EventArgs e)
        {
            if (uiButton3.Text.Equals("侦听"))
            {
                IPAddress ip;
                if (IPAddress.TryParse(serIP.Text, out ip))
                {

                    tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建socket对象
                    tcpServer.Bind(new IPEndPoint(ip, serPort.IntValue));//绑定IP和申请端口

                    tcpServer.Listen(100);//设置客户端最大连接数
                    tcpSerThread = new Thread(tcpServerThread);//开启线程执行循环接收消息
                    tcpSerThread.Start();
                    Console.WriteLine("服务器已启动,等待连接.........");
                    uiButton3.Text = "断开";

                }
                else
                {
                    MessageBox.Show("非法IP");
                }

            }
            else if (uiButton3.Text.Equals("断开"))
            {
                try
                {
                    //
                    foreach (Client client in clientList)
                    {
                        client.Close();
                    }
                    if (tcpServer != null)
                    {
                        tcpServer.Close();
                    }
                    clientList.Clear();
                    if (tcpSerThread != null)
                    {
                        tcpSerThread.Abort();
                    }
                    uiButton3.Text = "侦听";
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }
        //客户端
        private void uiButton5_Click(object sender, EventArgs e)
        {
            if (uiButton5.Text.Equals("连接"))
            {
                IPAddress ip;
                if (IPAddress.TryParse(tcpCliIP.Text, out ip))
                {
                    ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        var result = ClientSocket.BeginConnect(ip, tcpCliPort.IntValue, null, null);
                        var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

                        if (!success)
                        {
                            throw new Exception("Failed to connect.");
                        }

                        // we have connected
                        ClientSocket.EndConnect(result);
                        tcpClient = new Client(ClientSocket, this);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    uiButton5.Text = "断开";
                }
                else
                {
                    MessageBox.Show("非法IP");
                }
            }
            else
            {
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }

                uiButton5.Text = "连接";
            }


        }
        void tcpServerThread()
        {
            while (true)//循环等待新客户端的连接
            {
                try
                {
                    Socket clientSocket = tcpServer.Accept();
                    Console.WriteLine((clientSocket.RemoteEndPoint as IPEndPoint).Address + "已连接");
                    Client client = new Client(clientSocket, this);
                    clientList.Add(client);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

            }
        }
        public class Client
        {
            private Socket clientSocket;
            private Thread t;
            private Form1 form;
            public string ip = "";
            private byte[] data = new byte[1024];
            public Client(Socket socket, Form1 form)
            {
                this.form = form;
                clientSocket = socket;
                ip = (clientSocket.RemoteEndPoint as IPEndPoint).Address.ToString();//获取客户端的ip
                t = new Thread(ReceiveMessage);//开启线程执行循环接收消息
                t.Start();
            }
            private void ReceiveMessage()//接收消息
            {
                int length = 0;//初始化消息的长度
                while (true)//循环接收消息
                {
                    try
                    {
                        length = clientSocket.Receive(data);//获取存放消息数据数组的长度
                        if (length != 0)//判断是否有数组内是否存放消息数据
                        {
                            byte[] vs = new byte[length];
                            Array.Copy(data, vs, length);
                            form.recData(vs);
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
            public void SendMessage(byte[] data)//发送消息
            {
                clientSocket.Send(data);
            }
            public bool Connected//获取该客户端的状态
            {
                get { return clientSocket.Connected; }
            }
            public void Close()
            {
                clientSocket.Close();
                t.Abort();
            }
        }
        private void uiButton4_Click(object sender, EventArgs e)
        {
            button2_Click(null, new EventArgs());
        }
        private void uiButton6_Click(object sender, EventArgs e)
        {
            button2_Click(null, new EventArgs());
        }

        #endregion

        #region 串口操作
        /// <summary>
        /// 从注册表获取系统串口列表
        /// </summary>
        public void GetComList()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
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
                try
                {
                    serialPort.BaudRate = Convert.ToInt32(baudCombo.Text);
                    serialPort.PortName = cmbPort.Text;
                    serialPort.Open();
                    isReceiving = false;
                    cmbPort.Enabled = false;
                    baudCombo.Enabled = false;
                    serialPort.ReadTimeout = 5;
                    button1.Text = "关闭串口";
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                
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
                    recData(vs);
                }));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
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
        public void sendData(byte[] vs)
        {
            if (needScript)
            {
                try
                {
                    if (pyScript == null)
                    {
                        MessageBox.Show("脚本未加载");
                    }
                    else
                    {
                        vs = pyScript.dataSend(vs);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

            }
            if (串口ToolStripMenuItem.Checked)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Write(vs, 0, vs.Length);
                }
            }
            else if (tCP服务端ToolStripMenuItem.Checked)
            {
                foreach (Client cli in clientList)
                {
                    cli.SendMessage(vs);
                }
            }
            else if (tCP客户端ToolStripMenuItem.Checked)
            {
                tcpClient.SendMessage(vs);
            }
            string bs = byteArrayToString(vs);
            UIControl.AddTextBoxValue(recBox, "--->");
            UIControl.AddTextBoxValue(recBox, bs);
            if (needSave)
            {
                writeFile("--->" + bs);
            }

        }




        #endregion

        #endregion

        
    }
}
