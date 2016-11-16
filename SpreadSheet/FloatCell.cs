using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    class FloatCell : NumericCell
    {
        public float? value { get; protected set; }
        public FloatCell(int vertical, int horizontal, StringBuilder enter):
            base(vertical,horizontal,enter)
        {
            Parse();
        }

        protected override void Parse()
        {
            float result;
            if (float.TryParse(enter.ToString(), out result))
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
