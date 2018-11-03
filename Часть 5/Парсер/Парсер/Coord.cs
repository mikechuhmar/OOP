using System;
using System.Windows.Forms;
namespace Парсер
{
    class Coord
    {
        //Массив координат
        public double[] coord;
        public double this[int i]
        {
            get
            {
                return coord[i];
            }
            set
            {
                coord[i] = value;
            }
        }
        //Конструкторы
        public Coord()
        {

        }
        public Coord(double[] point)
        {
            coord = point;
        }
        public Coord(Coord c)
        {
            coord = new double[c.coord.Length];
            for (int i = 0; i < c.coord.Length; i++)
                this[i] = c[i];
        }
        public static Coord operator -(Coord c)
        {
            Coord answ = new Coord();
            answ.coord = new double[c.coord.Length];
            for (int i = 0; i < c.coord.Length; i++)
            {
                answ[i] = -c[i];
            }
            return answ;
        }
        //Прегрузки операторов
        public static Coord operator +(Coord a, Coord b)
        {
            Coord answ = new Coord();
            answ.coord = new double[a.coord.Length];
            for (int i = 0; i < a.coord.Length; i++)
            {
                answ[i] = a[i] + b[i];
            }
            return answ;
        }
        public static Coord operator -(Coord a, Coord b)
        {
            Coord answ = new Coord();
            answ.coord = new double[a.coord.Length];
            for (int i = 0; i < a.coord.Length; i++)
            {
                answ[i] = a[i] - b[i];
            }
            return answ;
        }
        public static Coord operator *(double alfa, Coord a)
        {
            Coord answ = new Coord();
            answ.coord = new double[a.coord.Length];
            for (int i = 0; i < a.coord.Length; i++)
            {
                answ[i] = alfa * a[i];
            }
            return answ;
        }
        public static Coord operator *(Coord a, double alfa)
        {
            Coord answ = new Coord();
            answ.coord = new double[a.coord.Length];
            for (int i = 0; i < a.coord.Length; i++)
            {
                answ[i] = alfa * a[i];
            }
            return answ;
        }
        public static Coord operator /(Coord a, double alfa)
        {
            Coord answ = new Coord();
            answ.coord = new double[a.coord.Length];
            for (int i = 0; i < a.coord.Length; i++)
            {
                answ[i] = a[i] / alfa;
            }
            return answ;
        }
        //Норма вектора
        public double norma()
        {
            double normaSqr = 0;
            foreach (double c in coord)
                normaSqr += c * c;
            return Math.Sqrt(normaSqr);
        }
        public double Norma
        {
            get { return norma(); }
        }
        //Единичный орт
        public static Coord Ort(int amount, int number)
        {
            double[] array = new double[amount];
            for (int i = 0; i < amount; i++)
            {
                if (i == number)
                    array[i] = 1;
                else
                    array[i] = 0;
            }
            return new Coord(array);
        }
        
        //Различные типы вывода
        public void output()
        {
            foreach (double d in coord)
                Console.Write(" {0} ", d);
            Console.Write("\n");
        }
        public void output(TextBox t, int am)
        {
            string s = "";
            for (int i = 0; i < am; i++)
            {
                if (i < am - 1)
                    s += " " + Math.Round(coord[i], 3) + ";";
                else
                    s += " " + Math.Round(coord[i], 3);
            }
            t.Text = s;
        }
        
    }
}
