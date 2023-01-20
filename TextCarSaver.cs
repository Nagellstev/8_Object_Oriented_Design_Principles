using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    internal class TextCarSaver : ICarSaver
    {
        public void Save(Car car, string fileName)
        {
            using StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(car.Brand);
            writer.WriteLine(car.Model);
            writer.WriteLine(car.Quantity);
            writer.WriteLine(car.Price);
        }
    }
}
