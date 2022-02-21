
namespace myPort
{
    partial class Protocols
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.parsingList = new Sunny.UI.UIDataGridView();
            this.parsingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parsingValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parsingSend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.parsingCmd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.parsingList)).BeginInit();
            this.SuspendLayout();
            // 
            // parsingList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.parsingList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.parsingList.BackgroundColor = System.Drawing.Color.White;
            this.parsingList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.parsingList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.parsingList.ColumnHeadersHeight = 32;
            this.parsingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.parsingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parsingName,
            this.parsingValue,
            this.parsingSend,
            this.parsingCmd});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.parsingList.DefaultCellStyle = dataGridViewCellStyle3;
            this.parsingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parsingList.EnableHeadersVisualStyles = false;
            this.parsingList.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.parsingList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.parsingList.Location = new System.Drawing.Point(0, 35);
            this.parsingList.Name = "parsingList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.parsingList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.parsingList.RowHeadersVisible = false;
            this.parsingList.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.parsingList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.parsingList.RowTemplate.Height = 23;
            this.parsingList.SelectedIndex = -1;
            this.parsingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.parsingList.ShowGridLine = true;
            this.parsingList.Size = new System.Drawing.Size(800, 415);
            this.parsingList.Style = Sunny.UI.UIStyle.Custom;
            this.parsingList.TabIndex = 0;
            this.parsingList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.parsingList_CellDoubleClick);
            this.parsingList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.parsingList_RowsRemoved);
            // 
            // parsingName
            // 
            this.parsingName.HeaderText = "协议名";
            this.parsingName.MinimumWidth = 6;
            this.parsingName.Name = "parsingName";
            this.parsingName.ReadOnly = true;
            this.parsingName.Width = 125;
            // 
            // parsingValue
            // 
            this.parsingValue.HeaderText = "协议内容";
            this.parsingValue.MinimumWidth = 6;
            this.parsingValue.Name = "parsingValue";
            this.parsingValue.ReadOnly = true;
            this.parsingValue.Width = 125;
            // 
            // parsingSend
            // 
            this.parsingSend.HeaderText = "是否回复";
            this.parsingSend.MinimumWidth = 6;
            this.parsingSend.Name = "parsingSend";
            this.parsingSend.ReadOnly = true;
            this.parsingSend.Width = 125;
            // 
            // parsingCmd
            // 
            this.parsingCmd.HeaderText = "回复命令";
            this.parsingCmd.MinimumWidth = 6;
            this.parsingCmd.Name = "parsingCmd";
            this.parsingCmd.ReadOnly = true;
            this.parsingCmd.Width = 125;
            // 
            // Protocols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.parsingList);
            this.Name = "Protocols";
            this.RectColor = System.Drawing.Color.DarkViolet;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "protocols";
            this.TitleColor = System.Drawing.Color.DarkViolet;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Protocols_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.parsingList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        Sunny.UI.UIDataGridView parsingList;
        private System.Windows.Forms.DataGridViewTextBoxColumn parsingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn parsingValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn parsingSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn parsingCmd;
    }
}