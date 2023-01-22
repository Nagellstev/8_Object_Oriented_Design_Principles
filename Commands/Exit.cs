using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Commands
{
    internal class Exit : ICommand
    {
        CarStore carStore;
        public Exit(CarStore _carStore)
        {
            carStore = _carStore;
        }
        public void Execute()
        {
            carStore.Exit();
        }
    }
}
