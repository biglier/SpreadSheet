using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public class Cell
    {
        public int vertical
        {
            get; protected set;
        }

        public int horizontal
        {
            get; protected set;
        }

        public StringBuilder conclusion
        {
            get; protected set;
        }

        public StringBuilder enter
        {
           get; protected set;
        } 

        public Cell(int vertical, int horizontal, StringBuilder enter)
        {
            this.vertical = vertical;
            this.horizontal = horizontal;
            this.enter = enter;
        }

        protected Cell()
        {

        }

        protected virtual void CreateConclusion() { }
    }
}
