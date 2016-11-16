using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public struct Coordinates
    {
        public Coordinates(int horizontal, int vertical)
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
        }
        public int horizontal { get; private set;}
       
        public int vertical { get; private set; }
    }
}
