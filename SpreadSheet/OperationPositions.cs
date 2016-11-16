using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    class OperationPositions
    {
        public char operation
        {
            get; protected set;
        }

        public int position
        {
            get; protected set;
        }

        public OperationPositions(char operation, int position)
        {
            this.operation = operation;
            this.position = position; ;
        }
    }
}
