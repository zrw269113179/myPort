
namespace myPort
{
    partial class ProForm
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
            this.proName = new Sunny.UI.UITextBox();
            this.proStr = new Sunny.UI.UITextBox();
            this.replyName = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.reply = new Sunny.UI.UICheckBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // proName
            // 
            this.proName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.proName.FillColor = System.Drawing.Color.White;
            this.proName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.proName.Location = new System.Drawing.Point(77, 39);
            this.proName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.proName.Maximum = 2147483647D;
            this.proName.Minimum = -2147483648D;
            this.proName.MinimumSize = new System.Drawing.Size(1, 1);
            this.proName.Name = "proName";
            this.proName.Size = new System.Drawing.Size(614, 29);
            this.proName.TabIndex = 0;
            this.proName.Text = "uiTextBox1";
            this.proName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // proStr
            // 
            this.proStr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.proStr.FillColor = System.Drawing.Color.White;
            this.proStr.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.proStr.Location = new System.Drawing.Point(13, 106);
            this.proStr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.proStr.Maximum = 2147483647D;
            this.proStr.Minimum = -2147483648D;
            this.proStr.MinimumSize = new System.Drawing.Size(1, 1);
            this.proStr.Multiline = true;
            this.proStr.Name = "proStr";
            this.proStr.Size = new System.Drawing.Size(678, 193);
            this.proStr.TabIndex = 1;
            this.proStr.Text = "uiTextBox2";
            this.proStr.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // replyName
            // 
            this.replyName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.replyName.FillColor = System.Drawing.Color.White;
            this.replyName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.replyName.Location = new System.Drawing.Point(123, 309);
            this.replyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.replyName.Maximum = 2147483647D;
            this.replyName.Minimum = -2147483648D;
            this.replyName.MinimumSize = new System.Drawing.Size(1, 1);
            this.replyName.Name = "replyName";
            this.replyName.Size = new System.Drawing.Size(569, 29);
            this.replyName.TabIndex = 2;
            this.replyName.Text = "uiTextBox3";
            this.replyName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(9, 39);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(61, 23);
            this.uiLabel1.TabIndex = 3;
            this.uiLabel1.Text = "协议名";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(9, 78);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(84, 23);
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.Text = "协议格式";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reply
            // 
            this.reply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reply.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.reply.Location = new System.Drawing.Point(14, 309);
            this.reply.MinimumSize = new System.Drawing.Size(1, 1);
            this.reply.Name = "reply";
            this.reply.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.reply.Size = new System.Drawing.Size(102, 29);
            this.reply.TabIndex = 5;
            this.reply.Text = "是否回复";
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(592, 346);
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
            this.uiButton2.Location = new System.Drawing.Point(436, 346);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(100, 35);
            this.uiButton2.TabIndex = 7;
            this.uiButton2.Text = "取消";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // ProForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 384);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.reply);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.replyName);
            this.Controls.Add(this.proStr);
            this.Controls.Add(this.proName);
            this.Name = "ProForm";
            this.Text = "ProForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox proName;
        private Sunny.UI.UITextBox proStr;
        private Sunny.UI.UITextBox replyName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UICheckBox reply;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
    }
}