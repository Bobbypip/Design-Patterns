using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class Menu
    {
        public Menu(string name, string description, double price, bool isVegatarian)
        {
            Name = name;
            Description = description;
            Price = price;
            IsVegatarian = isVegatarian;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public bool IsVegatarian { get; private set; }
    }

    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    public class DinnerMenuIterator : IIterator<Menu>
    {
        Menu[] items;
        int position = 0;

        public DinnerMenuIterator(Menu[] items)
        {
            this.items = items;
        }

        public bool HasNext()
        {
            if (position >= items.Length || items[position] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Menu Next()
        {
            Menu menu = items[position];
            position = position + 1;
            return menu;
        }
    }


    public class BreakfastMenuIterator : IIterator<Menu>
    {
        List<Menu> items;
        int position = 0;

        public BreakfastMenuIterator(List<Menu> items)
        {
            this.items = items;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool HasNext()
        {
            if (position >= items.Count || items[position] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Menu Next()
        {
            Menu menu = items[position];
            position = position + 1;
            return menu;
        }

    }


    public class BreakfastMenuCollection
    {
        private List<Menu> _menuItems;

        public BreakfastMenuCollection()
        {
            _menuItems = new List<Menu>();
            AddItem("Desyuno simple dulce", "Panqueques con manjar + cafe o te", 200, false);
            AddItem("Desyuno Sandwich", "Sandwich Jamon queso + cafe o te", 120, false);
            AddItem("Desyuno vegetariano", "Sandwich Lechuga y atun + jugo", 200, true);

        }

        public void AddItem(string name, string description, double price, bool isVegatarian)
        {
            Menu menuItem = new Menu(name, description, price, isVegatarian);
            _menuItems.Add(menuItem);
        }

        public IIterator<Menu> CreateIterator() => new BreakfastMenuIterator(_menuItems);
    }

    public class DinnerMenuCollection
    {
        private Menu[] _menuItems;
        private int _maxItems = 4;
        private int _numberOfItems;

        public DinnerMenuCollection()
        {
            _menuItems = new Menu[_maxItems];

            AddItem("Vegatiariano simple", "Hipocalorico + Jugo", 500, true);
            AddItem("Caribean Sushi", "10 hot rolls, 15 kanikama", 800, false);
            AddItem("Pizza familiar", "Pizza 3 ingredientes a elección", 800, false);

        }

        public void AddItem(string name, string description, double price, bool isVegatarian)
        {
            Menu menuItem = new Menu(name, description, price, isVegatarian);

            if (_numberOfItems > _maxItems)
            {
                Console.WriteLine("El menu está full");
            }
            else
            {
                _menuItems[_numberOfItems] = menuItem;
                _numberOfItems++;
            }
        }

        //public Menu[] GetMenuItems() => _menuItems;
        public IIterator<Menu> CreateIterator() => new DinnerMenuIterator(_menuItems);

    }

    class Program
    {

        static void Main(string[] args)
        {
            var breakFastMenu = new BreakfastMenuCollection();
            var dinnerMenu = new DinnerMenuCollection();
            IIterator<Menu> breakfastMenuIterator = breakFastMenu.CreateIterator();
            IIterator<Menu> dinnerMenuIterator = dinnerMenu.CreateIterator();

            Iterate(breakfastMenuIterator);
            Iterate(dinnerMenuIterator);

            Console.ReadLine();

        }

        private static void Iterate(IIterator<Menu> iterator)
        {
            while (iterator.HasNext())
            {
                Menu menu = iterator.Next();
                Console.WriteLine(menu.Name);
                Console.WriteLine(menu.Description);
                Console.WriteLine(menu.Price);
            }
        }
    }
}
