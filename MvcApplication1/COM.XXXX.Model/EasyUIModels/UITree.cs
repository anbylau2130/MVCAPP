using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COM.XXXX.EasyUIModels
{
    public class UITree
    {
        public string id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public string Checked { get; set; }
        public string state { get; set; }
        public object attributes { get; set; }
        List<UITree> _children = new List<UITree>();
        public List<UITree> children
        {
            get { return _children; }
            set { _children = value; }
        }
    }

}
