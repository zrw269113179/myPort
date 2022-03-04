
namespace myPort
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.串口配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新端口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCP服务端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCP客户端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.协议配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接收协议ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大小端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高位在前ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.低位在前ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.命令ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接收参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收发配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置区十六进制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接收区十六进制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图像数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.禁止加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.recList = new Sunny.UI.UIDataGridView();
            this.recName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recIsShow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sendList = new Sunny.UI.UIDataGridView();
            this.sendName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdList = new Sunny.UI.UIDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSend = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmdTimer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdTimerParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.LineChart = new Sunny.UI.UILineChart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移至开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移至最新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiButton9 = new Sunny.UI.UIButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.socketCliPanel = new System.Windows.Forms.Panel();
            this.uiButton8 = new Sunny.UI.UIButton();
            this.uiButton6 = new Sunny.UI.UIButton();
            this.uiButton5 = new Sunny.UI.UIButton();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.tcpCliPort = new Sunny.UI.UITextBox();
            this.tcpCliIP = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.socketSerPanel = new System.Windows.Forms.Panel();
            this.uiButton7 = new Sunny.UI.UIButton();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.serPort = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.serIP = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.serialPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.baudCombo = new Sunny.UI.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPort = new Sunny.UI.UIComboBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.button1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.sendBox = new Sunny.UI.UITextBox();
            this.uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            this.recBox = new Sunny.UI.UITextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.sendObjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recObjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.socketCliPanel.SuspendLayout();
            this.socketSerPanel.SuspendLayout();
            this.serialPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            this.uiTitlePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sendObjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recObjBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口配置ToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.协议配置ToolStripMenuItem,
            this.图像配置ToolStripMenuItem,
            this.数据保存ToolStripMenuItem,
            this.脚本ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 35);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1029, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 串口配置ToolStripMenuItem
            // 
            this.串口配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新端口ToolStripMenuItem,
            this.串口ToolStripMenuItem,
            this.tCP服务端ToolStripMenuItem,
            this.tCP客户端ToolStripMenuItem});
            this.串口配置ToolStripMenuItem.Name = "串口配置ToolStripMenuItem";
            this.串口配置ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.串口配置ToolStripMenuItem.Text = "端口配置";
            // 
            // 刷新端口ToolStripMenuItem
            // 
            this.刷新端口ToolStripMenuItem.Name = "刷新端口ToolStripMenuItem";
            this.刷新端口ToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.刷新端口ToolStripMenuItem.Text = "刷新端口";
            this.刷新端口ToolStripMenuItem.Click += new System.EventHandler(this.刷新端口ToolStripMenuItem_Click);
            // 
            // 串口ToolStripMenuItem
            // 
            this.串口ToolStripMenuItem.Checked = true;
            this.串口ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.串口ToolStripMenuItem.Name = "串口ToolStripMenuItem";
            this.串口ToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.串口ToolStripMenuItem.Text = "串口";
            this.串口ToolStripMenuItem.Click += new System.EventHandler(this.串口ToolStripMenuItem_Click);
            // 
            // tCP服务端ToolStripMenuItem
            // 
            this.tCP服务端ToolStripMenuItem.Name = "tCP服务端ToolStripMenuItem";
            this.tCP服务端ToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.tCP服务端ToolStripMenuItem.Text = "TCP服务端";
            this.tCP服务端ToolStripMenuItem.Click += new System.EventHandler(this.tCP服务端ToolStripMenuItem_Click);
            // 
            // tCP客户端ToolStripMenuItem
            // 
            this.tCP客户端ToolStripMenuItem.Name = "tCP客户端ToolStripMenuItem";
            this.tCP客户端ToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.tCP客户端ToolStripMenuItem.Text = "TCP客户端";
            this.tCP客户端ToolStripMenuItem.Click += new System.EventHandler(this.tCP客户端ToolStripMenuItem_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.配置ToolStripMenuItem.Text = "导入导出";
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 协议配置ToolStripMenuItem
            // 
            this.协议配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.接收协议ToolStripMenuItem,
            this.大小端ToolStripMenuItem});
            this.协议配置ToolStripMenuItem.Name = "协议配置ToolStripMenuItem";
            this.协议配置ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.协议配置ToolStripMenuItem.Text = "协议配置";
            // 
            // 接收协议ToolStripMenuItem
            // 
            this.接收协议ToolStripMenuItem.Name = "接收协议ToolStripMenuItem";
            this.接收协议ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.接收协议ToolStripMenuItem.Text = "接收协议";
            this.接收协议ToolStripMenuItem.Click += new System.EventHandler(this.接收协议ToolStripMenuItem_Click);
            // 
            // 大小端ToolStripMenuItem
            // 
            this.大小端ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.高位在前ToolStripMenuItem,
            this.低位在前ToolStripMenuItem});
            this.大小端ToolStripMenuItem.Name = "大小端ToolStripMenuItem";
            this.大小端ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.大小端ToolStripMenuItem.Text = "大小端";
            // 
            // 高位在前ToolStripMenuItem
            // 
            this.高位在前ToolStripMenuItem.Checked = true;
            this.高位在前ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.高位在前ToolStripMenuItem.Name = "高位在前ToolStripMenuItem";
            this.高位在前ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.高位在前ToolStripMenuItem.Text = "高位在前";
            this.高位在前ToolStripMenuItem.Click += new System.EventHandler(this.高位在前ToolStripMenuItem_Click);
            // 
            // 低位在前ToolStripMenuItem
            // 
            this.低位在前ToolStripMenuItem.Name = "低位在前ToolStripMenuItem";
            this.低位在前ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.低位在前ToolStripMenuItem.Text = "低位在前";
            this.低位在前ToolStripMenuItem.Click += new System.EventHandler(this.低位在前ToolStripMenuItem_Click);
            // 
            // 图像配置ToolStripMenuItem
            // 
            this.图像配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.曲线ToolStripMenuItem,
            this.命令ToolStripMenuItem,
            this.设置参数ToolStripMenuItem,
            this.接收参数ToolStripMenuItem,
            this.收发配置ToolStripMenuItem,
            this.设置区十六进制ToolStripMenuItem,
            this.接收区十六进制ToolStripMenuItem});
            this.图像配置ToolStripMenuItem.Name = "图像配置ToolStripMenuItem";
            this.图像配置ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.图像配置ToolStripMenuItem.Text = "界面配置";
            // 
            // 曲线ToolStripMenuItem
            // 
            this.曲线ToolStripMenuItem.Checked = true;
            this.曲线ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.曲线ToolStripMenuItem.Name = "曲线ToolStripMenuItem";
            this.曲线ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.曲线ToolStripMenuItem.Text = "曲线";
            this.曲线ToolStripMenuItem.Click += new System.EventHandler(this.曲线ToolStripMenuItem_Click);
            // 
            // 命令ToolStripMenuItem
            // 
            this.命令ToolStripMenuItem.Checked = true;
            this.命令ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.命令ToolStripMenuItem.Name = "命令ToolStripMenuItem";
            this.命令ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.命令ToolStripMenuItem.Text = "命令";
            this.命令ToolStripMenuItem.Click += new System.EventHandler(this.命令ToolStripMenuItem_Click);
            // 
            // 设置参数ToolStripMenuItem
            // 
            this.设置参数ToolStripMenuItem.Checked = true;
            this.设置参数ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.设置参数ToolStripMenuItem.Name = "设置参数ToolStripMenuItem";
            this.设置参数ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.设置参数ToolStripMenuItem.Text = "设置参数";
            this.设置参数ToolStripMenuItem.Click += new System.EventHandler(this.设置参数ToolStripMenuItem_Click);
            // 
            // 接收参数ToolStripMenuItem
            // 
            this.接收参数ToolStripMenuItem.Checked = true;
            this.接收参数ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.接收参数ToolStripMenuItem.Name = "接收参数ToolStripMenuItem";
            this.接收参数ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.接收参数ToolStripMenuItem.Text = "接收参数";
            this.接收参数ToolStripMenuItem.Click += new System.EventHandler(this.接收参数ToolStripMenuItem_Click);
            // 
            // 收发配置ToolStripMenuItem
            // 
            this.收发配置ToolStripMenuItem.Checked = true;
            this.收发配置ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.收发配置ToolStripMenuItem.Name = "收发配置ToolStripMenuItem";
            this.收发配置ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.收发配置ToolStripMenuItem.Text = "收发配置";
            this.收发配置ToolStripMenuItem.Click += new System.EventHandler(this.收发配置ToolStripMenuItem_Click);
            // 
            // 设置区十六进制ToolStripMenuItem
            // 
            this.设置区十六进制ToolStripMenuItem.Checked = true;
            this.设置区十六进制ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.设置区十六进制ToolStripMenuItem.Name = "设置区十六进制ToolStripMenuItem";
            this.设置区十六进制ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.设置区十六进制ToolStripMenuItem.Text = "设置区十六进制";
            this.设置区十六进制ToolStripMenuItem.Click += new System.EventHandler(this.设置区十六进制ToolStripMenuItem_Click);
            // 
            // 接收区十六进制ToolStripMenuItem
            // 
            this.接收区十六进制ToolStripMenuItem.Checked = true;
            this.接收区十六进制ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.接收区十六进制ToolStripMenuItem.Name = "接收区十六进制ToolStripMenuItem";
            this.接收区十六进制ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.接收区十六进制ToolStripMenuItem.Text = "接收区十六进制";
            this.接收区十六进制ToolStripMenuItem.Click += new System.EventHandler(this.接收区十六进制ToolStripMenuItem_Click);
            // 
            // 数据保存ToolStripMenuItem
            // 
            this.数据保存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始保存ToolStripMenuItem,
            this.保存图像数据ToolStripMenuItem});
            this.数据保存ToolStripMenuItem.Name = "数据保存ToolStripMenuItem";
            this.数据保存ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.数据保存ToolStripMenuItem.Text = "数据保存";
            // 
            // 开始保存ToolStripMenuItem
            // 
            this.开始保存ToolStripMenuItem.Name = "开始保存ToolStripMenuItem";
            this.开始保存ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.开始保存ToolStripMenuItem.Text = "开始保存";
            this.开始保存ToolStripMenuItem.Click += new System.EventHandler(this.开始保存ToolStripMenuItem_Click);
            // 
            // 保存图像数据ToolStripMenuItem
            // 
            this.保存图像数据ToolStripMenuItem.Name = "保存图像数据ToolStripMenuItem";
            this.保存图像数据ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.保存图像数据ToolStripMenuItem.Text = "保存图像数据";
            this.保存图像数据ToolStripMenuItem.Click += new System.EventHandler(this.保存图像数据ToolStripMenuItem_Click);
            // 
            // 脚本ToolStripMenuItem
            // 
            this.脚本ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载脚本ToolStripMenuItem,
            this.禁止加载ToolStripMenuItem});
            this.脚本ToolStripMenuItem.Name = "脚本ToolStripMenuItem";
            this.脚本ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.脚本ToolStripMenuItem.Text = "脚本";
            // 
            // 加载脚本ToolStripMenuItem
            // 
            this.加载脚本ToolStripMenuItem.Name = "加载脚本ToolStripMenuItem";
            this.加载脚本ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.加载脚本ToolStripMenuItem.Text = "加载脚本";
            this.加载脚本ToolStripMenuItem.Click += new System.EventHandler(this.加载脚本ToolStripMenuItem_Click);
            // 
            // 禁止加载ToolStripMenuItem
            // 
            this.禁止加载ToolStripMenuItem.Checked = true;
            this.禁止加载ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.禁止加载ToolStripMenuItem.Name = "禁止加载ToolStripMenuItem";
            this.禁止加载ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.禁止加载ToolStripMenuItem.Text = "禁止加载";
            this.禁止加载ToolStripMenuItem.Click += new System.EventHandler(this.禁止加载ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(2, 65);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1029, 461);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.recList, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.sendList, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1029, 339);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // recList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.recList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.recList.BackgroundColor = System.Drawing.Color.White;
            this.recList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.recList.ColumnHeadersHeight = 32;
            this.recList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.recList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recName,
            this.recValue,
            this.recIsShow});
            this.recList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recList.EnableHeadersVisualStyles = false;
            this.recList.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.recList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.recList.Location = new System.Drawing.Point(876, 3);
            this.recList.Name = "recList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.recList.RowHeadersVisible = false;
            this.recList.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 8F);
            this.recList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.recList.RowTemplate.Height = 23;
            this.recList.SelectedIndex = -1;
            this.recList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recList.ShowGridLine = true;
            this.recList.Size = new System.Drawing.Size(150, 333);
            this.recList.TabIndex = 3;
            this.recList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.recList_CellEndEdit);
            this.recList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.recList_CellValueChanged);
            this.recList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.recList_RowsRemoved);
            this.recList.Resize += new System.EventHandler(this.recList_Resize);
            // 
            // recName
            // 
            this.recName.DataPropertyName = "recName";
            this.recName.HeaderText = "数据名";
            this.recName.MinimumWidth = 6;
            this.recName.Name = "recName";
            this.recName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recName.Width = 20;
            // 
            // recValue
            // 
            this.recValue.DataPropertyName = "recValue";
            this.recValue.HeaderText = "数值";
            this.recValue.MinimumWidth = 6;
            this.recValue.Name = "recValue";
            this.recValue.ReadOnly = true;
            this.recValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recValue.Width = 20;
            // 
            // recIsShow
            // 
            this.recIsShow.DataPropertyName = "recIsShow";
            this.recIsShow.HeaderText = "图像";
            this.recIsShow.MinimumWidth = 6;
            this.recIsShow.Name = "recIsShow";
            this.recIsShow.Width = 125;
            // 
            // sendList
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.sendList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.sendList.BackgroundColor = System.Drawing.Color.White;
            this.sendList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sendList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.sendList.ColumnHeadersHeight = 32;
            this.sendList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sendList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sendName,
            this.sendValue});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sendList.DefaultCellStyle = dataGridViewCellStyle8;
            this.sendList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendList.EnableHeadersVisualStyles = false;
            this.sendList.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.sendList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.sendList.Location = new System.Drawing.Point(722, 3);
            this.sendList.Name = "sendList";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sendList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.sendList.RowHeadersVisible = false;
            this.sendList.RowHeadersWidth = 51;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 8F);
            this.sendList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.sendList.RowTemplate.Height = 23;
            this.sendList.SelectedIndex = -1;
            this.sendList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sendList.ShowGridLine = true;
            this.sendList.Size = new System.Drawing.Size(148, 333);
            this.sendList.TabIndex = 2;
            this.sendList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.sendList_CellEndEdit);
            this.sendList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.sendList_CellValueChanged);
            this.sendList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.sendList_RowsRemoved);
            this.sendList.Resize += new System.EventHandler(this.sendList_Resize);
            // 
            // sendName
            // 
            this.sendName.DataPropertyName = "sendName";
            this.sendName.HeaderText = "数据名";
            this.sendName.MinimumWidth = 6;
            this.sendName.Name = "sendName";
            this.sendName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sendName.Width = 125;
            // 
            // sendValue
            // 
            this.sendValue.DataPropertyName = "sendValue";
            dataGridViewCellStyle7.NullValue = "0";
            this.sendValue.DefaultCellStyle = dataGridViewCellStyle7;
            this.sendValue.HeaderText = "数值";
            this.sendValue.MinimumWidth = 6;
            this.sendValue.Name = "sendValue";
            this.sendValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sendValue.Width = 125;
            // 
            // cmdList
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmdList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.cmdList.BackgroundColor = System.Drawing.Color.White;
            this.cmdList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmdList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.cmdList.ColumnHeadersHeight = 32;
            this.cmdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.cmdList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.cmdSend,
            this.cmdTimer,
            this.cmdTimerParam});
            this.cmdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdList.EnableHeadersVisualStyles = false;
            this.cmdList.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmdList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.cmdList.Location = new System.Drawing.Point(414, 3);
            this.cmdList.Name = "cmdList";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmdList.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.cmdList.RowHeadersVisible = false;
            this.cmdList.RowHeadersWidth = 51;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 8F);
            this.cmdList.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.cmdList.RowTemplate.Height = 23;
            this.cmdList.SelectedIndex = -1;
            this.cmdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cmdList.ShowGridLine = true;
            this.cmdList.Size = new System.Drawing.Size(302, 333);
            this.cmdList.TabIndex = 4;
            this.cmdList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cmdList_CellContentClick);
            this.cmdList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cmdList_CellDoubleClick);
            this.cmdList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.cmdList_RowsRemoved);
            this.cmdList.Resize += new System.EventHandler(this.cmdList_Resize);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "sendName";
            this.dataGridViewTextBoxColumn1.HeaderText = "命令名";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "sendValue";
            this.dataGridViewTextBoxColumn2.HeaderText = "命令格式";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // cmdSend
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.NullValue = "发送";
            this.cmdSend.DefaultCellStyle = dataGridViewCellStyle13;
            this.cmdSend.HeaderText = "发送";
            this.cmdSend.MinimumWidth = 6;
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.ReadOnly = true;
            this.cmdSend.Text = "发送";
            this.cmdSend.ToolTipText = "发送";
            this.cmdSend.UseColumnTextForButtonValue = true;
            this.cmdSend.Width = 125;
            // 
            // cmdTimer
            // 
            this.cmdTimer.HeaderText = "连发";
            this.cmdTimer.MinimumWidth = 6;
            this.cmdTimer.Name = "cmdTimer";
            this.cmdTimer.ReadOnly = true;
            this.cmdTimer.Width = 125;
            // 
            // cmdTimerParam
            // 
            dataGridViewCellStyle14.NullValue = "1000";
            this.cmdTimerParam.DefaultCellStyle = dataGridViewCellStyle14;
            this.cmdTimerParam.HeaderText = " 间隔";
            this.cmdTimerParam.MinimumWidth = 6;
            this.cmdTimerParam.Name = "cmdTimerParam";
            this.cmdTimerParam.ReadOnly = true;
            this.cmdTimerParam.Width = 125;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.LineChart);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.uiButton9);
            this.splitContainer4.Size = new System.Drawing.Size(405, 333);
            this.splitContainer4.SplitterDistance = 292;
            this.splitContainer4.TabIndex = 5;
            // 
            // LineChart
            // 
            this.LineChart.ContextMenuStrip = this.contextMenuStrip1;
            this.LineChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineChart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.LineChart.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.LineChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.LineChart.Location = new System.Drawing.Point(0, 0);
            this.LineChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.LineChart.Name = "LineChart";
            this.LineChart.Size = new System.Drawing.Size(405, 292);
            this.LineChart.Style = Sunny.UI.UIStyle.Custom;
            this.LineChart.TabIndex = 5;
            this.LineChart.MouseEnter += new System.EventHandler(this.LineChart_MouseEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移至开始ToolStripMenuItem,
            this.移至最新ToolStripMenuItem,
            this.缩小ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 76);
            // 
            // 移至开始ToolStripMenuItem
            // 
            this.移至开始ToolStripMenuItem.Name = "移至开始ToolStripMenuItem";
            this.移至开始ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.移至开始ToolStripMenuItem.Text = "移至开始";
            this.移至开始ToolStripMenuItem.Click += new System.EventHandler(this.移至开始ToolStripMenuItem_Click);
            // 
            // 移至最新ToolStripMenuItem
            // 
            this.移至最新ToolStripMenuItem.Name = "移至最新ToolStripMenuItem";
            this.移至最新ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.移至最新ToolStripMenuItem.Text = "移至最新";
            this.移至最新ToolStripMenuItem.Click += new System.EventHandler(this.移至最新ToolStripMenuItem_Click);
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.缩小ToolStripMenuItem.Text = "缩小";
            this.缩小ToolStripMenuItem.Click += new System.EventHandler(this.缩小ToolStripMenuItem_Click);
            // 
            // uiButton9
            // 
            this.uiButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton9.Location = new System.Drawing.Point(0, 3);
            this.uiButton9.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton9.Name = "uiButton9";
            this.uiButton9.Size = new System.Drawing.Size(100, 35);
            this.uiButton9.TabIndex = 0;
            this.uiButton9.Text = "清空图像";
            this.uiButton9.Click += new System.EventHandler(this.uiButton9_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.socketCliPanel);
            this.splitContainer2.Panel1.Controls.Add(this.socketSerPanel);
            this.splitContainer2.Panel1.Controls.Add(this.serialPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1029, 118);
            this.splitContainer2.SplitterDistance = 175;
            this.splitContainer2.TabIndex = 0;
            // 
            // socketCliPanel
            // 
            this.socketCliPanel.Controls.Add(this.uiButton8);
            this.socketCliPanel.Controls.Add(this.uiButton6);
            this.socketCliPanel.Controls.Add(this.uiButton5);
            this.socketCliPanel.Controls.Add(this.uiLabel4);
            this.socketCliPanel.Controls.Add(this.tcpCliPort);
            this.socketCliPanel.Controls.Add(this.tcpCliIP);
            this.socketCliPanel.Controls.Add(this.uiLabel3);
            this.socketCliPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.socketCliPanel.Location = new System.Drawing.Point(0, 0);
            this.socketCliPanel.Name = "socketCliPanel";
            this.socketCliPanel.Size = new System.Drawing.Size(175, 118);
            this.socketCliPanel.TabIndex = 6;
            // 
            // uiButton8
            // 
            this.uiButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiButton8.Location = new System.Drawing.Point(3, 100);
            this.uiButton8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton8.Name = "uiButton8";
            this.uiButton8.Size = new System.Drawing.Size(41, 15);
            this.uiButton8.TabIndex = 6;
            this.uiButton8.Text = "清空";
            this.uiButton8.Click += new System.EventHandler(this.uiButton8_Click);
            // 
            // uiButton6
            // 
            this.uiButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton6.Location = new System.Drawing.Point(71, 74);
            this.uiButton6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton6.Name = "uiButton6";
            this.uiButton6.Size = new System.Drawing.Size(100, 35);
            this.uiButton6.TabIndex = 5;
            this.uiButton6.Text = "发送";
            this.uiButton6.Click += new System.EventHandler(this.uiButton6_Click);
            // 
            // uiButton5
            // 
            this.uiButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiButton5.Location = new System.Drawing.Point(3, 68);
            this.uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton5.Name = "uiButton5";
            this.uiButton5.Size = new System.Drawing.Size(57, 26);
            this.uiButton5.TabIndex = 4;
            this.uiButton5.Text = "连接";
            this.uiButton5.Click += new System.EventHandler(this.uiButton5_Click);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(4, 42);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(96, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 3;
            this.uiLabel4.Text = "服务器端口";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcpCliPort
            // 
            this.tcpCliPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tcpCliPort.DoubleValue = 9000D;
            this.tcpCliPort.FillColor = System.Drawing.Color.White;
            this.tcpCliPort.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tcpCliPort.IntValue = 9000;
            this.tcpCliPort.Location = new System.Drawing.Point(114, 39);
            this.tcpCliPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcpCliPort.Maximum = 2147483647D;
            this.tcpCliPort.Minimum = -2147483648D;
            this.tcpCliPort.MinimumSize = new System.Drawing.Size(1, 1);
            this.tcpCliPort.Name = "tcpCliPort";
            this.tcpCliPort.Size = new System.Drawing.Size(54, 34);
            this.tcpCliPort.TabIndex = 2;
            this.tcpCliPort.Text = "9000";
            this.tcpCliPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tcpCliPort.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            // 
            // tcpCliIP
            // 
            this.tcpCliIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tcpCliIP.FillColor = System.Drawing.Color.White;
            this.tcpCliIP.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tcpCliIP.Location = new System.Drawing.Point(39, 4);
            this.tcpCliIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcpCliIP.Maximum = 2147483647D;
            this.tcpCliIP.Minimum = -2147483648D;
            this.tcpCliIP.MinimumSize = new System.Drawing.Size(1, 1);
            this.tcpCliIP.Name = "tcpCliIP";
            this.tcpCliIP.Size = new System.Drawing.Size(129, 34);
            this.tcpCliIP.TabIndex = 1;
            this.tcpCliIP.Text = "127.0.0.1";
            this.tcpCliIP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(7, 7);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(37, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "IP";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // socketSerPanel
            // 
            this.socketSerPanel.Controls.Add(this.uiButton7);
            this.socketSerPanel.Controls.Add(this.uiButton4);
            this.socketSerPanel.Controls.Add(this.uiButton3);
            this.socketSerPanel.Controls.Add(this.serPort);
            this.socketSerPanel.Controls.Add(this.uiLabel2);
            this.socketSerPanel.Controls.Add(this.serIP);
            this.socketSerPanel.Controls.Add(this.uiLabel1);
            this.socketSerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.socketSerPanel.Location = new System.Drawing.Point(0, 0);
            this.socketSerPanel.Name = "socketSerPanel";
            this.socketSerPanel.Size = new System.Drawing.Size(175, 118);
            this.socketSerPanel.TabIndex = 12;
            // 
            // uiButton7
            // 
            this.uiButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton7.Location = new System.Drawing.Point(7, 76);
            this.uiButton7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton7.Name = "uiButton7";
            this.uiButton7.Size = new System.Drawing.Size(37, 33);
            this.uiButton7.TabIndex = 6;
            this.uiButton7.Text = "清空";
            this.uiButton7.Click += new System.EventHandler(this.uiButton7_Click);
            // 
            // uiButton4
            // 
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton4.Location = new System.Drawing.Point(71, 76);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(100, 35);
            this.uiButton4.TabIndex = 5;
            this.uiButton4.Text = "发送";
            this.uiButton4.Click += new System.EventHandler(this.uiButton4_Click);
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton3.Location = new System.Drawing.Point(114, 39);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(57, 29);
            this.uiButton3.TabIndex = 4;
            this.uiButton3.Text = "侦听";
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // serPort
            // 
            this.serPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.serPort.DoubleValue = 9000D;
            this.serPort.FillColor = System.Drawing.Color.White;
            this.serPort.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.serPort.IntValue = 9000;
            this.serPort.Location = new System.Drawing.Point(47, 39);
            this.serPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serPort.Maximum = 2147483647D;
            this.serPort.Minimum = -2147483648D;
            this.serPort.MinimumSize = new System.Drawing.Size(1, 1);
            this.serPort.Name = "serPort";
            this.serPort.Size = new System.Drawing.Size(53, 34);
            this.serPort.TabIndex = 3;
            this.serPort.Text = "9000";
            this.serPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.serPort.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(3, 42);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(57, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "端口";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serIP
            // 
            this.serIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.serIP.FillColor = System.Drawing.Color.White;
            this.serIP.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.serIP.Location = new System.Drawing.Point(47, 4);
            this.serIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serIP.Maximum = 2147483647D;
            this.serIP.Minimum = -2147483648D;
            this.serIP.MinimumSize = new System.Drawing.Size(1, 1);
            this.serIP.Name = "serIP";
            this.serIP.Size = new System.Drawing.Size(125, 34);
            this.serIP.TabIndex = 1;
            this.serIP.Text = "127.0.0.1";
            this.serIP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(4, 7);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(26, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "IP";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serialPanel
            // 
            this.serialPanel.Controls.Add(this.label1);
            this.serialPanel.Controls.Add(this.baudCombo);
            this.serialPanel.Controls.Add(this.label2);
            this.serialPanel.Controls.Add(this.cmbPort);
            this.serialPanel.Controls.Add(this.uiButton1);
            this.serialPanel.Controls.Add(this.button1);
            this.serialPanel.Controls.Add(this.uiButton2);
            this.serialPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serialPanel.Location = new System.Drawing.Point(0, 0);
            this.serialPanel.Name = "serialPanel";
            this.serialPanel.Size = new System.Drawing.Size(175, 118);
            this.serialPanel.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口号";
            // 
            // baudCombo
            // 
            this.baudCombo.DataSource = null;
            this.baudCombo.FillColor = System.Drawing.Color.White;
            this.baudCombo.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baudCombo.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.baudCombo.Location = new System.Drawing.Point(67, 35);
            this.baudCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.baudCombo.MinimumSize = new System.Drawing.Size(63, 0);
            this.baudCombo.Name = "baudCombo";
            this.baudCombo.Padding = new System.Windows.Forms.Padding(0, 0, 43, 3);
            this.baudCombo.Radius = 2;
            this.baudCombo.Size = new System.Drawing.Size(104, 21);
            this.baudCombo.TabIndex = 11;
            this.baudCombo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // cmbPort
            // 
            this.cmbPort.DataSource = null;
            this.cmbPort.FillColor = System.Drawing.Color.White;
            this.cmbPort.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPort.Location = new System.Drawing.Point(67, 8);
            this.cmbPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPort.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Padding = new System.Windows.Forms.Padding(0, 0, 43, 3);
            this.cmbPort.Radius = 2;
            this.cmbPort.Size = new System.Drawing.Size(104, 21);
            this.cmbPort.TabIndex = 10;
            this.cmbPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(99, 61);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(73, 54);
            this.uiButton1.TabIndex = 7;
            this.uiButton1.Text = "发送";
            this.uiButton1.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(7, 64);
            this.button1.MinimumSize = new System.Drawing.Size(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 22);
            this.button1.TabIndex = 9;
            this.button1.Text = "打开串口";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(7, 89);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(37, 26);
            this.uiButton2.TabIndex = 8;
            this.uiButton2.Text = "清空";
            this.uiButton2.Click += new System.EventHandler(this.button3_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.uiTitlePanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.uiTitlePanel2);
            this.splitContainer3.Size = new System.Drawing.Size(850, 118);
            this.splitContainer3.SplitterDistance = 381;
            this.splitContainer3.TabIndex = 0;
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.sendBox);
            this.uiTitlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTitlePanel1.ForeColor = System.Drawing.Color.White;
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.uiTitlePanel1.Size = new System.Drawing.Size(381, 118);
            this.uiTitlePanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel1.TabIndex = 1;
            this.uiTitlePanel1.Text = "发送区";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.TitleHeight = 20;
            // 
            // sendBox
            // 
            this.sendBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sendBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendBox.FillColor = System.Drawing.Color.White;
            this.sendBox.Font = new System.Drawing.Font("微软雅黑", 9.25F);
            this.sendBox.Location = new System.Drawing.Point(0, 20);
            this.sendBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendBox.Maximum = 2147483647D;
            this.sendBox.Minimum = -2147483648D;
            this.sendBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.sendBox.Multiline = true;
            this.sendBox.Name = "sendBox";
            this.sendBox.Radius = 0;
            this.sendBox.ShowScrollBar = true;
            this.sendBox.Size = new System.Drawing.Size(381, 98);
            this.sendBox.Style = Sunny.UI.UIStyle.Custom;
            this.sendBox.TabIndex = 0;
            this.sendBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTitlePanel2
            // 
            this.uiTitlePanel2.Controls.Add(this.recBox);
            this.uiTitlePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTitlePanel2.ForeColor = System.Drawing.Color.White;
            this.uiTitlePanel2.Location = new System.Drawing.Point(0, 0);
            this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel2.Name = "uiTitlePanel2";
            this.uiTitlePanel2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.uiTitlePanel2.Size = new System.Drawing.Size(465, 118);
            this.uiTitlePanel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel2.TabIndex = 2;
            this.uiTitlePanel2.Text = "数据区";
            this.uiTitlePanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel2.TitleHeight = 20;
            // 
            // recBox
            // 
            this.recBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.recBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recBox.FillColor = System.Drawing.Color.White;
            this.recBox.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recBox.Location = new System.Drawing.Point(0, 20);
            this.recBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recBox.Maximum = 2147483647D;
            this.recBox.Minimum = -2147483648D;
            this.recBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.recBox.Multiline = true;
            this.recBox.Name = "recBox";
            this.recBox.Radius = 0;
            this.recBox.ShowScrollBar = true;
            this.recBox.Size = new System.Drawing.Size(465, 98);
            this.recBox.Style = Sunny.UI.UIStyle.Custom;
            this.recBox.TabIndex = 1;
            this.recBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // sendObjBindingSource
            // 
            this.sendObjBindingSource.DataSource = typeof(myPort.SendObj);
            // 
            // recObjBindingSource
            // 
            this.recObjBindingSource.DataSource = typeof(myPort.RecObj);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 528);
            this.CloseAskString = "确定是否关闭";
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.Text = "myPort";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdList)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.socketCliPanel.ResumeLayout(false);
            this.socketSerPanel.ResumeLayout(false);
            this.serialPanel.ResumeLayout(false);
            this.serialPanel.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sendObjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recObjBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 串口配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新端口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCP服务端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCP客户端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 协议配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接收协议ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripMenuItem 图像配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 曲线ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UIDataGridView sendList;
        private Sunny.UI.UIDataGridView recList;
        private System.Windows.Forms.ToolStripMenuItem 大小端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高位在前ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 低位在前ToolStripMenuItem;
        private System.Windows.Forms.BindingSource sendObjBindingSource;
        private System.Windows.Forms.BindingSource recObjBindingSource;
        private Sunny.UI.UIDataGridView cmdList;
        private System.Windows.Forms.ToolStripMenuItem 数据保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 命令ToolStripMenuItem;
        private Sunny.UI.UILineChart LineChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn recName;
        private System.Windows.Forms.DataGridViewTextBoxColumn recValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn recIsShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendValue;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIComboBox baudCombo;
        private Sunny.UI.UIComboBox cmbPort;
        private Sunny.UI.UIButton button1;
        private Sunny.UI.UITextBox recBox;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITextBox sendBox;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private System.Windows.Forms.ToolStripMenuItem 设置参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接收参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 收发配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存图像数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 脚本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载脚本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 禁止加载ToolStripMenuItem;
        private System.Windows.Forms.Panel serialPanel;
        private System.Windows.Forms.Panel socketSerPanel;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UITextBox serPort;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox serIP;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.Panel socketCliPanel;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox tcpCliPort;
        private Sunny.UI.UITextBox tcpCliIP;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton uiButton7;
        private Sunny.UI.UIButton uiButton8;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Sunny.UI.UIButton uiButton9;
        private System.Windows.Forms.ToolStripMenuItem 设置区十六进制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接收区十六进制ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn cmdSend;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cmdTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdTimerParam;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 移至开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移至最新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
    }
}

