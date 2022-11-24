using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public abstract class Pizza
    {
        public string Name { get; set; }
        protected string Dough;
        protected string Sauce;
        protected List<string> Toppings = new List<string>();

        public void Prepare()
        {
            Console.WriteLine($"Preparando: {Name}");
            Console.WriteLine($"Colocando Masa: {Dough}");
            Console.WriteLine($"Agregando salsa: {Sauce}");
            Console.WriteLine($"Agregando Capas: {string.Join(",", Toppings)}");
        }

        public void Bake() => Console.WriteLine("Cocinar por 20 min");
        public void Cut() => Console.WriteLine("Pizza fue cortada en partes iguales");
        public void Box() => Console.WriteLine("Pizza colocada en caja oficial");
    }

    public abstract class PizzaStore
    {
        public abstract Pizza CreatePizza(TypeOfPizza type);
        public Pizza OrderPIzza(TypeOfPizza type)
        {
            Pizza pizza = CreatePizza(type);
            
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            
            return pizza;
        }
    }

    public enum TypeOfPizza
    {
        Pepperoni,
        Neapolitan,
        California
    }

    public class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(TypeOfPizza type)
        {
            return (Pizza)Activator.
                CreateInstance(Type.GetType($"Factory.NY{Enum.GetName(typeof(TypeOfPizza), type)}Pizza"));
        }
    }

    public class FLPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(TypeOfPizza type)
        {
            return (Pizza)Activator.
                  CreateInstance(Type.GetType($"Factory.FL{Enum.GetName(typeof(TypeOfPizza), type)}Pizza"));
        }
    }

    #region NY
    internal class NYPepperoniPizza : Pizza
    {
        public NYPepperoniPizza()
        {
            Name = "Pepperoni";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Queso mozarella");
        }
    }

    internal class NYCaliforniaPizza : Pizza
    {
        public NYCaliforniaPizza()
        {
            Name = "California";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Queso mozarella");
        }
    }

    internal class NYNeapolitanPizza : Pizza
    {
        public NYNeapolitanPizza()
        {
            Name = "Napolitana";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Queso mozarella");
        }
    }
    #endregion

    #region FL
    internal class FLPepperoniPizza : Pizza
    {
        public FLPepperoniPizza()
        {
            Name = "Pepperoni";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Queso mozarella");
        }
    }

    internal class FLCaliforniaPizza : Pizza
    {
        public FLCaliforniaPizza()
        {
            Name = "California";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Queso mozarella");
        }
    }

    internal class FLNeapolitanPizza : Pizza
    {
        public FLNeapolitanPizza()
        {
            Name = "Napolitana";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Queso mozarella");
        }
    }
    #endregion
}
