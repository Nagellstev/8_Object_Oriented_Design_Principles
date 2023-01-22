using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Commands
{
    internal class AveragePrice : ICommand
    {
        CarStore carStore;
        public AveragePrice(CarStore _carStore)
        {
            carStore = _carStore;
        }
        public void Execute()
        {
            carStore.AveragePrice();
        }
    }
}
