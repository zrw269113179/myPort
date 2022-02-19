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
    

    
    public class ParsingObj
    {
        public string parsingName { get; set; }
        public string parsingStr { get; set; }
        public bool parsingCmd { get; set; }
        public string parsingCmdName { get; set; }
    }

    public class FuncObj
    {
        public string str { get; set; }
        public string name { get; set; }
        public int arrIndex { get; set; }
        public int arrLen { get; set; }
        public int value { get; set; }
    }
}
