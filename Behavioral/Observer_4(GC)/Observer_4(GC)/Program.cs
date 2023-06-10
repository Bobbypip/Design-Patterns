using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Example
{
    class Program
    {
        public class Button
        {
            public event EventHandler Clicked;

            public void Click()
            {
                Clicked?.Invoke(this, EventArgs.Empty);
            }
        }

        public class Form
        {
            public Form(Button button)
            {
                //button.Clicked += ButtonOnClicked;
                WeakEventManager<Button, EventArgs>
                    .AddHandler(button, "Clicked", ButtonOnClicked);
            }

            private void ButtonOnClicked(object sender, EventArgs e)
            {
                Console.WriteLine("El boton es clickeado");
            }

            ~Form()
            {
                Console.WriteLine("Form finalizo");
            }
        }

        static void Main(string[] args)
        {
            var button = new Button();
            var form = new Form(button);
            var formRef = new WeakReference(form);
            button.Click();
            Console.WriteLine("Cambiar form a null");
            form = null;
            FireGC();
            Console.WriteLine($"El objeto sigue activo {formRef.IsAlive}");

        }

        private static void FireGC()
        {
            Console.WriteLine("Empezar GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("Finalizar GC");
        }


    }
}
