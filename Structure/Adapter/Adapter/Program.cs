using Newtonsoft.Json;
using System;
using System.Xml.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public int Price { get; set; }
    }

    public static class ProductDataProvider
    {
        public static List<Product> GetData() =>
            new List<Product>
            {
                new Product("Iphone",  5000),
                new Product("Xiomi Mi 2", 100),
                new Product("Samsung s9", 4000)
            };
    }


    public class XmlConverter
    {
        public XDocument GetXml()
        { 
            var xDocument = new XDocument();
            var xElement = new XElement("Productos");
            var xAttributes = ProductDataProvider.GetData()
                .Select(m => new XElement("Producto", new XAttribute("Nombre", m.Name), new XAttribute("Precio", m.Price)));
            Type type = xAttributes.GetType();
            Console.WriteLine(type);
            xElement.Add(xAttributes);
            xDocument.Add(xElement);
            return xDocument;
        }
    }

    public interface IXmlToJson
    {
        void ConvertXmlToJson();
    }

    public class XmlToJsonAdapter : IXmlToJson
    {
        private XmlConverter _xmlconverter;

        public XmlToJsonAdapter(XmlConverter xmlconverter)
        {
            _xmlconverter = xmlconverter;
        }

        public void ConvertXmlToJson()
        {
            var products = _xmlconverter.GetXml()
                .Element("Productos")
                .Elements("Producto")
                .Select(m => new Product
                {
                    Name = m.Attribute("Nombre").Value,
                    Price = int.Parse(m.Attribute("Precio").Value)
                });

            new JsonConverter(products).ConvertToJson();
        }
    }

    public class JsonConverter
    {
        private IEnumerable<Product> _productData;

        public JsonConverter(IEnumerable<Product> productData)
        {
            _productData = productData;
        }

        public void ConvertToJson()
        {
            var result = JsonConvert.SerializeObject(_productData, Formatting.Indented);
            Console.WriteLine(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var xmlConverter = new XmlConverter();
            var adapter = new XmlToJsonAdapter(xmlConverter);
            adapter.ConvertXmlToJson();
            //Console.WriteLine(new XmlConverter().GetXml());
            Console.ReadLine();
        }
    }


}