using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SpreadSheet
{
    public partial class Form1 : Form
    {
        Dictionary<Coordinates, Cell> CellsDictionary = new Dictionary<Coordinates, Cell>();
        bool check = false;
        List<string> Columns = new List<string>();
        public Form1()
        {
            InitializeComponent();
            CreateColums();
            dataGridViewTable.RowCount = 256;
            for(int i=0; i< dataGridViewTable.RowCount; i++)
            {
                dataGridViewTable.Rows[i].HeaderCell.Value = i.ToString();
            }
        }

        private void dataGridViewTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void CheckCell()
        {
            
        }

        private void CreateColums()
        {
            int lastElement=0;
            List<string> columns = new List<string>();
            // Перенести функцію створення масиву колоное в клас і використати в ExpressionCellFactory
            if (dataGridViewTable.ColumnCount < 1)
            {
                columns.AddRange(GetAlphabeticalArray());
            }
            else
            {
                char last;
                if (dataGridViewTable.ColumnCount == 26)
                {
                    last = dataGridViewTable.Columns[0].Name[0];
                }
                else
                {
                    last = dataGridViewTable.Columns[dataGridViewTable.ColumnCount-1].Name[0];
                    if (last == 'I') { return; }
                    last++; 
                }
                columns = GetAlphabeticalArray();
                for (int i = 0; i < columns.Count; i++)
                {
                    columns[i]=last + columns[i];
                } 
                lastElement = dataGridViewTable.ColumnCount;
            }
            dataGridViewTable.ColumnCount = dataGridViewTable.ColumnCount + columns.Count;
            for (int i = 0; i < columns.Count; i++)
            {
                dataGridViewTable.Columns[lastElement+i].Name = columns[i];
            }
            Columns.AddRange(columns);
            MessageBox.Show(Columns.Count.ToString());
        }

        public List<string> GetAlphabeticalArray()
        {
            List<string> array = new List<string>();
            for (char s = 'A'; s <= 'Z'; s++)
            {
                array.Add( s.ToString());
            }
            return array;
        }

        private void AddingColumns(List<string> columnsNames)
        {
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateColums();
        }

        private void dataGridViewTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cellS()
        {

        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (dataGridViewTable.CurrentCell.Value!=null)
            {
                StringBuilder cellContent = new StringBuilder(dataGridViewTable.CurrentCell.Value.ToString());
                int vertical = dataGridViewTable.CurrentCell.ColumnIndex;
                int horizontal = dataGridViewTable.CurrentCell.RowIndex;
                Cell cell = CellFactory.GetCell(vertical, horizontal, cellContent, CellsDictionary,Columns);
                dataGridViewTable.CurrentCell.Value = cell.conclusion.ToString();
                textBox.Text = cell.enter.ToString();
                AddToCellDictionary(cell);
            }
        }

        private void AddToCellDictionary(Cell cell)
        {
            Coordinates coordinates = new Coordinates(cell.horizontal, cell.vertical);
            Cell existingCell;
            if (CellsDictionary.TryGetValue(coordinates, out existingCell))
                CellsDictionary.Remove(coordinates);
            CellsDictionary.Add(coordinates, cell);
            MessageBox.Show(CellsDictionary.Count.ToString());
        }

        private void dataGridViewTable_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTable.CurrentCell.Value== null)
            {
                textBox.Text = "";
            }
            else
            {
                Coordinates cordinates = new Coordinates(dataGridViewTable.CurrentCell.RowIndex, dataGridViewTable.CurrentCell.ColumnIndex);
                Cell existingCell;
                CellsDictionary.TryGetValue(cordinates, out existingCell);
                if (existingCell == null)
                    textBox.Text = dataGridViewTable.CurrentCell.Value.ToString();
                else
                    textBox.Text = existingCell.enter.ToString();
            }
        }
    }
}
