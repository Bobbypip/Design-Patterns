using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Category : ICloneable
    {
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public object Clone()
        {
            return new Category(Name);
        }
    }
    public class Product : ICloneable
    {
        public Product(string name, Category category) 
        {
            Name = name;
            Category = category;
        }

        public override string ToString()
        {
            return $"Producto {Name}, Categoria: {Category.Name}";
        }

        public object Clone()
        {
            return new Product(Name, (Category)Category.Clone());
        }

        public string Name { get; set; }
        public Category Category { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var notebook1 = new Product("MacBook Pro", new Category("Computers"));
            var iphone = (Product)notebook1.Clone();
            iphone.Name = "Iphone";
            iphone.Category.Name = "CellPhones";
            Console.WriteLine(notebook1);
            Console.WriteLine(iphone);
            Console.ReadLine();
        }
    }
}