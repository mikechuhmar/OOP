using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Машины
{
    public partial class Form1 : Form
    {
        List<Car> cars = new List<Car>();

        public Form1()
        {
            InitializeComponent();
        }  
            
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDrive.ReadOnly = false;
            setNumbDoors.ReadOnly = false;
            setNumbSeats.ReadOnly = false;
            setNumbWheels.ReadOnly = false;
            setNumbers.ReadOnly = false;
            setNumbWheels.ReadOnly = false;
            setName.Text = "";
            setBody.Text = "";
            setNumbDoors.Text = "";
            setNumbSeats.Text = "";
            setCapacity.Text = "";
            setNumbWheels.Text = "";
            setNumbers.Text = "";
            setDrive.Text = "";

            if (listBox1.SelectedIndex == 0)
            {
                driveBox1.Text = "Задний";
                //driveBox1. = true;
                setNumbDoors.Text = "2";
                setNumbDoors.ReadOnly = true;
                setNumbSeats.Text = "2";
                setNumbSeats.ReadOnly = true;
                setNumbWheels.Text = "4";
                setNumbWheels.ReadOnly = true;
            }
            else
            {
                setNumbers.Text = "Отсутствуют";
                setNumbers.ReadOnly = true;
                setNumbWheels.Text = "4";
                setNumbWheels.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex == 0)
            {
                SportCar avto = new SportCar(setName.Text, setBody.Text, Convert.ToDecimal(setCapacity.Text), setNumbers.Text);
                cars.Add(avto);
                nameBox.Items.Add(avto.get_name_of_car());
                setDrive.ReadOnly = false;
                setNumbDoors.ReadOnly = false;
                setNumbSeats.ReadOnly = false;
                setNumbWheels.ReadOnly = false;
            }
            else
            {
                RacingCar avto = new RacingCar(setName.Text, setBody.Text, /*setDrive.Text*/ driveBox1.SelectedText, Convert.ToDecimal(setCapacity.Text), short.Parse(setNumbDoors.Text), short.Parse(setNumbSeats.Text));
                cars.Add(avto);
                nameBox.Items.Add(avto.get_name_of_car());
                setNumbers.ReadOnly = false;
                setNumbWheels.ReadOnly = false;
            }
            setName.Text = "";
            setBody.Text = "";
            setNumbDoors.Text = "";
            setNumbSeats.Text = "";
            setCapacity.Text = "";
            setNumbWheels.Text = "";
            setNumbers.Text = "";
            setDrive.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getBody.ReadOnly = true;
            getCapacity.ReadOnly = true;
            getDrive.ReadOnly = true;
            getNumbDoors.ReadOnly = true;
            getNumbSeats.ReadOnly = true;
            getNumbWheels.ReadOnly = true;
            getNumbers.ReadOnly = true;
        }

        private void nameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Car avto = cars.Find(x => cars.IndexOf(x) == nameBox.SelectedIndex);
            avto.PrintCharacteristics(getBody, getNumbDoors, getNumbSeats, getCapacity, getNumbWheels, getNumbers, getDrive);
        }       
    }     
}
