using System;
using System.Windows.Forms;
using System.IO;

namespace Граф
{
    class UndirectedGraf: Graf
    {       
        //Конструкторы
        public UndirectedGraf(DataGridView table): base(table){}
        public UndirectedGraf(double[,] matrix) : base(matrix) { }
        //Создание таблицы
        public static void CreateTable(DataGridView table, int amountVertex)
        {
            //Названия строк и столбцов
            string Vertex = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            table.ColumnCount = amountVertex;
            table.RowCount = table.ColumnCount;
            for (int i = 0, k = 0; i < table.RowCount; i++)
                for (int j = 0; j < table.ColumnCount; j++, k++)
                    table[i, j].Style.BackColor = System.Drawing.Color.White;
            for (int i = 0; i < amountVertex; i++)
            {
                string num = "";
                if (i / 26 != 0)
                    num = (i / 26).ToString();
                table.Rows[i].HeaderCell.Value = Vertex[i%26].ToString() + num;
                table.Columns[i].HeaderCell.Value = Vertex[i%26].ToString() + num;
            }
            for (int i = 0; i < table.RowCount; i++)
                for (int j = 0; j < table.ColumnCount; j++)
                {
                    if (i == j)
                        table[i, j].Value = "-";
                    else table[i, j].Value = null;
                }
                   
            
        }
        //Вывод графа в таблицу
        public void output(DataGridView table)
        {
            string Vertex = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            table.ColumnCount = Columns;
            table.RowCount = table.ColumnCount;
            for (int i = 0; i < Rows; i++)
            {
                string num = "";
                if (i / 26 != 0)
                    num = (i / 26).ToString();
                table.Rows[i].HeaderCell.Value = Vertex[i % 26].ToString() + num;
                table.Columns[i].HeaderCell.Value = Vertex[i % 26].ToString() + num;
            }
            for (int i = 0; i < table.RowCount; i++)
                for (int j = 0; j < table.ColumnCount; j++)
                {
                    table[i, j].Value = matrix[i, j];
                }
        }
        //Вывод контрольного примера в таблицу
        public static void ExampleTable(DataGridView table, string path)
        {
            string[] dataString = File.ReadAllText(path).Split(' ', '\n');
            string Vertex = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int amountVertex;
            amountVertex = Convert.ToInt32(Math.Sqrt(dataString.Length));
            table.RowCount = amountVertex;
            table.ColumnCount = table.RowCount;

            for (int i = 0, k = 0; i < table.RowCount; i++)
                for (int j = 0; j < table.ColumnCount; j++, k++)
                    table[i, j].Style.BackColor = System.Drawing.Color.White;

            for (int i = 0, k = 0; i < table.RowCount; i++)
                for (int j = 0; j < table.ColumnCount; j++, k++)
                {
                    if (dataString[k][0] == '-')
                        table[i, j].Value = "-";
                    else
                        table[i, j].Value = dataString[k];
                }
            for (int i = 0; i < amountVertex; i++)
            {
                string num = "";
                if (i / 26 != 0)
                    num = (i / 26).ToString();
                table.Rows[i].HeaderCell.Value = Vertex[i % 26].ToString() + num;
                table.Columns[i].HeaderCell.Value = Vertex[i % 26].ToString() + num;
            }
           

        }  
        //Количество обработанных вершин      
        int amTreated(bool [] vertex)
        {
            int k = 0;
            for (int i = 0; i < vertex.Length; i++)
                if (vertex[1])
                    k++;
            return k;
        }
        //Количество обработанных рёбер
        int amTreated(bool [,] edges)
        {
            int k = 0;
            int length = (int)Math.Sqrt(edges.Length);
            for (int i = 0; i < length; i++)
                for (int j = 0; i < length; j++)
                    if (edges[i, j])
                        k++;
            return k;
        }
        //Алгоритм ближайшего соседа
        public bool[,] NearestNeighborAlgorithm(DataGridView table, TextBox t)
        {
            //Массивы обработанных рёбер и вершин
            bool[,] treatedEdges = new bool[Rows, Columns];
            bool[] treatedVertrex = new bool[Rows];
            for (int i = 0; i < Rows; i++)
            {
                treatedVertrex[i] = false;
                for (int j = 0; j < Columns; j++)
                {
                    if (matrix[i, j] == -1)
                        treatedEdges[i, j] = true;
                    else
                        treatedEdges[i, j] = false;
                }
                    
            }
            treatedVertrex[0] = true;
            bool make = false;
            double minEdge;
            //Пока количество обработанных вершин меньше общего количества
            while (amTreated(treatedVertrex) <= Rows)
            {
                minEdge = double.MaxValue;                
                int min_i=0, min_j=0;
                int i = 0, j = 0;
                for (i = 0; i < Rows; i++)
                {
                    if(treatedVertrex[i])
                    {                        
                        for (j = 0; j < Columns; j++)
                        {
                            if (!treatedVertrex[j] && !treatedEdges[i, j] && (matrix[i, j] < minEdge))
                            {
                                minEdge = matrix[i, j];
                                min_i = i;
                                min_j = j;
                                make = true;                               
                            }                           
                        }
                    }
                }
                //Если больше невозможно обработать, то выход из цикла
                if (!make)
                    break;
                make = false;
                i = min_i;
                j = min_j;
                treatedVertrex[j] = true;
                treatedEdges[i, j] = true;
                treatedEdges[j, i] = treatedEdges[i, j];
            }
            return treatedEdges;
        }
        //Матрица Кирхгофа
        public UndirectedGraf kirhgof()
        {
            double[,] KirhgofMatrix = new double[Rows, Columns];
            double[] connect = new double[Rows];
            for (int i = 0; i < Rows; i++)
            {
                int countConnect = 0;
                for (int j = 0; j < Columns; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        countConnect++;
                        KirhgofMatrix[i, j] = -1;
                    }

                    else
                        KirhgofMatrix[i, j] = 0;
                }

                KirhgofMatrix[i, i] = countConnect;
            }
            return new UndirectedGraf(KirhgofMatrix);
        }
        public UndirectedGraf Kirhgof
        {
            get { return kirhgof(); }
        }
        //Минор матрицы при срезе правого столбца и нижней строки   
        public double [,] MinorRD()
        {
            double[,] answ = new double[Rows - 1, Columns - 1];
            for (int i = 0; i < Rows - 1; i++)
                for (int j = 0; j < Columns - 1; j++)
                    answ[i, j] = matrix[i, j];
            return answ;
        }
        public UndirectedGraf GrafMinorRD
        {
            get { return new UndirectedGraf(MinorRD()); }
            
        }
        //Произвольный минор
        void Minor(double[,] arr, ref double [,] answ, int a, int b, int m)
        {
            //double[,] answ = new double[Rows - 1, Columns - 1];
            int di = 0, dj;
            for (int i = 0; i < m - 1; i++)
            {
                if (i == a)
                    di = 0;
                dj = 0;
                for (int j = 0; j < m - 1; j++)
                {
                    if (j == b)
                        dj = 1;
                    answ[i, j] = matrix[i + di, j + dj];
                }                
            }                
            
        }
        public UndirectedGraf GrafMinor(double[,] arr, ref double[,] answ, int i, int j, int m)
        {
            Minor(arr, ref answ, i, j, m);
            return new UndirectedGraf(answ);

        }
        //Определитель матрицы
        double det(double [,] arr, int m)
        {
            double[,] p = new double[m, m];
            double answ = 0;
            int k = 1;
            int n = m - 1;
            if (m == 1)
            {
                answ = matrix[0, 0];
                return answ;
            }
            if (m == 2)
            {
                answ = arr[0, 0] * arr[1, 1] + arr[1, 0] * arr[0, 1];
            }
            if (m > 2)
            {
                for (int i = 0; i < m; i++)
                {
                    Minor(arr, ref p, i, 0, m);
                    answ += k * arr[i, 0] * det(p, n);
                    k = -k;
                }
            }
            return answ;
        }

        public double Det
        {
            get { return det(matrix, Rows); }
        }
        //Количество остовов
        public double AmountOfSkeletons 
        {
            get { return Kirhgof.GrafMinorRD.Det; }
        }
    }
}
