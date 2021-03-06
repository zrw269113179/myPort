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
    public partial class ProForm : Sunny.UI.UIForm
    {
        public ParsingObj obj { get; set; }
        Protocols form;
        int index;

        public ProForm()
        {
            InitializeComponent();
        }

        public ProForm(Protocols form, int index)
        {
            InitializeComponent();
            this.index = index;
            this.obj = form.ls[index];
            this.form = form;
            proName.Text = obj.parsingName;
            proStr.Text = obj.parsingStr;
            reply.Checked = obj.parsingCmd;
            replyName.Text = obj.parsingCmdName;
            replyName.Items.Add("无");
            foreach(CmdObj obj in form.parent.parse.cmdObjs)
            {
                replyName.Items.Add(obj.cmdName);
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            Sunny.UI.UIDataGridView ls = form.getParsingList();
            if (string.IsNullOrWhiteSpace(proName.Text) || string.IsNullOrWhiteSpace(proStr.Text))
            {
                form.ls.RemoveAt(index);
                ls.Rows.RemoveAt(index);  
            }
            this.Close();
            return;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Sunny.UI.UIDataGridView ls = form.getParsingList();
            if (string.IsNullOrWhiteSpace(proName.Text) || string.IsNullOrWhiteSpace(proStr.Text))
            {
                form.ls.RemoveAt(index);
                ls.Rows.RemoveAt(index);
                this.Close();
                return;
            }
            
            form.ls[index].parsingName = proName.Text;
            form.ls[index].parsingStr = proStr.Text;
            form.ls[index].parsingCmd = reply.Checked;
            if(replyName.Text.Equals("无"))
            {
                form.ls[index].parsingCmdName = null;
            }
            else
            {
                form.ls[index].parsingCmdName = replyName.Text;
            }
            
            ls.Rows[index].Cells[0].Value = form.ls[index].parsingName;
            ls.Rows[index].Cells[1].Value = form.ls[index].parsingStr;
            ls.Rows[index].Cells[2].Value = form.ls[index].parsingCmd;
            ls.Rows[index].Cells[3].Value = form.ls[index].parsingCmdName;
            ls.Rows[index].Tag = obj;
            if(form.parent.parse.parse_rec_per_prase(obj))
            {
                ls.EndEdit();
                this.Close();
            }
        }
    }
}
