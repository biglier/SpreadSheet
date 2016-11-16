using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public static class CellFactory
    {
        public static Cell GetCell(int vertical, int horizontal, StringBuilder enter, Dictionary<Coordinates, Cell> dictionary,
                                    List<String> columnList)
        {
            char firstSymbol = enter[0];
            switch (firstSymbol)
            {
                case '\'':
                    {
                        return new StringCell(vertical, horizontal, enter);
                    }
                case '=':
                    {
                      return  ExpressionCellFactory.GetCell(vertical, horizontal, enter,"#In Proccess", dictionary,columnList);  
                    }
                default:
                        return NumericCellFactory.GetCell(vertical, horizontal, enter);
            }
        }
    }
}
