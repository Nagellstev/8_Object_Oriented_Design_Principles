using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    interface ICarValidator
    {
        bool IsValid(Car car);
    }
}
