using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myPort
{
    public partial class Protocols : Sunny.UI.UIForm
    {
        public List<ParsingObj> ls;
        public Form1 parent;
        public Protocols()
        {
            InitializeComponent();
        }

        public Protocols(Form1 form)
        {
            InitializeComponent();
            this.ls = form.parse.parsingObjs;
            parent = form;
            parsingList.Columns[0].DataPropertyName = "parsingName";
            parsingList.Columns[1].DataPropertyName = "parsingStr";
            parsingList.Columns[2].DataPropertyName = "parsingCmd";
            parsingList.Columns[3].DataPropertyName = "parsingCmdName";
            parsingList.Columns[0].Width = (int)(0.2 * parsingList.Width);
            parsingList.Columns[1].Width = (int)(0.5 * parsingList.Width);
            parsingList.Columns[2].Width = (int)(0.1 * parsingList.Width);
            parsingList.Columns[3].Width = (int)(0.2 * parsingList.Width);
            if(ls.Count>0)
            {
                foreach(ParsingObj obj in ls)
                {
                    parsingList.Rows.Add(obj.parsingName, obj.parsingStr, obj.parsingCmd, obj.parsingCmdName);
                }
            }
        }

        private void Protocols_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        public Sunny.UI.UIDataGridView getParsingList()
        {
            return parsingList;
        }

        private void parsingList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex < ls.Count)
            {
                ls.RemoveAt(e.RowIndex);
            }
        }

        private void parsingList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.RowIndex >= ls.Count)
                {
                    ls.Add(new ParsingObj());
                    parsingList.AddRow();
                }
                ProForm cf = new ProForm(this, e.RowIndex);
                cf.Show();

            }
        }
    }
}
