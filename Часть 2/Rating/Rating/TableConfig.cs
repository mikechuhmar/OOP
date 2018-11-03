using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Rating
{
    class TableConfig
    {
        List<Configuration> ListConfig;
        int length;
        DataGridView table;
        public TableConfig(DataGridView table)
        {
            this.table = table;
            string[] text = { "Конфигурация", "P1", "P2", "P3", "F12", "F17", "F18", "F21" };
            table.ColumnCount = 8;
            table.Columns[0].Width = 110;
            table.Columns[0].HeaderText = "Конфигурация";
            for (int i = 1; i <= 3; i++)
            {
                table.Columns[i].Width = 30;
                table.Columns[i].HeaderText = text[i];
            }
            for (int i = 4; i <= 7; i++)
            {
                table.Columns[i].Width = 50;
                table.Columns[i].HeaderText = text[i];
            }
            table.Width = 450;
            for (int i = 0; i < table.RowCount; i++)
            {
                table.Rows[i].Height = 25;
                table[0, i].Value = i + 1;
            }
            table.Font = new System.Drawing.Font("Microsoft Sans Serif", 10); ;



        }
        public void buildTable(int length)
        {
            this.length = length;
            for (int i = 0; i < length; i++)
            {
                table.Rows.Add();
                table[0, i].Value = i + 1;
            }           
               
        }
        private void readValues()
        {
            ListConfig = new List<Configuration>(length);
            List<int> index = new List<int>(length);
            List<int> P1 = new List<int>(length);
            List<int> P2 = new List<int>(length);
            List<int> P3 = new List<int>(length);


            for (int i = 0; i < table.RowCount; i++)
            {
                index.Add(Convert.ToInt32(table[0, i].Value));
                P1.Add(Convert.ToInt32(table[1, i].Value));
                P2.Add(Convert.ToInt32(table[2, i].Value));
                P3.Add(Convert.ToInt32(table[3, i].Value));
            }

            for (int i = 0; i < table.RowCount; i++)
                ListConfig.Add(new Configuration(index[i], P1[i], P2[i], P3[i]));
        }
        private void createRow(int index, int p1, int p2, int p3)
        {
            table.Rows.Add(index, p1, p2, p3);
        }
        public void Example()
        {
            table.Rows.Clear();
            createRow(1, 10, 8, 3);
            createRow(2, 9, 7, 5);
            createRow(3, 8, 5, 8);
            createRow(4, 8, 6, 7);
            createRow(5, 7, 9, 5);
            createRow(6, 7, 6, 8);
            createRow(7, 9, 4, 8);
            createRow(8, 8, 5, 8);
            createRow(9, 10, 8, 3);
            createRow(10, 9, 8, 4);
            length = 10;
        }
        public void outputCompute()
        {
            readValues();
            for (int i = 0; i < ListConfig.Count; i++)
                ListConfig[i].output(table, i);
            StreamWriter res = new StreamWriter("result.txt");
            res.WriteLine("№ P1 P2 P3 F12  F17  F18  F21");
            foreach(Configuration c in ListConfig)
            {
                res.WriteLine("{0} {1}  {2}  {3}  {4:0.000} {5:0.000} {6:0.000} {7:0.000}", c.conf, c.P[0], c.P[1], c.P[2], c.f12, c.f17, c.f18, c.f21);
            }
            res.Close();
        }
        public void outputSorted()
        {
            List<Configuration> sortConfigs = new List<Configuration>();
            sortConfigs = ListConfig.OrderByDescending(x => x.func).ToList();
            table.Rows.Clear();
            for (int i = 0; i < ListConfig.Count; i++)
            {
                table.Rows.Add();
                sortConfigs[i].output(table, i);
            }
        }
    }
}
