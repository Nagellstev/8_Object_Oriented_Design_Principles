using CarDealer;
using CarDealer.Commands;
using CarDealer.Entities;
using System.Diagnostics.Metrics;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        // The client code.
        ICarReader reader = new ConsoleCarReader();
        ICarBinder binder = new GeneralCarBinder();
        ICarValidator validator = new GeneralCarValidator();
        ICarSaver saver = new TextCarSaver();
        CarStore s1 = CarStore.GetInstance(reader, binder, validator, saver);
        CarStore s2 = CarStore.GetInstance(reader, binder, validator, saver);
        //Car car = new Car("Opel", "Zafira", 1, 5000);

        if (s1 == s2)
        {
            Console.WriteLine("Singleton works, both variables contain the same instance.");
        }
        else
        {
            Console.WriteLine("Singleton failed, variables contain different instances.");
        }
        //s1.AddCar();
        //Console.WriteLine(s1.Cars[0].Model);

        Invoker invoker = new Invoker();
        //reciever is already initialized. It is s1.
        AddCar addCar = new AddCar(s1);
        AveragePrice avPr = new AveragePrice(s1);
        AveragePriceType avPrTy = new AveragePriceType(s1);
        CountAll coAll = new CountAll(s1);
        CountTypes coTy = new CountTypes(s1);
        LoadFromFile load = new LoadFromFile(s1);
        //Setting of concrete command will be in swith statement according to chosen item of list of commands
        //invoker.SetCommand(addCar);
        bool endApp = false;

        Console.WriteLine("Practical Task: Object Oriented Design Principles\r");
        Console.WriteLine("Car Store Processing\r");
        Console.WriteLine("-----------\n");
        while (endApp != true)
        {
            Console.WriteLine("Choose action:");
            Console.WriteLine("\ta - add new car");
            Console.WriteLine("\tb - calculate average price of all cars");
            Console.WriteLine("\tc - calculate average price of all cars of selected brand");
            Console.WriteLine("\td - count all cars");
            Console.WriteLine("\te - exit");
            Console.WriteLine("\tf - count all brands");
            Console.WriteLine("\tl - load cars from XML file");
            switch (Console.ReadLine())
            {
                case "a":
                    invoker.SetCommand(addCar);
                    break;
                case "b":
                    invoker.SetCommand(avPr);
                    break;
                case "c":
                    invoker.SetCommand(avPrTy);
                    break;
                case "d":
                    invoker.SetCommand(coAll);
                    break;
                case "f":
                    invoker.SetCommand(coTy);
                    break;
                case "l":
                    invoker.SetCommand(load);
                    break;
                case "e":
                    Console.WriteLine("Exit? y/n");
                    if (Console.ReadLine() == "y")
                    {
                        endApp = true;
                    }
                    break;
                default:
                    Console.WriteLine("You have not chosen anything.");
                    break;
            }
            invoker.Run();
            Console.WriteLine("\n");
        }
    }
}

