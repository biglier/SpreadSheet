using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    class IntCell : NumericCell
    {
        public int? value { get; protected set; }
        public IntCell(int vertical, int horizontal, StringBuilder enter):
            base(vertical,horizontal,enter)
        {
            Parse();
        }

        protected override void Parse()
        {
            int result;
            if (Int32.TryParse(enter.ToString(), out result))
            {
                value = result;
                CreateConclusion();
            }         
        }

        protected override void CreateConclusion()
        {
            StringBuilder s = new StringBuilder(value.ToString());
            conclusion = s;
        }
    }
}
