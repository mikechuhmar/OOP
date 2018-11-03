using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Машины
{
    public class Car : IGetCharacteristics, IOutCharacteristics
    {
        string name_of_car; //Название
        string bodytype; //Тип кузова
        short number_of_seats; //Число сидений
        short number_of_doors; //Число дверей
        decimal engine_capacity; //Мощность
        string drive_unit;
        string numbers; //Номера
        short number_of_wheels; //Число колёс

        //Задать название автомобиля
        protected void set_name_of_car(string name)
        {
            name_of_car = name;
        }
        //Задать тип кузова автомобиля
        protected void set_bodytype(string body)
        {
            bodytype = body;
        }
        //Задать число мест в автомобиле
        protected void set_number_of_seats(short seats)
        {
            number_of_seats = seats;
        }
        //Задать число дверей в автомобиле
        protected void set_number_of_doors(short doors)
        {
            number_of_doors = doors;
        }
        //Задать мощность двигателя автомобиля
        protected void set_engine_capacity(decimal capacity)
        {
            engine_capacity = capacity;
        }
        protected void set_drive_unit(string drive)
        {
            drive_unit = drive;
        }
        //Задать номера автомобиля
        protected void set_numbers(string number)
        {
            numbers = number;
        }
        //Задать количество колёс автомобиля
        protected void set_number_of_wheels(short _wheels)
        {
            number_of_wheels = _wheels;
        }
        //Все методы для получения характеристик объявлены в интерфейсе IGetCharacteristics
        public string get_name_of_car()
        {
            return name_of_car;
        }
        public string get_bodytype()
        {
            return bodytype;
        }
        public short get_number_of_seats()
        {
            return number_of_seats;
        }
        public short get_number_of_doors()
        {
            return number_of_doors;
        }
        public decimal get_engine_capacity()
        {
            return engine_capacity;
        }
        public string get_drive_unit()
        {
            return drive_unit;
        }
        public string get_numbers()
        {
            return numbers;
        }
        public short get_number_of_wheels()
        {
            return number_of_wheels;
        }
        //Метод для вывода характеристик объявлен в IOutCharacteristics
        public void PrintCharacteristics(TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6, TextBox t7, TextBox t8)
        {

            t2.Text = bodytype;
            t3.Text = Convert.ToString(number_of_doors);
            t4.Text = Convert.ToString(number_of_seats);
            t5.Text = Convert.ToString(engine_capacity);
            t6.Text = Convert.ToString(number_of_wheels);
            t7.Text = numbers;
            t8.Text = drive_unit;
        }
    }
}
