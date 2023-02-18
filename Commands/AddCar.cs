using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Commands
{
    internal class AddCar : ICommand
    {
        CarStore carStore;

        public AddCar(CarStore _carStore)
        {
            carStore = _carStore;
        }

        public void Execute()
        {
            carStore.AddCar();
        }
    }
}
