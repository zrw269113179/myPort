using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPort
{
    public class RecObj
    {
        public string recSeriseName { get; set; }
        public string recName { get; set; }
        public int recValue { get; set; }
        public bool recIsShow { get; set; }
        public bool valueChanged { get; set; }
        public int tempValue { get; set; }
        public int tempIndex { get; set; }
        
    }
    public class SendObj
    {
        public string sendName { get; set; }
        public int sendValue { get; set; }
        public int tempValue { get; set; }
        public int tempIndex { get; set; }
    }

    public class PerParse
    {
        public RecObj rec { get; set; }
        public string scriptPath { get; set; }
        public int num { get; set; }
        public int valueLen;
        public string[] pList {get; set; }
        public PerParse()
        {
            num = -1;
        }
        public void reset()
        {
            rec = null;
            scriptPath = null;
            num = -1;
            valueLen = 1;
            pList = null;
        }
    }
    public class CmdPerParse
    {
        public SendObj send { get; set; }
        public string scriptPath { get; set; }
        public int num { get; set; }
        public int valueLen;
        public string[] pList { get; set; }
        public CmdPerParse()
        {
            num = -1;
        }
        public void reset()
        {
            send = null;
            scriptPath = null;
            num = -1;
            valueLen = 1;
            pList = null;
        }
    }


    public class ParsingObj
    {
        public string parsingName { get; set; }
        public string parsingStr { get; set; }
        public bool parsingCmd { get; set; }
        public string parsingCmdName { get; set; }
        public List<PerParse> array { get; set; }
    }

    public class FuncObj
    {
        public CmdPerParse cmdFunc { get; set; }
        public int arrIndex { get; set; }
        public int value { get; set; }
    }

}
