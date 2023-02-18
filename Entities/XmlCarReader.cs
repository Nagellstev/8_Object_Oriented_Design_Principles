using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarDealer.Entities
{
    internal class XmlCarReader : ICarReader
    {
        public string?[] GetInputData()
        {
            //XElement.Load(fileName).Elements("Vehicle")
            //string brand = xElement.Element("Brand").Value;
            //string model = xElement.Element("Model").Value;
            //int qtty = Convert.ToInt32(xElement.Element("Quantity").Value);
            //int price = Convert.ToInt32(xElement.Element("Price").Value);
            //return new string?[] { brand, model, qtty, price };
            return new string?[] { "", "", "", "" };
        }
    }
}
