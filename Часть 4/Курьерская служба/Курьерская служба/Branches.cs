using System;
using System.Windows.Forms;

namespace Курьерская_служба
{
    class Branches
    {
        //Массив длительностей переездов между филиалов
        Time[,] timeTo;
        //Количество филиалов
        int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
        }

        public Branches(DataGridView tb, int amounBranches)
        {
            amount = amounBranches;
            timeTo = new Time[amount, amount];
            for (int i = 0; i < amount; i++)
                for (int j = 0; j < amount; j++)
                {
                    int t = Convert.ToInt32(tb[i, j].Value);
                    int h = t / 60;
                    int m = t % 60;
                    timeTo[i, j] = new Time(h, m);
                }
        }
        public Time timeBetween(int num1, int num2)
        {
            return timeTo[num1 - 1, num2 - 1];
        }
    }
}
