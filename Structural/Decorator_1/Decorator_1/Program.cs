using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    public interface ICoffe
    {
        string GetDescription();

        double GetCost();
    }

    public abstract class CondimentDecorator : ICoffe
    {
        ICoffe _coffe;
        protected double _price = 0.0;
        protected string _name = "";
        protected CondimentDecorator(ICoffe coffe)
        {
            _coffe = coffe;
        }

        public double GetCost()
        {
            return _coffe.GetCost() + _price;
        }

        public string GetDescription()
        {
            return $"{_coffe.GetDescription()} {_name}";
        }
    }

    public class MilkDecorator : CondimentDecorator
    {
        public MilkDecorator(ICoffe coffe) : base(coffe)
        {
            _name = "Leche";
            _price = 0.25;
        }
    }

    public class ChocolateDecorator : CondimentDecorator
    {
        public ChocolateDecorator(ICoffe coffe) : base(coffe)
        {
            _name = "Chocolate";
            _price = 0.45;
        }
    }

    public class Filtered : ICoffe
    {
        public string GetDescription()
        {
            return "Filtrado simple";
        }

        public double GetCost()
        {
            return 5.65;
        }
    }

    public class Espresso : ICoffe
    {
        public string GetDescription()
        {
            return "Espresso simple";
        }

        public double GetCost()
        {
            return 3.25;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var espressoWithMilkAndChocolate = new MilkDecorator(new ChocolateDecorator(new Espresso()));
            Console.WriteLine($"El precio de {espressoWithMilkAndChocolate.GetDescription()} {espressoWithMilkAndChocolate.GetCost().ToString("N2")}");
            Console.ReadLine();
        }
    }
}
