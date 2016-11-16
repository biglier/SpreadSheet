using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public static class NumericCellFactory 
    {
        public static Cell GetCell(int vertical, int horizontal, StringBuilder enter)
        {
            IntCell intCell = new IntCell(vertical, horizontal, enter);
            if (intCell.value != null)
            {
                return intCell;
            }
            else
            {
                FloatCell floatCell = new FloatCell(vertical, horizontal, enter);
                if(floatCell.value!= null)
                {
                    return floatCell;
                }
                else
                {
                    string s = "#Cannot convert to numeric";
                    return new ErrorCell(vertical, horizontal, enter,s );
                }
            }
        }
    }
}
