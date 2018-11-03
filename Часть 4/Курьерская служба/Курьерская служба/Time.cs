using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Курьерская_служба
{
    class Time
    {
        int minutes;
        int hours;
        public Time(int hours, int minutes)
        {
            this.minutes = minutes;
            this.hours = hours;
        }
        public Time(Time t)
        {
            minutes = t.minutes;
            hours = t.hours;
        }
        public int Minute
        {
            get { return minutes; }

        }
        public int Hour
        {
            get { return hours; }

        }
        public int inMinutes
        {
            get
            {
                return Hour * 60 + Minute;
            }
        }
        public static Time operator +(Time a, Time b)
        {
            int h = a.Hour + b.Hour + (a.Minute + b.Minute) / 60;
            int m = (a.Minute + b.Minute) % 60;
            return new Time(h, m);
        }
        public static Time operator -(Time a, Time b)
        {
            int h;
            int m;
            if (a.Minute < b.Minute)
            {
                h = a.Hour - b.Hour - 1;
                m = a.Minute - b.Minute + 60;
            }
            else
            {
                h = a.Hour - b.Hour;
                m = a.Minute - b.Minute;
            }
            return new Time(h, m);
        }
        public string inString
        {
            get
            {
                string t;
                if (Minute < 10)
                    t = Hour.ToString() + ":0" + Minute.ToString();
                else
                    t = Hour.ToString() + ":" + Minute.ToString();
                return t;

            }

        }

        public void output()
        {

            Console.WriteLine(inString);
        }
    }
}
