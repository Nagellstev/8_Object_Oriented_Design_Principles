using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using CarDealer.Entities;
using System.Collections.ObjectModel;
using CarDealer.Commands;

namespace CarDealer
{
    internal class CarStore
    {
        public ICarReader Reader { get; set; }
        public ICarBinder Binder { get; set; }
        public ICarValidator Validator { get; set; }
        public ICarSaver Saver { get; set; }

        public ReadOnlyCollection<Car> Cars
        { get
            {
                return cars.AsReadOnly();
            }
        }
        private List<Car> cars = new List<Car>();
        private CarStore(ICarReader reader, ICarBinder binder, ICarValidator validator, ICarSaver saver)
        {
            this.Reader = reader;
            this.Binder = binder;
            this.Validator = validator;
            this.Saver = saver;
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
        /// <summary>
        /// Public functions doing something
        /// </summary>
        public void LoadFromFile() //1
        {
            Console.WriteLine("Input File Name:");
            string fileName = Console.ReadLine();
            cars = LoadFromFileInternal(fileName);
            Console.WriteLine("Cars loaded.");
        }
        public void AddCar() //2
        {
            string?[] data = Reader.GetInputData();
            Car car = Binder.CreateCar(data);
            if (Validator.IsValid(car))
            {
                cars.Add(car);
                Saver.Save(car, "CarStore.txt");
                Console.WriteLine("Data sucsessfully processed");
            }
            else
            {
                Console.WriteLine("Incorrect data");
            }
        }
        public void CountAll() //3
        {
            Console.WriteLine("Quantity of all cars in the store: " + CountAllInternal(Cars.ToList()));
        }
        public void CountTypes() //4
        {
            Console.WriteLine("Quantity of all car brands in the store: " + CountTypesInternal(Cars.ToList()));
        }
        public void AveragePrice() //5
        {
            Console.WriteLine("Average price of all cars in the store: " + AveragePriceInternal(Cars.ToList()));
        }
        public void AveragePriceType() //6
        {
            Console.WriteLine("Input Car Brand:");
            string brand = Console.ReadLine();
            decimal avPr = AveragePriceInternal(SelectTypes(Cars.ToList(), brand));
            Console.WriteLine("Average price of " + brand + " cars in the store: " + avPr);
        }
        /// <summary>
        /// Private functions
        /// </summary>
        private List<Car> LoadFromFileInternal(string fileName)
        {
            List<Car> cars = new List<Car>();
            foreach (XElement xElement in XElement.Load(fileName).Elements("Vehicle"))
            {
                string brand = xElement.Element("Brand").Value;
                string model = xElement.Element("Model").Value;
                int qtty = Convert.ToInt32(xElement.Element("Quantity").Value);
                int price = Convert.ToInt32(xElement.Element("Price").Value);
                cars.Add(new Car(brand, model, qtty, price));
            }
            return cars;
        }
        private List<Car> SelectTypes(List<Car> cars, string brand)
        {
            var selectedCars = from car in cars
                               where car.Brand == brand
                               select car;
            return selectedCars.ToList();
        }
        private int CountTypesInternal(List<Car> cars)
        {
            List<string> brands = new List<string>();  
            foreach (Car car in cars)
            {
                if (!brands.Contains(car.Brand))
                {
                    brands.Add(car.Brand);
                }
            }
            return brands.Count;
        }
        private decimal AveragePriceInternal(List<Car> cars)
        {
            decimal sumPrice = 0;
            int qtty = 0;
            foreach (Car car in cars) 
            { 
                sumPrice += car.Price * car.Quantity;
                qtty += car.Quantity;
            }
            //return sumPrice / CountAllInternal(cars);
            return qtty <= 0 ? 0 : sumPrice / qtty;
        }
        private int CountAllInternal(List<Car> cars)
        {
            int qtty = 0;
            foreach (Car car in cars)
            {
                qtty += car.Quantity;
            }
            return qtty;
        }
    }
}
