
using System.Collections.Generic;
using System.Windows.Forms;

namespace Курьерская_служба
{
    class Build
    {
        public static void createList(ComboBox c, int a, int b)
        {
            List<int> amCouriers = new List<int>();
            for (int i = a; i <= b; i++)
                amCouriers.Add(i);
            c.DataSource = amCouriers;
            c.Text = "";
            c.KeyPress += Comb_KeyPress; ;
        }
        public static void  createTimeGrid(DataGridView tg, Label tgl, int am)
        {
            tg.Show();
            tgl.Show();
            tg.ColumnCount = am;
            tg.RowCount = am;
            int rhw = 45;
            int chh = 35;
            int rh = 35;
            int cw = 35;
            tg.Width = rhw + am * cw + 20;
            tg.Height = chh + am * rh;
            tg.RowHeadersWidth = rhw;
            tg.ColumnHeadersHeight = chh;
            tg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            for (int i = 0; i < am; i++)
            {
                
                tg.Columns[i].Width = cw;
                tg.Columns[i].HeaderText = (i + 1).ToString();
                tg.Rows[i].HeaderCell.Value = (i + 1).ToString();
                tg.Rows[i].Height = rh;
                tg[i, i].Value = 0;
                tg[i, i].ReadOnly = true;
                
            }
            

        }
        public static void createLettersGrid(DataGridView lg)
        {
            List<string> title = new List<string>();
            title.Add("№");
            title.Add("Появление");
            title.Add("Отправитель");
            title.Add("Получатель");
            title.Add("Срочность");
            title.Add("Курьер");
            title.Add("Начало обработки");
            title.Add("Конец обработки");
            int[] columnWidth = { 30, 85, 100, 90, 80, 60, 80, 80 };
            
            lg.Show();
            lg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            lg.ColumnCount = 8;
            lg.RowCount = 8;
            int i = 0;
            foreach(string t in title)
            {
                lg.Columns[i].HeaderText = t;
                lg.Columns[i].Width = columnWidth[i];
                i++;
            }
            lg.Width = 700;
            lg.Height = 8 * 25;
        }
        public static void createCourierRes(DataGridView cResGrid, Label cResLabel)
        {
            cResGrid.Show();
            cResLabel.Show();
            List<string> title = new List<string>();
            title.Add("№");
            title.Add("Доставлено писем");
            title.Add("Доставлено не вовремя");
            title.Add("Холостые переезды");
            title.Add("Время холостых переездов");
            int[] columnWidth = { 30, 90, 90, 85, 85};
            cResGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            cResGrid.ColumnCount = 5;
            cResGrid.RowCount = 6;
            int i = 0;
            foreach (string t in title)
            {
                cResGrid.Columns[i].HeaderText = t;
                cResGrid.Columns[i].Width = columnWidth[i];
                i++;
            }
            cResGrid.Width = 450;
            cResGrid.Height = 220;
        }
        private static void Comb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
