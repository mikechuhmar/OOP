using System;
using System.Drawing;
using System.Windows.Forms;

namespace Граф
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Скрыть кнопки, поля
            AmountVerticesLabel.Visible = false;
            AmountVerticesTextBox.Visible = false;
            FindAmountSkeletonsButton.Visible = false;
            AmountSkeletonsTextBox.Visible = false;
            FindSkeletonMinWeightButton.Visible = false;            
            BuildMatrixButton.Visible = false;
        }

        private void SelectActionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            FindAmountSkeletonsButton.Visible = false;
            AmountSkeletonsTextBox.Visible = false;
            FindSkeletonMinWeightButton.Visible = false;            
            if (SelectActionListBox.SelectedIndex == 1)
            {
                AmountVerticesLabel.Visible = true;
                AmountVerticesTextBox.Visible = true;
                BuildMatrixButton.Visible = true;
            }
            else
            {
                AmountVerticesLabel.Visible = false;
                AmountVerticesTextBox.Visible = false;
                BuildMatrixButton.Visible = false;
                UndirectedGraf.ExampleTable(GrafGrid, "test_46_nn_2.txt");
                FindAmountSkeletonsButton.Visible = true;
                AmountSkeletonsTextBox.Visible = true;
                FindSkeletonMinWeightButton.Visible = true;                
            }            
        }

        private void BuildMatrixButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                FindAmountSkeletonsButton.Visible = true;
                AmountSkeletonsTextBox.Visible = true;
                FindSkeletonMinWeightButton.Visible = true;               
                UndirectedGraf.CreateTable(GrafGrid, Convert.ToInt32(AmountVerticesTextBox.Text));
            }
            catch
            {
                if (AmountVerticesTextBox.Visible == true && AmountVerticesTextBox.Text == "")
                {
                    MessageBox.Show("Введите количество вершин");
                }
            }
        }           

        private void FindAmountSkeletonsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GrafGrid.RowCount; i++)
                for (int j = 0; j < GrafGrid.ColumnCount; j++)
                    if (GrafGrid.Rows[j].Cells[i].Value == null || (string)GrafGrid.Rows[j].Cells[i].Value == "")
                        GrafGrid.Rows[j].Cells[i].Value = "-";
            UndirectedGraf graf = new UndirectedGraf(GrafGrid);
            AmountSkeletonsTextBox.Text = graf.AmountOfSkeletons.ToString();
        }

        

        private void GrafGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (GrafGrid.CurrentCell.Value != null)
            {
                int column = GrafGrid.CurrentCell.OwningRow.Index;
                int row = GrafGrid.CurrentCell.OwningColumn.Index;
                GrafGrid[column, row].Value = GrafGrid.CurrentCell.Value;

            }

        }

        private void FindSkeletonMinWeightButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GrafGrid.RowCount; i++)
                for (int j = 0; j < GrafGrid.ColumnCount; j++)
                    if (GrafGrid.Rows[j].Cells[i].Value == null)
                    {
                        GrafGrid[i, j].Value = "-";
                        GrafGrid[j, i].Value = "-";
                    }
                        
            UndirectedGraf graf = new UndirectedGraf(GrafGrid);            
            bool [,] skeleton = graf.NearestNeighborAlgorithm(GrafGrid, AmountSkeletonsTextBox);
            for (int i = 0; i < GrafGrid.RowCount; i++)
            {
                for (int j = 0; j < GrafGrid.ColumnCount; j++)
                {
                    if (skeleton[i, j] && graf[i, j] != -1)
                    {
                        GrafGrid[j, i].Style.BackColor = Color.Red;
                        GrafGrid[i, j].Style.BackColor = Color.Red;
                    }

                }
            }         
        }
    }
}
