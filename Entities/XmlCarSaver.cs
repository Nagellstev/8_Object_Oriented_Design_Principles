using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarDealer.Entities
{
    internal class XmlCarSaver : ICarSaver
    {
        public void Save(Car car, string fileName)
        {
            XElement Xcar = new XElement("Vehicle",
                new XElement("Brand", car.Brand),
                new XElement("Model", car.Model),
                new XElement("Quantity", car.Quantity),
                new XElement("Price", car.Price)
                );

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true)
                    )
                {
                    writer.WriteLine(Xcar);
                    writer.Close();
                }
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}
