using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    
    class Program
    {
        // Receiver
        public class Product
        {
            public Product(string name, int price)
            {
                Name = name;
                Price = price;
            }

            public string Name { get; set; }
            public int Price { get; set; }

            public void IncreasePrice(int amount)
            {
                Price += amount;
                Console.WriteLine($"El precio de {Name} se incremento por {amount}");
            }

            public bool DecreasePrice(int amount)
            {
                if (amount < Price)
                {
                    Price -= amount;
                    Console.WriteLine($"El precio de {Name} se redujo por {amount}");
                    return true;
                }
                return false;
            }

            public override string ToString() => $"El precio actual de {Name} es {Price}";
        }

        // Command Interface
        public interface ICommand
        {
            void Execute();
            void Undo();
        }
        public enum PriceAction
        {
            Increase,
            Decrease
        }

        // Command
        public class ProductCommand : ICommand
        {
            private Product _product;
            private PriceAction _priceAction;
            private int _amount;

            public bool IsCommandExecuted { get; private set; }
            public ProductCommand(Product product, PriceAction priceAction, int amount)
            {
                _product = product;
                _priceAction = priceAction;
                _amount = amount;
            }

            public void Execute()
            {
                if (_priceAction == PriceAction.Increase)
                {
                    _product.IncreasePrice(_amount);
                    IsCommandExecuted = true;
                }
                else
                {
                    IsCommandExecuted = _product.DecreasePrice(_amount);
                }
            }

            public void Undo()
            {
                if (!IsCommandExecuted)
                    return;

                if (_priceAction == PriceAction.Increase)
                {
                    _product.DecreasePrice(_amount);
                }
                else
                {
                    _product.IncreasePrice(_amount);
                }
            }
        }

        // Invoker
        public class ModifyPrice
        {
            private List<ICommand> _commands;
            private ICommand _command;

            public ModifyPrice()
            {
                _commands = new List<ICommand>();
            }

            public void SetCommand(ICommand command) => _command = command;

            public void Invoke()
            {
                _commands.Add(_command);
                _command.Execute();
            }

            public void Undo()
            {
                foreach (var command in Enumerable.Reverse(_commands))
                {
                    command.Undo();
                }
            }

        }

        static void Main(string[] args)
        {
            // Client
            var modifyPrice = new ModifyPrice();
            var product = new Product("IPhone", 5000);

            var productCommand = new ProductCommand(product, PriceAction.Increase, 100);

            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();

            var productCommand1 = new ProductCommand(product, PriceAction.Decrease, 30000);

            modifyPrice.SetCommand(productCommand1);
            modifyPrice.Invoke();

            Console.WriteLine(product);

            modifyPrice.Undo();
            Console.WriteLine(product);
            Console.ReadLine();
        }
    }
}
