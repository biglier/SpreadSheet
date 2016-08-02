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
        List<string> Columns = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Thread ColumsThread = new Thread(CreateColums);
            ColumsThread.Start();
            dataGridViewTable.ColumnCount = 26;
            AddingColumns(Columns);

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
            if (Columns.Count < 1)
            {
                Columns.AddRange(GetAlphabeticalArray());
            }
            else
            {
                if (Columns.Count > 26)
                {

                }
                else
                {
                    string last = Columns[Columns.Count-1];
                    var array = GetAlphabeticalArray();
                    for(int i=0 ; i < array.Count; i++)
                    {
                        array[i] = last + array[i];
                    }
                }
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
            for(int i=0; i<columnsNames.Count; i++)
            {
                dataGridViewTable.Columns[i].Name = columnsNames[i];
            }
            
        }
    }
}
