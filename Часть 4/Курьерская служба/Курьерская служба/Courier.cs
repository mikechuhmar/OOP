using System;
using System.Collections.Generic;
using System.Linq;

namespace Курьерская_служба
{
    //Перечисление статусов курьера
    public enum StatusCourier
    {
        Free,
        HasApplication,
        GetLetter,
    };
    class Courier
    {
        //Номер курьера
        int number;
        public int Number
        {
            get { return number; }
        }
        //Статус курьера
        public StatusCourier status = StatusCourier.Free;
        //Место начального расположения
        int firstPlace;
        //Место текущего расположения
        public int currentPlace;
        //Место следующего расположения
        public int nextPlace;
        //Время между текущим положением и следующим филиалом
        public Time timeCurrNext = new Time(0, 0);
        //Количество холостых переездов
        public int amountSingleTransfers = 0;
        //Время холостых переездов
        public Time timeSingleTranfers = new Time(0,0);
        //Количество обрабатываемых в данный момент писем
        int amountReceived = 0;
        //Заявка
        public Letter application;
        Branches branches;
        int amountBr;
        //Доставленные письма
        public List<Letter> deliveredLetters = new List<Letter>(100);
        //Обрабатываемые письма
        List<Letter> recieveLetters = new List<Letter>(100);
        public int deliveredNotTime = 0;
        public Courier(int firstPlace, Branches branches, int number)
        {
            this.number = number;
            this.branches = branches;
            amountBr = branches.Amount;
            this.firstPlace = firstPlace;
            currentPlace = firstPlace;
        }
        //Забрать заявку
        void getApplication(Time currentTime)
        {
            if (status == StatusCourier.HasApplication && application.status == StatusLetter.Engaged)
            {
                application.status = StatusLetter.Taking;
                application.startProcessTime = new Time(currentTime);
                application.journalize = false;
                status = StatusCourier.GetLetter;
                recieveLetters.Add(application);
                amountReceived++;             

            }
        }
        //Передача писем филиалу
        void lettersToBranch(Time currentTime)
        {
            if (status == StatusCourier.GetLetter)
            {
                currentPlace = recieveLetters.First().Destination;
                foreach (Letter r in recieveLetters)
                {
                    if (currentPlace == r.Destination && r.status != StatusLetter.Delivered)
                    {
                        r.status = StatusLetter.Delivered;
                        r.endProcessTime = new Time(currentTime);
                        amountReceived--;
                        r.journalize = false;
                        if (currentTime.inMinutes > r.Deadline.inMinutes)
                            deliveredNotTime++;
                        deliveredLetters.Add(r);
                    }
                }
                recieveLetters.RemoveAll(x => x.status == StatusLetter.Delivered);
            }

        }
        //Сбор писем из филиала
        void lettersFromBranch(Time currentTime, List<Letter> letters)
        {
            foreach (Letter l in letters)
            {
                if (l.status == StatusLetter.Application && l.Sender == currentPlace)
                {
                    recieveLetters.Add(l);
                    l.status = StatusLetter.Taking;
                    l.startProcessTime = currentTime;
                    l.ownCourier = this;
                    l.journalize = false;
                    amountReceived++;
                }
            }
        }
        //Приезд в филиал
        void arrivalToBranch(Time currentTime, List<Letter> letters)
        {
            //Если курьер приехал на место
            if (timeCurrNext.inMinutes == 0)
            {
                lettersToBranch(currentTime);
                lettersFromBranch(currentTime, letters);
                if (amountReceived == 0 && status == StatusCourier.GetLetter)
                {
                    status = StatusCourier.Free;
                }
                getApplication(currentTime);
                //Если у курьера есть письма, выбираем письмо, которое нужно доставить раньше всех
                if (status == StatusCourier.GetLetter)
                {
                    recieveLetters.OrderBy(x => (x.Deadline - branches.timeBetween(currentPlace, x.Destination)));
                    nextPlace = recieveLetters.First(x => x.status == StatusLetter.Taking).Destination;
                    Random rand = new Random();
                    timeCurrNext = branches.timeBetween(currentPlace, nextPlace) + new Time(0, rand.Next(5, 35));
                }
            }
        }
        //Новый момент времени
        public void ChangingTime(Time currentTime, List<Letter> letters)
        {
            arrivalToBranch(currentTime, letters);
            if (timeCurrNext.inMinutes != 0)
            {
                timeCurrNext = timeCurrNext - new Time(0, 1);                
            }       
        }
     
    }
}
