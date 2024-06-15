using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_List
{
    internal class ConsoleMenuelement
    {

        public string Label { get; set; }
        public Action ActionToRun { get; set; }
        public ConsoleMenuelement(string label, Action actionToRun)
        {
            Label = label;
            ActionToRun = actionToRun;
        }
        public override string ToString()
        {
            return Label;
        }
    }
}
