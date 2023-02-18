using CarDealer;
using CarDealer.Commands;
using CarDealer.Entities;
using System.Diagnostics.Metrics;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        // The client code.
        ICarReader reader = new ConsoleCarReader();
        ICarBinder binder = new GeneralCarBinder();
        ICarValidator validator = new GeneralCarValidator();
        //ICarSaver saver = new TextCarSaver();
        ICarSaver saver = new XmlCarSaver();
        CarStore s1 = CarStore.GetInstance(reader, binder, validator, saver);
        CarStore s2 = CarStore.GetInstance(reader, binder, validator, saver);

        if (s1 == s2)
        {
            Console.WriteLine("Singleton works, both variables contain the same instance.\n");
        }
        else
        {
            Console.WriteLine("Singleton failed, variables contain different instances.\n");
        }

        Invoker invoker = new Invoker();
        //reciever is already initialized. It is s1.
        AddCar addCar = new AddCar(s1);
        AveragePrice averagePrice = new AveragePrice(s1);
        AveragePriceType averagePriceType = new AveragePriceType(s1);
        CountAll countAll = new CountAll(s1);
        CountTypes countType = new CountTypes(s1);
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
                    invoker.Run();
                    break;
                case "b":
                    invoker.SetCommand(averagePrice);
                    invoker.Run();
                    break;
                case "c":
                    invoker.SetCommand(averagePriceType);
                    invoker.Run();
                    break;
                case "d":
                    invoker.SetCommand(countAll);
                    invoker.Run();
                    break;
                case "f":
                    invoker.SetCommand(countType);
                    invoker.Run();
                    break;
                case "l":
                    invoker.SetCommand(load);
                    invoker.Run();
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

            Console.WriteLine("\n");
        }
    }
}

