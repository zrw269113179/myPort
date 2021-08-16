using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace myPort
{
    class UIControl
    {

        private delegate void AddTextBoxValueDelegate(UITextBox txtInfo, string value);
        static public void AddTextBoxValue(UITextBox txtInfo,string value)
        {
            if(txtInfo == null)
            {
                return;
            }
            if (txtInfo.InvokeRequired)//判断是否跨线程请求
            {
                AddTextBoxValueDelegate myDelegate = delegate (UITextBox txt,string text) { 
                    txt.AppendText( text);
                };
                txtInfo.Invoke(myDelegate, txtInfo, value);
            }
            else
            {
                txtInfo.AppendText(value);
            }
        }

        private delegate void ClearTextBoxValueDelegate(UITextBox txtInfo);
        static public void ClearTextBoxValue(UITextBox txtInfo)
        {
            if (txtInfo == null)
            {
                return;
            }
            if (txtInfo.InvokeRequired)//判断是否跨线程请求
            {
                ClearTextBoxValueDelegate myDelegate = delegate (UITextBox txt) { txt.Text = ""; };
                txtInfo.Invoke(myDelegate, txtInfo);
            }
            else
            {
                txtInfo.Text = "";
            }
        }
        public static int index = 0;
        public static int show = 0;
        public delegate void SeriesAddPointDelegate(UILineChart txtInfo, string x, int value);
        static public void AddSeriesPoint(UILineChart txtInfo, string x, int value)
        {
            if (txtInfo == null)
            {
                return;
            }
            if (txtInfo.InvokeRequired)//判断是否跨线程请求
            {
                SeriesAddPointDelegate myDelegate = delegate (UILineChart a, string b, int c) {
                    
                    
                    if (index < a.Option.Series[b].DataCount + 1)
                    {
                        a.Option.Series[b].Add(index+1, c);
                        index = a.Option.Series[b].DataCount;
                        if (index > 200)
                        {
                            if (index <= show + 20)
                            {
                                txtInfo.Option.XAxis.Max = show + 20;
                                txtInfo.Option.XAxis.MaxAuto = false;
                                txtInfo.Option.XAxis.Min = show - 200;
                                txtInfo.Option.XAxis.MinAuto = false;
                                show++;
                            }
                        }
                        else if (index == 200)
                        {
                            show = 200;
                            txtInfo.Option.XAxis.Max = show + 20;
                            txtInfo.Option.XAxis.MaxAuto = false;
                            txtInfo.Option.XAxis.Min = show - 200;
                            txtInfo.Option.XAxis.MinAuto = false;

                        }
                    }
                    else
                    {
                        a.Option.Series[b].Add(index, c);
                    }
                        
                    
                    txtInfo.Refresh();
                };
                txtInfo.Invoke(myDelegate, txtInfo,x, value);
            }
            else
            {
                index++;
                if (index > 200)
                {
                    txtInfo.Option.XAxis.Max = index + 20;
                    txtInfo.Option.XAxis.MaxAuto = false;
                    txtInfo.Option.XAxis.Min = index - 200;
                    txtInfo.Option.XAxis.MinAuto = false;
                }
                txtInfo.Option.Series[x].Add(index, value);
                txtInfo.Refresh();
            }
        }
    }
}
