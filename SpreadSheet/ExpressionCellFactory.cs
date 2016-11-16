using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheet
{
    public static class ExpressionCellFactory
    {
        static Dictionary<Coordinates, Cell> dictionary;

        static List<String> columnsList;

        static int vertical,horizontal;

        static StringBuilder firstEnter;

        public static Cell GetCell(int _vertical, int _horizontal, StringBuilder enter, string conclusion, 
                                    Dictionary<Coordinates, Cell> _dictionary, List<String> _columnList)
        {
            dictionary = _dictionary;
            columnsList = _columnList;
            vertical = _vertical;
            horizontal = _horizontal;
            firstEnter = enter;
            if (enter.Length == 1)
            {
                string c = "#Input more characters";
                return new ErrorCell(vertical,horizontal,enter,c);
            }
            else
            {
                List<OperationPositions> operationPositions = new List<OperationPositions>();
                for (int i = 1; i < enter.Length; i++)
                {
                    if (enter[i] == '-' || enter[i] == '+' || enter[i] == '*' || enter[i] == '/')
                    {
                        operationPositions.Add(new OperationPositions(enter[i], i));
                    }
                }
                if (operationPositions.Count == 0)
                {
                    Cell cell = Parse(enter.ToString().Substring(1));
                    return cell;
                }
                if (operationPositions[0].position == 1 && operationPositions[operationPositions.Count-1].position==enter.Length-1)
                {
                    return new ErrorCell(vertical, horizontal, enter, "#Check operations position");
                }
                Cell fVarCell = Parse(enter.ToString().Substring(1, operationPositions[0].position - 1));
                if (fVarCell is ErrorCell) return fVarCell;
                float result = ReturnFloat(fVarCell);
                for (int j=0; j<operationPositions.Count; j++)
                {
                    if (operationPositions.Count>1 && j<operationPositions.Count-1 &&
                        operationPositions[j].position == operationPositions[j + 1].position + 1)
                    {
                        return new ErrorCell(vertical, horizontal, enter, "#Check operations");
                    }
                    Cell varCell;
                    int lenght = 0;
                    if (j == operationPositions.Count - 1)
                         lenght = enter.Length - (1+operationPositions[j].position);
                    else
                        lenght = operationPositions[j + 1].position - (operationPositions[j].position + 1);
                    varCell = Parse(enter.ToString().Substring(operationPositions[j].position + 1, lenght));
                    if (varCell is ErrorCell) return varCell;
                    float variable = ReturnFloat(varCell);
                    if (variable == 0 && operationPositions[j].operation == '/')
                        return new ErrorCell(vertical, horizontal, enter, "#zeroDivision");
                    try
                    {
                        result = Calculation.Calculate(operationPositions[j].operation, result, variable);
                    }
                    catch(Exception aEx)
                    {
                       return new ErrorCell(vertical, horizontal, enter, "#There is invalid in Calculation");
                    }
                }
                StringBuilder resultString = new StringBuilder(result.ToString());
                return NumericCellFactory.GetCell(vertical, horizontal, resultString);
            }            
        }

        private static float ReturnFloat(Cell cell)
        {
            float variable = 0F;
            if (cell is IntCell)
            {
                IntCell numCell = (IntCell)cell as IntCell;
                variable = (float)numCell.value;
            }
            if (cell is FloatCell)
            {
                FloatCell numCell = (FloatCell)cell as FloatCell;
                variable = (float)numCell.value;
            }
            return variable;
        }
        private static Cell Parse(string s)
        {
            StringBuilder enter = new StringBuilder(s);
            Cell cell = NumericCellFactory.GetCell(vertical,horizontal,enter);
            if (cell is ErrorCell)
            {
                return GetValueByCell(s); 
            }
            else
            {
                return cell;
            }
        }

        private static Cell GetValueByCell(string s)
        {
            int separatorPosition = -1;
            for(int j = s.Length-1; j>=0; j--)
            {
                if (s[j] != ',')
                {
                    try
                    {
                        int ch = Int32.Parse(s[j].ToString());
                    }
                    catch
                    {
                        separatorPosition = j;
                        break;
                    }
                }
            }
            if (separatorPosition == -1 || separatorPosition==s.Length)
            {
                s.Insert(0, '='.ToString());
                StringBuilder enter = new StringBuilder(s);
                return new ErrorCell(vertical,horizontal,enter,"#Check the entered data");
            }
            else
            {
                int h = Int32.Parse(s.Substring(separatorPosition+1));
                Coordinates coordinates =ConvertCellCoordinates(s.Substring(0,separatorPosition+1),h);
                if (coordinates.horizontal == -1)
                {
                    return new ErrorCell(vertical,horizontal,firstEnter,"#Check cell coordinates");
                }
                else
                {
                    Cell cell;
                    dictionary.TryGetValue(coordinates, out cell);
                    if (cell == null)
                    {
                        return new ErrorCell(vertical, horizontal, firstEnter, "#Reference to null cell");
                    }
                    return Parse(cell.conclusion.ToString());
                }
            }
        }

        private static Coordinates ConvertCellCoordinates(string name, int horizontal)
        {
            for (int i=0; i<columnsList.Count; i++)
            {
                if (columnsList[i] == name)
                {
                    return new Coordinates(horizontal, i);
                }
            }
            return new Coordinates(-1,-1);
        }
    }
}
