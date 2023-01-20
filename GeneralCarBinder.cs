﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    internal class GeneralCarBinder : ICarBinder
    {
        public Car CreateCar(string?[] data)
        {
            if (data is { Length: 4 } &&
                data[0] is string brand &&
                data[1] is string model &&
                brand.Length > 0 &&
                model.Length > 0 &&
                int.TryParse(data[2], out var qtty) &&
                int.TryParse(data[3], out var price))
            {
                return new Car(brand, model, qtty, price);
            }
            throw new Exception("Error Car Binder. Incorrect Data");
        }
    }
}