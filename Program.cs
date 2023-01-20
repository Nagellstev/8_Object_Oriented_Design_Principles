using CarDealer;
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

        if (s1 == s2)
        {
            Console.WriteLine("Singleton works, both variables contain the same instance.");
        }
        else
        {
            Console.WriteLine("Singleton failed, variables contain different instances.");
        }
    }
}
