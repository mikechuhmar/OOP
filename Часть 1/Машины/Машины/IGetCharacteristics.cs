using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Машины
{
    //Интерфейс для получения всех характеристик автомобиля
    interface IGetCharacteristics
    {

        string get_name_of_car();
        string get_bodytype();
        short get_number_of_seats();
        short get_number_of_doors();
        decimal get_engine_capacity();
        string get_drive_unit();
        string get_numbers();
        short get_number_of_wheels();
    }
}
