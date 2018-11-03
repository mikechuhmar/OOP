using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Курьерская_служба
{
    class WorkDay
    {
        Time begin = new Time(9, 0);
        Time end = new Time(18, 0);
        Time current = new Time(9, 0);
        Branches branches;
        List<Letter> letters = new List<Letter>(100);
        public List<Courier> couriers = new List<Courier>();
        DataGridView lettersGrid;
        int amountCourier;
        public WorkDay(Branches branches, int amountCourier, DataGridView lettersGrid)
        {
            this.branches = branches;
            this.amountCourier = amountCourier;
            distributionCouriers();
            this.lettersGrid = lettersGrid;
        }
        //Расставить курьеров
        void distributionCouriers()
        {
            Random rand = new Random();
            for (int i = 1; i <= amountCourier; i++)
            {
                int firstPlace = rand.Next(1, branches.Amount + 1);
                couriers.Add(new Courier(firstPlace, branches, i));
            }

        }
        //Узнать, есть ли недоставленные письма
        bool notDelivered()
        {
            bool flag = false;
            if (letters.Count <= 1)
                flag = true;
            else
            {
                foreach (Letter l in letters)
                {
                    if (l.status != StatusLetter.Delivered)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        //Смоделировать работу курьеров в течение дня
        public void ModelDay(int step, ref int numRow, TextBox cd, int numDay)
        {

            Time showTime = current + new Time(0, step);
            Time next = current;
            Random rand = new Random();
            int numLetter = 1;
            do
            {
                cd.Refresh();
                cd.Text = numDay.ToString();
                //Если ещё не конец рабочего дня
                if (current.inMinutes <= end.inMinutes)
                {
                    if (current.inMinutes >= next.inMinutes)
                    {
                        if (current.inMinutes != begin.inMinutes)
                        {
                            letters.Add(new Letter(numLetter, current, branches));
                            numLetter++;
                        }
                        int interval;
                        if (current.Hour >= 11 && current.Hour <= 15)
                            interval = rand.Next(2, 10);


                        else
                            interval = rand.Next(5, 20);
                        next = current + new Time(0, interval);
                    }
                }
                //Нойти свободных курьеров
                foreach (Letter l in letters)
                {
                    l.FindCourier(couriers);
                }
                foreach (Courier c in couriers)
                {
                    c.ChangingTime(current, letters);
                }
                Thread.Sleep(200/step);
                current = current + new Time(0, 1);
                //Вывести актуальную невыведенную информацию
                if (current.inMinutes == showTime.inMinutes)
                {
                    lettersGrid.Refresh();
                    foreach (Letter l in letters)
                    {
                        if (l.journalize == false)
                        {
                            
                            l.output(lettersGrid, numRow, numLetter);
                            numRow++;
                            l.journalize = true;
                        }
                    }
                    showTime = current + new Time(0, step);
                }
            } while (current.Hour < 24 || notDelivered());
            List<string> infoLetters = new List<string>();
            //Вывод в файл
            foreach (Letter l in letters)
            {
                string numCou;
                if (l.ownCourier == null)
                    numCou = "Нет";
                else
                    numCou = l.ownCourier.Number.ToString();
                string start;
                if (l.startProcessTime.Hour < 24)
                {
                    if (l.startProcessTime.Hour == 0)
                        start = "Пока нет";
                    else
                        start = l.startProcessTime.inString;
                }

                else
                    start = "Др.день";
                string end;
                if (start == "Др.день" || l.endProcessTime.Hour >= 24)
                    end = "Др.день";
                else
                {
                    if (l.endProcessTime.Hour == 0)
                        end = "Пока нет";

                    else
                        end = l.endProcessTime.inString;
                }
                infoLetters.Add(l.Number.ToString() + "  " + l.OriginTime.inString + "  " + l.Sender + "  " + l.Destination + "  " + numCou + "  " + l.Urgency.inString + "  " + start + "  " + end);
            }
            StreamWriter letterFile = new StreamWriter("letterInfo.txt", true);
            letterFile.WriteLine("День {0}", numDay);
            letterFile.WriteLine("Номер  Возникло  Отправитель  Получатель  Курьер  Срочность  Начало   Конец");
            foreach(string info in infoLetters)
            {
                letterFile.WriteLine(info);
            }
            letterFile.Close();
        }
    }
}
