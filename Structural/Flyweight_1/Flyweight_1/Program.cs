using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public interface IPlayer
    {
        void AssingWeapon(string weapon);
        void Mission();
    }

    public class Terrorist : IPlayer
    {
        private string _task;
        private string _weapon;

        public Terrorist()
        {
            _task = "Colocar bomba";
        }

        public void AssingWeapon(string weapon)
        {
            _weapon = weapon;
        }

        public void Mission()
        {
            Console.WriteLine($"El terrorista con el arma {_weapon} tiene la tarea de {_task}");
        }
    }


    public class CounterTerrorist : IPlayer
    {
        private string _task;
        private string _weapon;

        public CounterTerrorist()
        {
            _task = "Desarmar bomba";
        }

        public void AssingWeapon(string weapon)
        {
            _weapon = weapon;
        }

        public void Mission()
        {
            Console.WriteLine($"El contra terrorista con el arma {_weapon} tiene la tarea de {_task}");
        }
    }

    public class Factory
    {
        Dictionary<string, IPlayer> _players = new Dictionary<string, IPlayer>();

        public int GetNumberOfInstance()
        {
            return _players.Count();
        }

        public IPlayer GetPlayer(string key)
        {
            IPlayer player = null;
            if (_players.ContainsKey(key))
            {
                player = _players[key];
            }
            else
            {
                switch (key)
                {
                    case "Terrorist":
                        player = new Terrorist();
                        break;
                    case "CounterTerrorist":
                        player = new CounterTerrorist();
                        break;
                }

                _players.Add(key, player);

            }

            return player;
        }

    }


    class Program
    {
        private static string[] playerType = { "Terrorist", "CounterTerrorist" };
        private static string[] weapons = { "Ak47", "Gut Knife", "M16", "Granade" };

        public static string GetPlayerRandom()
        {
            Random r = new Random();

            int rad = r.Next(playerType.Length);
            return playerType[rad];
        }

        public static string GetWeaponRandom()
        {
            Random r = new Random();

            int rad = r.Next(weapons.Length);
            return weapons[rad];
        }

        static void Main(string[] args)
        {
            var factory = new Factory();
            for (int i = 0; i < 10; i++)
            {
                IPlayer p = factory.GetPlayer(GetPlayerRandom());
                p.AssingWeapon(GetWeaponRandom());
                p.Mission();
            }

            Console.WriteLine(factory.GetNumberOfInstance());


            Console.ReadLine();
        }

    }
}
