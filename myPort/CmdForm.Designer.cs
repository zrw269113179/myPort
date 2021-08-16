
namespace myPort
{
    partial class CmdForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.cmdName = new Sunny.UI.UITextBox();
            this.cmdStr = new Sunny.UI.UITextBox();
            this.timerNeed = new Sunny.UI.UICheckBox();
            this.timerTime = new Sunny.UI.UITextBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(4, 56);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(73, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "命令名";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(4, 94);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "命令格式";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdName
            // 
            this.cmdName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmdName.FillColor = System.Drawing.Color.White;
            this.cmdName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmdName.Location = new System.Drawing.Point(84, 56);
            this.cmdName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdName.Maximum = 2147483647D;
            this.cmdName.Minimum = -2147483648D;
            this.cmdName.MinimumSize = new System.Drawing.Size(1, 1);
            this.cmdName.Name = "cmdName";
            this.cmdName.Size = new System.Drawing.Size(601, 29);
            this.cmdName.TabIndex = 2;
            this.cmdName.Text = "uiTextBox1";
            this.cmdName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdStr
            // 
            this.cmdStr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmdStr.FillColor = System.Drawing.Color.White;
            this.cmdStr.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmdStr.Location = new System.Drawing.Point(8, 122);
            this.cmdStr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdStr.Maximum = 2147483647D;
            this.cmdStr.Minimum = -2147483648D;
            this.cmdStr.MinimumSize = new System.Drawing.Size(1, 1);
            this.cmdStr.Multiline = true;
            this.cmdStr.Name = "cmdStr";
            this.cmdStr.Size = new System.Drawing.Size(677, 173);
            this.cmdStr.TabIndex = 3;
            this.cmdStr.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerNeed
            // 
            this.timerNeed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.timerNeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.timerNeed.Location = new System.Drawing.Point(8, 304);
            this.timerNeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.timerNeed.Name = "timerNeed";
            this.timerNeed.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.timerNeed.Size = new System.Drawing.Size(96, 29);
            this.timerNeed.TabIndex = 4;
            this.timerNeed.Text = "是否连发";
            // 
            // timerTime
            // 
            this.timerTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.timerTime.DoubleValue = 1000D;
            this.timerTime.FillColor = System.Drawing.Color.White;
            this.timerTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.timerTime.IntValue = 1000;
            this.timerTime.Location = new System.Drawing.Point(111, 304);
            this.timerTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timerTime.Maximum = 2147483647D;
            this.timerTime.Minimum = -2147483648D;
            this.timerTime.MinimumSize = new System.Drawing.Size(1, 1);
            this.timerTime.Name = "timerTime";
            this.timerTime.Size = new System.Drawing.Size(574, 29);
            this.timerTime.TabIndex = 5;
            this.timerTime.Text = "1000";
            this.timerTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(585, 341);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 6;
            this.uiButton1.Text = "确定";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton2.Location = new System.Drawing.Point(436, 341);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(100, 35);
            this.uiButton2.TabIndex = 7;
            this.uiButton2.Text = "取消";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // CmdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 384);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.timerTime);
            this.Controls.Add(this.timerNeed);
            this.Controls.Add(this.cmdStr);
            this.Controls.Add(this.cmdName);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Name = "CmdForm";
            this.Text = "命令详情";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox cmdName;
        private Sunny.UI.UITextBox cmdStr;
        private Sunny.UI.UICheckBox timerNeed;
        private Sunny.UI.UITextBox timerTime;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
    }
}