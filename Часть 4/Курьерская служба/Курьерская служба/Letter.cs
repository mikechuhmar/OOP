using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Курьерская_служба
{
    //Статус письма
    public enum StatusLetter
    {
        Application,
        Engaged,
        Taking,
        Delivered,

    };

    class Letter
    {
        //Номер письма
        int number;
        public int Number
        {
            get { return number; }
        }
        //Количество филиалов
        int amountBr;
        //Филиалы
        Branches branches;
        //Отправитель
        int sender;
        public int Sender
        { get { return sender; } }
        //Получатель
        int destination;
        public int Destination
        {
            get { return destination; }
        }
        //Курьер, забирающий это письмо 
        public Courier ownCourier = null;
        //Время появления
        Time originTime;
        public Time OriginTime
        { get { return originTime; } }
        //Срочность
        Time urgency;
        public Time Urgency
        {
            get { return urgency; }
        }
        //Крайний срок
        Time deadline;
        public Time Deadline
        {
            get
            {
                return deadline;
            }
        }
        //Время начала обработки
        public Time startProcessTime = new Time(0, 0);
        //Время конца обработки
        public Time endProcessTime = new Time(0, 0);
        //Статус письма
        public StatusLetter status = StatusLetter.Application;
        public bool journalize = false;
        //Выбор оправителя и получателя
        void chooseSenderDestination()
        {
            Random rand = new Random();
            sender = rand.Next(1, amountBr + 1);
            do
            {
                destination = rand.Next(1, amountBr);
            } while (destination == sender);
        }
        //Генерация срочности
        void chooseUrgency()
        {
            Random rand = new Random();
            int urg = rand.Next(30, 180);
            urgency = new Time(urg / 60, urg % 60);
        }

        public Letter(int number, Time originTime, Branches branches)
        {
            this.number = number;
            amountBr = branches.Amount;
            chooseSenderDestination();
            chooseUrgency();
            this.originTime = originTime;
            this.branches = branches;
            deadline = originTime + urgency;
        }
        //Поиск курьера
        public void FindCourier(List<Courier> couriers)
        {

            if (status == StatusLetter.Application)
            {
                bool freeCourier = false;
                //Есть ли свободные курьеры
                foreach (Courier c in couriers)
                {
                    if (c.status == StatusCourier.Free)
                    {
                        freeCourier = true;
                        break;
                    }
                }
                if (freeCourier)
                {
                    ownCourier = couriers.First(x => x.status == StatusCourier.Free);
                    foreach (Courier c in couriers)
                    {
                        if (c.status == StatusCourier.Free && branches.timeBetween(c.currentPlace, sender).inMinutes < branches.timeBetween(ownCourier.currentPlace, sender).inMinutes)
                        {
                            ownCourier = c;
                        }
                    }
                    ownCourier.status = StatusCourier.HasApplication;
                    ownCourier.application = this;
                    ownCourier.nextPlace = sender;
                    this.status = StatusLetter.Engaged;
                    //Время между текущим и следующим положениями курьера
                    Random rand = new Random();
                    ownCourier.timeCurrNext = branches.timeBetween(ownCourier.currentPlace, sender) + new Time(0, rand.Next(5, 35));
                    if (ownCourier.timeCurrNext.inMinutes != 0)
                    {
                        ownCourier.timeSingleTranfers = ownCourier.timeSingleTranfers + ownCourier.timeCurrNext;
                        ownCourier.amountSingleTransfers++;
                    }
                }

            }
        }
        //Вывод
        public void output(DataGridView lg, int index, int numDay)
        {
            lg.Rows.Add();
            string numCou;
            if (ownCourier == null)
                numCou = "Нет";
            else
                numCou = ownCourier.Number.ToString();
            string start;
            if (startProcessTime.Hour < 24)
            {
                if (startProcessTime.Hour == 0)
                    start = "Пока нет";
                else
                    start = startProcessTime.inString;
            }
               
            else
                start = "Др. день";
            string end;
            if (start == "Др. день" || endProcessTime.Hour >= 24)
                end = "Др. день";
            else
            {
                if (endProcessTime.Hour == 0)
                    end = "Пока нет";

                else
                    end = endProcessTime.inString;
            }
            lg.Rows[index].HeaderCell.Value = numDay;
            lg[0, index].Value = Number.ToString();
            lg[1, index].Value = OriginTime.inString;
            lg[2, index].Value = Sender;
            lg[3, index].Value = Destination;
            lg[5, index].Value = numCou;
            lg[4, index].Value = Urgency.inString;
            lg[6, index].Value = start;
            lg[7, index].Value = end;
            if(index <= 8)
            {
                lg.FirstDisplayedScrollingRowIndex = 0;
            }
            else
            {
                lg.FirstDisplayedScrollingRowIndex = index - 6;
            }
            lg.Refresh();         
            

        }
    }
}
