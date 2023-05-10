using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        public class Memento
        {
            public int Balance { get; }
            public Memento(int balance)
            {
                Balance = balance;
            }

        }

        public class Account
        {
            public Account(int balance)
            {
                Balance = balance;
                _operations.Add(new Memento(balance));
            }

            public int Balance { get; set; }
            private List<Memento> _operations = new List<Memento>();
            private int _current;

            public Memento Deposit(int amount)
            {
                Balance += amount;
                var memento = new Memento(Balance);
                _operations.Add(memento);
                ++_current;
                return memento;
            }

            public Memento Undo()
            {
                if (_current > 0)
                {
                    var memento = _operations[--_current];
                    Balance = memento.Balance;
                    return memento;
                }
                return null;
            }

            public Memento Redo()
            {
                if (_current + 1 < _operations.Count)
                {
                    var memento = _operations[++_current];
                    Balance = memento.Balance;
                    return memento;
                }
                return null;
            }

            public void Restore(Memento memento)
            {
                Balance = memento.Balance;
            }

            public override string ToString()
            {
                return $"Balance: {Balance}";
            }

        }

        static void Main(string[] args)
        {
            var account = new Account(100);
            account.Deposit(20); // 120

            account.Deposit(30); // 150

            Console.WriteLine(account);
            account.Undo();
            Console.WriteLine($"Undo 1: {account}");
            account.Undo();
            Console.WriteLine($"Undo 2: {account}");
            account.Redo();
            Console.WriteLine($"Redo 2: {account}");

            Console.ReadLine();
        }
    }
}
