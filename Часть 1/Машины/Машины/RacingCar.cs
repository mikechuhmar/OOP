using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Машины
{
    public class RacingCar : Car
    {
        public RacingCar(string name, string body, string drive, decimal capacity, short doors, short seats)
        {
            set_name_of_car(name);
            set_bodytype(body);
            set_drive_unit(drive);
            set_engine_capacity(capacity);
            set_numbers("Отсутствуют");
            set_number_of_doors(doors);
            set_number_of_seats(seats);
            set_number_of_wheels(4);
        }
    }
}
