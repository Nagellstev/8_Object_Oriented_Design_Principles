using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    internal class GeneralCarValidator : ICarValidator
    {
        public bool IsValid(Car car) =>
            !string.IsNullOrEmpty(car.Brand) &&
            !string.IsNullOrEmpty(car.Model) &&
            car.Quantity > 0 &&
            car.Price > 0;
    }
}
