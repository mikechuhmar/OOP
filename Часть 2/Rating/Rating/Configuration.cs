using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace Rating
{
    class Configuration
    {
        public int conf;

        public List<float> P = new List<float>();
        private float min;
        private float max;
        public float f12;
        public float f17;
        public float f18;
        public float f21;
        public float func
        { get { return f17; } }
        
        void F12()
        {
            f12 = P.Average();
            //f12 = P[0];
        }
        void F17()
        {
            List<float> answ = new List<float>();
            if (max != min)
            {
                foreach (float p in P)
                {
                    answ.Add((p - min) / (max - min));
                }
            }
            if (answ.Count != 0)
            {
                f17 = answ.Average();
            }
            else
                f17 = 1 / 3f;
        }
        void F18()
        {
            List<float> answ = new List<float>();
            answ.Add(P[0] / max);
            answ.Add(P[1] / max);
            answ.Add(P[2] / max);
            f18 = answ.Average();

        }
        void F21()
        {
            f21 = 1 + f17 * (10 - 1);
        }
        public Configuration(int _conf, int p1, int p2, int p3)
        {
            conf = _conf;
            P = new List<float>(3);
            P.Add(p1);
            P.Add(p2);
            P.Add(p3);
            max = P.Max();
            min = P.Min();
            F12();
            F17();
            F18();
            F21();
        }
        public void output(DataGridView table, int index)
        {
            table[0, index].Value = conf;
            for (int i = 1; i <= 3; i++)
            {
                table[i, index].Value = P[i - 1];
                
            }
            table[4, index].Value = Math.Round(f12, 3);
            table[5, index].Value = Math.Round(f17, 3);
            table[6, index].Value = Math.Round(f18, 3);
            table[7, index].Value = Math.Round(f21, 3);
        }
    }
}
