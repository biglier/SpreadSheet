using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    class ErrorCell :Cell
    {
        public ErrorCell(int vertical, int horizontal, StringBuilder enter, string conclusion)
            :base (vertical, horizontal,enter)
        {
            StringBuilder s = new StringBuilder(conclusion);
            this.conclusion = s;
        }
    }
}
