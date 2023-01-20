using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    internal class ConsoleCarReader : ICarReader
    {
        public string?[] GetInputData()
        {
            Console.WriteLine("Input brand:");
            string? brand = Console.ReadLine();
            Console.WriteLine("Input model:");
            string? model = Console.ReadLine();
            Console.WriteLine("Input quantity:");
            string? qtty = Console.ReadLine();
            Console.WriteLine("Input price:");
            string? price = Console.ReadLine();
            return new string?[] { brand, model, qtty, price };
        }
    }
}
