
using System.Collections.Generic;


namespace Парсер
{
    class UnconditionalOptimisation
    {
        //Введённая функция
        IntroducedFunction y;
        //Массив точек
        Coord[] x;
        //Координаты минимума
        Coord min;
        //Шаг
        double h;
        //Коэффициент уменьшения шага
        double beta;
        //Список новых точек, среди которых нужно искать минимум
        List<Coord> x_new = new List<Coord>();
        //Конструктор
        public UnconditionalOptimisation(IntroducedFunction _y, Coord _x0)
        {
            y = _y;
            x = new Coord[5];
            x[0] = _x0;
            x[1] = x[0];
            h = 0.01 * x[0].Norma;
            beta = 2;
        }
        //Свойство, возвращающее точку минимума
        public Coord Min
        { get { return min; } }

        //Поиск новых точек и добавление их в список
        void SuitablePoints(Coord x, int length, List<Coord> p)
        {

            Coord Ort = Coord.Ort(x.coord.Length, length - 1);
            p.Add(x + h * Ort);

            p.Add(x - h * Ort);

            if (length - 1 > 0)
            {
                SuitablePoints(new Coord(x + h * Ort), length - 1, p);
                SuitablePoints(new Coord(x - h * Ort), length - 1, p);
                SuitablePoints(new Coord(x), length - 1, p);
            }
        }
        //Исследовательский поиск среди новых точек и стартовой точки
        Coord Research(Coord x)
        {
            x_new = new List<Coord>();
            x_new.Add(x);
            SuitablePoints(x, x.coord.Length, x_new);
            //Предположительный минимум
            Coord x_ = new Coord(x);
            foreach (Coord p in x_new)
                if (y.Answer(p) < y.Answer(x_))
                    x_ = new Coord(p);
            return x_;
        }
        //Метод Хука-Дживса
        public int HookeJeeves()
        {
            int k = 0;
            double Eps = 0.001;
            int maxIter = 40;
            while (true)
            {
                //Получение новой точки с помощью исследовательского поиска
                x[2] = Research(x[1]);
                //Если не удалось найти подходящую точку, уменьшаем шаг
                if (y.Answer(x[2]) >= y.Answer(x[1]))
                {
                    h /= beta;
                    k++;
                }
                else
                {
                    do
                    {
                        //Ускоряющий поиск в новую точку в направлении минимума
                        x[3] = 2 * x[2] - x[1];
                        //Исследовательский поиск из новой точки
                        x[4] = Research(x[3]);
                        //Если удалось найти точку, лучшую чем точка найденная при первом исследовательском поиске, 
                        //стартовыя точка становится равна предыдущей лучшей точке, а предыдущая лучшая точка равна новой лучшей точке
                        if (y.Answer(x[4]) < y.Answer(x[2]))
                        {
                            x[1] = x[2];
                            x[2] = x[4];
                        }
                        //Иначе стартовая точка равна предыдущей лучшей точке и переход к началу алгоритма
                        else
                        {
                            x[1] = x[2];
                            break;
                        }
                    } while (y.Answer(x[4]) > y.Answer(x[2]));
                }
                if (h <= Eps || k >= maxIter)
                {
                    min = x[2];
                    break;
                }
            }
            return k;
        }
    }
}
