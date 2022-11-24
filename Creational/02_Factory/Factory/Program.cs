// See https://aka.ms/new-console-template for more information
using Factory;

Console.WriteLine("Hello, World!");

PizzaStore nyStore = new NYPizzaStore();
Pizza pizza = nyStore.OrderPIzza(TypeOfPizza.Pepperoni);
Console.WriteLine($"Pizza {pizza.Name} lista para ser entregada a Rodrigo");
Console.ReadLine();