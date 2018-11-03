using System;
using System.Windows.Forms;

namespace Rating
{
    public partial class Form1 : Form
    {
        TableConfig t;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(amountConfTextbox.Text != "")
                t.buildTable(int.Parse(amountConfTextbox.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            t.outputCompute();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new TableConfig(table);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t.Example();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                t.outputSorted();
            }
            catch
            {
                MessageBox.Show("Не рассчитаны значения");
            }                
        }
    }
}
