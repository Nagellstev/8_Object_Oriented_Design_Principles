using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Entities
{
    interface ICarSaver
    {
        void Save(Car car, string fileName);
    }
}
