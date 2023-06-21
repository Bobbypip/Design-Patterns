using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public abstract class Bread
    {
        public abstract void MixIngredients();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Cortando el pan {GetType().Name}");
        }

        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }

    }

    public class Blanco : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Colocando ingredientes para el pan blanco");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("horneando pan blanc (24 min)");
        }
    }

    public class Integral : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Horneando pan integral (10 min)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Colocando ingredientes pan integral");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Blanco blanco = new Blanco();
            blanco.Make();

            Integral integral = new Integral();
            integral.Make();


        }
    }
}
