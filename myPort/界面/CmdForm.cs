using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static myPort.Form1;

namespace myPort
{
    public partial class CmdForm : Sunny.UI.UIForm
    {
        public CmdObj obj { get; set; }
        Form1 form;
        int index;
        public CmdForm()
        {
            InitializeComponent();
        }
        public CmdForm(Form1 form,int index)
        {
            InitializeComponent();
            this.index = index;
            this.obj = form.parse.cmdObjs[index];
            this.form = form;
            cmdName.Text = obj.cmdName;
            cmdStr.Text = obj.cmdStr;
            timerNeed.Checked = obj.timerNeed;
            timerTime.Text = obj.time.ToString();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Sunny.UI.UIDataGridView cmdList = form.getCmdList();
            if (string.IsNullOrWhiteSpace(cmdName.Text) || string.IsNullOrWhiteSpace(cmdStr.Text))
            {
                form.parse.cmdObjs.RemoveAt(index);
                cmdList.Rows.RemoveAt(index);
                this.Close();
                return;
            }
            
            form.parse.cmdObjs[index].cmdName = cmdName.Text;
            form.parse.cmdObjs[index].cmdStr = cmdStr.Text;
            form.parse.cmdObjs[index].timerNeed = timerNeed.Checked;
            form.parse.cmdObjs[index].time =  Convert.ToInt32(timerTime.Text);
            form.parseCmd(form.parse.cmdObjs[index]);
            form.parse.cmdObjs[index].cmdTimer.Interval = form.parse.cmdObjs[index].time;
            if (!timerNeed.Checked)
            {
                form.parse.cmdObjs[index].cmdTimer.Stop();
            }
            cmdList.Rows[index].Cells[0].Value = form.parse.cmdObjs[index].cmdName;
            cmdList.Rows[index].Cells[1].Value = form.parse.cmdObjs[index].cmdStr;
            cmdList.Rows[index].Cells[3].Value = form.parse.cmdObjs[index].timerNeed;
            cmdList.Rows[index].Cells[4].Value = form.parse.cmdObjs[index].time;
            cmdList.EndEdit();
            this.Close();
        }
    }
}
