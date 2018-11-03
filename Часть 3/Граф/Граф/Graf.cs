using System;
using System.Windows.Forms;

namespace Граф
{
    class Graf
    {
        //Матрица пропускных способностей
        protected double[,] matrix;
        //Получение и задание значений матрицы пропускных способностей
        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
        //Количество строк
        public int rows;
        //Количество столбцов
        public int columns;
        protected int Rows
        {
            get { return rows; }
        }
        protected int Columns
        {
            get { return columns; }
        }
        //Конструкторы
        protected Graf(DataGridView table)
        {
            rows = table.RowCount;
            columns = table.ColumnCount;            
            matrix = new double[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    if (table[i, j].Value.ToString() != "-" && table[i, j].Value != null)
                        matrix[j, i] = Convert.ToDouble(table[i, j].Value);
                    else
                        matrix[j, i] = -1;
                }
        }
        protected Graf(double[,] graf)
        {
            rows = graf.GetLength(0);
            columns = graf.GetLength(1);
            matrix = new double[rows, columns];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    matrix[i, j] = graf[i, j];
        }


    }
}
