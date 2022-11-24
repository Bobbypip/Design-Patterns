using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public interface ISingletonContainer
    {
        int GetPopulation(string name);
    }

    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Nueva Instancia SingletonContainer");
            var elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        private static Lazy<SingletonDataContainer> instance = new Lazy<SingletonDataContainer>(() => new SingletonDataContainer());
        public static SingletonDataContainer Instance => instance.Value;

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }

    public class SingletonFinder 
    {
        private readonly ISingletonContainer _datacontainer;

        public SingletonFinder(ISingletonContainer dataContainer)
        {
            _datacontainer = dataContainer;
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int total = 0;
            foreach (var name in names)
            {
                total += _datacontainer.GetPopulation(name);
            }

            return total;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var capitals = SingletonDataContainer.Instance;
            var capitals1 = SingletonDataContainer.Instance;
            var capitals2 = SingletonDataContainer.Instance;
            Console.WriteLine($"Los habitantes de Londres: {capitals.GetPopulation("London")}");
            Console.ReadLine();
        }
    }
}