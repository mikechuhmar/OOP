using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Парсер
{
    public partial class Form1 : Form
    {
        //Масивы текстовых полей для ввода координат и названий
        TextBox[] t = new TextBox[10];
        Label[] l = new Label[10];
        //Введённая функция
        IntroducedFunction func;

        public Form1()
        {
            InitializeComponent();
        }

        //Событие загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            //Скрыть текстовые поля и названия координат
            t[0] = x1_TextBox;
            t[1] = x2_TextBox;
            t[2] = x3_TextBox;
            t[3] = x4_TextBox;
            t[4] = x5_TextBox;
            t[5] = x6_TextBox;
            t[6] = x7_TextBox;
            t[7] = x8_TextBox;
            t[8] = x9_TextBox;
            t[9] = x10_TextBox;
            foreach (TextBox te in t)
                te.Hide();

            l[0] = x1_Label;
            l[1] = x2_Label;
            l[2] = x3_Label;
            l[3] = x4_Label;
            l[4] = x5_Label;
            l[5] = x6_Label;
            l[6] = x7_Label;
            l[7] = x8_Label;
            l[8] = x9_Label;
            l[9] = x10_Label;
            foreach (Label la in l)
                la.Hide();
            //Скрытие полей для ввода
            answerLabel.Hide();
            answerButton.Hide();
            answerTextBox.Hide();
            minButton.Hide();
            minLabel.Hide();
            minTextBox.Hide();
        }

        private void enterFuncButton_Click(object sender, EventArgs e)
        {
            //Показать все текстовые поля для ввода координат и их названия при нажатии на кнопку Ввести функцию
            
            answerLabel.Show();
            answerButton.Show();
            answerTextBox.Show();
            minButton.Show();
            minLabel.Show();
            minTextBox.Show();
            func = new IntroducedFunction(funcTextBox.Text);
            if (func.IsRightFunction())
            {

                func.CountVariables();
                func.Postfix();
                for (int i = 0; i < func.Variables; i++)
                {
                    t[i].Show();
                    l[i].Show();
                }
            }
            else
            {
                MessageBox.Show("Неправильная функция");
            }
        }

        private void answerButton_Click(object sender, EventArgs e)
        {
            try
            {
                double[] coordinates = new double[func.Variables];
                for (int i = 0; i < func.Variables; i++)
                {
                    coordinates[i] = Convert.ToDouble(t[i].Text);
                }
                Coord x0 = new Coord(coordinates);
                answerTextBox.Text = func.Answer(x0).ToString();
            }
            catch
            {
                bool c = true;
                foreach (TextBox te in t)
                    if (te.Text == "" && te.Visible == true)
                        c = false;
                if(!c)
                    MessageBox.Show("Не все координаты введены");
                else
                    MessageBox.Show("Ошибка");
            }
        }

        private void funcTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                case '(':
                case ')':
                case '-':
                case '+':
                case '*':
                case '/':
                case '^':
                case ',':
                case 'e':
                case 'x':
                case 'p':
                case 's':
                case 'i':
                case 'n':
                case 'c':
                case 'o':
                case 'l':
                case (char)Keys.Back:
                case (char)Keys.Delete:
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            foreach (TextBox te in t)
                te.Hide();
            try
            {
                double[] coordinates = new double[func.Variables];
                for (int i = 0; i < func.Variables; i++)
                {
                    coordinates[i] = Convert.ToDouble(t[i].Text);
                }
                Coord x0 = new Coord(coordinates);
                UnconditionalOptimisation opt = new UnconditionalOptimisation(func, x0);
                opt.HookeJeeves();
                opt.Min.output(minTextBox, func.Variables);
                
            }
            catch
            {
                bool c = true;
                foreach (TextBox te in t)
                    if (te.Text == "" && te.Visible == true)
                        c = false;
                if (!c)
                    MessageBox.Show("Не все координаты введены");
                else
                    MessageBox.Show("Ошибка");
            }
        }
    }
}
