using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    internal class CarStore
    {
        //public List<Car> cars = new List<Car>();
        public List<Car> Cars
        { get; private set; }
        public ICarReader Reader { get; set; }
        public ICarBinder Binder { get; set; }
        public ICarValidator Validator { get; set; }
        public ICarSaver Saver { get; set; }

        private CarStore(ICarReader reader, ICarBinder binder, ICarValidator validator, ICarSaver saver)
        {
            this.Reader = reader;
            this.Binder = binder;
            this.Validator = validator;
            this.Saver = saver;
            this.Cars = new List<Car>();
        }

        private static CarStore _instance;

        public static CarStore GetInstance(ICarReader reader, ICarBinder binder, ICarValidator validator, ICarSaver saver)
        {
            if (_instance == null)
            {
                _instance = new CarStore(reader, binder, validator, saver);
            }
            return _instance;
        }
        

        public void Process()
        {
            string?[] data = Reader.GetInputData();
            Car car = Binder.CreateCar(data);
            if (Validator.IsValid(car))
            {
                Cars.Add(car);
                Saver.Save(car, "CarStore.txt");
                Console.WriteLine("Data sucsessfully processed");
            }
            else
            {
                Console.WriteLine("Incorrect data");
            }
        }
    }
}
