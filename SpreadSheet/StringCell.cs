using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    class StringCell :Cell
    {
        public StringCell(int vertical, int horizontal, StringBuilder enter)
            :base(vertical, horizontal, enter)
        {
            String s = enter.ToString().Substring(1);
            conclusion = new StringBuilder(s);
        }
    }
}
