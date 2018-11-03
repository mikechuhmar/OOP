using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Машины
{
    public class SportCar : Car
    {
        public SportCar(string name, string body, decimal capacity, string number)
        {
            set_name_of_car(name);
            set_bodytype(body);
            set_drive_unit("Задний");
            set_engine_capacity(capacity);
            set_numbers(number);
            set_number_of_doors(2);
            set_number_of_seats(2);
            set_number_of_wheels(4);
        }

    }
}
