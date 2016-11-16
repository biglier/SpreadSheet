using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public class NumericCell : Cell
    {
        public NumericCell(int vertical, int horizontal, StringBuilder enter)
            :base(vertical, horizontal, enter)
        {

        }

        protected virtual void Parse() { }
    }
}