using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    interface ICarBinder
    {
        Car CreateCar(string?[] data);
    }
}
