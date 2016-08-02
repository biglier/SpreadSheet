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

        public Form1()
        {
            InitializeComponent();
            CreateColums();
        }

        private void dataGridViewTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            CheckCell();
        }

        private void CheckCell()
        {

        }

        private void CreateColums()
        {
            int lastElement=0;
            List<string> columns = new List<string>();
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
                    columns[i] = last + columns[i];
                } 
                lastElement = dataGridViewTable.ColumnCount;
            }
            dataGridViewTable.ColumnCount = dataGridViewTable.ColumnCount + columns.Count;
            for (int i = 0; i < columns.Count; i++)
            {
                dataGridViewTable.Columns[lastElement+i].Name = columns[i];
            }
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
    }
}
