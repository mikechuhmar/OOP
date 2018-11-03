using System;
using System.Windows.Forms;

namespace Курьерская_служба
{    
    public partial class Form1 : Form
    {
        Branches branches;
        int amountCouriers;
        int amounBranches;
        int step;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Build.createList(amCourCBox, 1, 5);
            Build.createList(amBrCBox, 3, 7);
            Build.createList(stepCB, 30, 300);
            Build.createLettersGrid(LettersGrid);
            timeBrGrid.Hide();
            crGrid.Hide();
            crL.Hide();            
            
        }

        private void amBrCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Build.createTimeGrid(timeBrGrid, timeBrLabel, Convert.ToInt32(amBrCBox.SelectedValue));
        }

        private void timeBrGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int column = timeBrGrid.CurrentCell.OwningRow.Index;
            int row = timeBrGrid.CurrentCell.OwningColumn.Index;
            timeBrGrid[column, row].Value = timeBrGrid.CurrentCell.Value;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LettersGrid.ClearSelection();
            bool empty = false;
            for (int i = 0; i < timeBrGrid.RowCount; i++)
                for (int j = 0; j < timeBrGrid.RowCount; j++)
                    if (timeBrGrid[i, j].Value == null)
                        empty = true;
            try
            {
                
                amountCouriers = Convert.ToInt32(amCourCBox.Text);
                int[] numCou = new int[amountCouriers];
                int[] del = new int[amountCouriers];
                int[] delNotTime = new int[amountCouriers];
                int[] amSingleTrans = new int[amountCouriers];
                Time[] singleTransf = new Time[amountCouriers];
                for(int i = 0; i<amountCouriers; i++)
                {
                    numCou[i] = 0;
                    del[i] = 0;
                    delNotTime[i] = 0;
                    amSingleTrans[i] = 0;
                    singleTransf[i] = new Time(0, 0);
                }
                amounBranches = Convert.ToInt32(amBrCBox.Text);
                branches = new Branches(timeBrGrid, amounBranches);
                step = Convert.ToInt32(stepCB.Text);
                int numRow = 0;
                WorkDay[] days = new WorkDay[7];
                int numDay = 1;
                for (int i = 0; i < 7; i++)
                {

                    days[i] = new WorkDay(branches, amountCouriers, LettersGrid);
                    
                }
                
                foreach (WorkDay d in days)
                {
                    
                    d.ModelDay(step, ref numRow, currentDayTB, numDay);
                    numDay++;
                    currentDayTB.Refresh();
                    currentDayTB.Text = numDay.ToString();
                }
                Build.createCourierRes(crGrid, crL);
                for (int i = 0; i < amountCouriers; i++)
                {
                    foreach(WorkDay d in days)
                    {
                        numCou[i] = d.couriers[i].Number;
                        del[i] += d.couriers[i].deliveredLetters.Count;
                        delNotTime[i] += d.couriers[i].deliveredNotTime;
                        amSingleTrans[i] += d.couriers[i].amountSingleTransfers;
                        singleTransf[i] = singleTransf[i] + d.couriers[i].timeSingleTranfers;
                    }
                }
                for (int i = 0; i < amountCouriers; i++)
                {
                    crGrid[0, i].Value = numCou[i];
                    crGrid[1, i].Value = del[i];
                    crGrid[2, i].Value = delNotTime[i];
                    crGrid[3, i].Value = amSingleTrans[i];
                    crGrid[4, i].Value = singleTransf[i].inString;
                }
            }
            catch
            {
                if (amCourCBox.Text == "")
                    MessageBox.Show("Не выбрано количество курьеров");
                if (amBrCBox.Text == "")
                    MessageBox.Show("Не выбрано количество филиалов");
                if (empty)
                    MessageBox.Show("Не все пути введены");
            }
        }

        private void timeBrGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':                
                case (char)Keys.Back:
                case (char)Keys.Delete:
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                break;
            }
        }
    }
}
