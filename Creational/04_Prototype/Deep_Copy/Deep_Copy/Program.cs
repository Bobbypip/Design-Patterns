using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DeepCopy
{
    interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Category : IPrototype<Category>
    {
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public Category DeepCopy()
        {
            return new Category(Name);
        }
    }

    public class Product : IPrototype<Product>
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

        public Product DeepCopy()
        {
            return new Product(Name, Category.DeepCopy());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var notebook1 = new Product("MacBook Pro", new Category("Computers"));
            var cellphone = notebook1.DeepCopy();
            cellphone.Name = "Dell";
            cellphone.Category.Name = "Notebooks";
            WriteLine(notebook1);
            WriteLine(cellphone);
            ReadLine();
        }
    }
}
