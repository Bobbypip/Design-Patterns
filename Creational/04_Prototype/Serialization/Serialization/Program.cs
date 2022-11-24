using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Serialization
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;

        }
    }

    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public Category Category { get; set; }

        public Product(string name, Category category)
        {
            Name = name;
            Category = category;
        }

        public override string ToString()
        {
            return $"Producto: {Name}, Categoría: {Category.Name}";
        }

    }

    [Serializable]
    public class Category
    {
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var notebook1 = new Product("MacBook Pro", new Category("Computers"));

            var dell = notebook1.DeepCopy();
            dell.Category.Name = "Notebooks";
            dell.Name = "Dell";
            WriteLine(notebook1);
            WriteLine(dell);
            ReadLine();
        }
    }
}
