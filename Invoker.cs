using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Commands;

namespace CarDealer
{
    internal class Invoker
    {
        ICommand command;
        public void SetCommand(ICommand c)
        {
                command = c;
        }
        public void Run()
        {
            command.Execute();
        }
    }
}
