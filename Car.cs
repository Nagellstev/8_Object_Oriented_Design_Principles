﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    internal class Car
    {
        public string Brand { get; }
        public string Model { get; }
        public int Quantity { get; }
        public int Price { get; }
        public Car(string brand, string model, int qtty, int price)
        {
            Brand = brand;
            Model = model;
            Quantity = qtty;
            Price = price;
        }
    }
}
