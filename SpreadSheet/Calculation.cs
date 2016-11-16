using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public static class Calculation
    {
        private static Dictionary<char, Func<float, float, float>> _opreations = new Dictionary<char, Func<float, float, float>>
        {
            { '+', (x,y)=>x+y },
            { '-', (x,y)=>x-y },
            { '*', (x,y)=>x*y },
            { '/', (x,y)=>x/y }
        };

        public static float Calculate(char o, float x, float y)
        {
            if (!_opreations.ContainsKey(o))
                throw new ArgumentException(string.Format("Operation {0} is invalid", "op"));
            return _opreations[o](x, y);
        }
    }
}
