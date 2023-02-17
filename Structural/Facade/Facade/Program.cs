using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public class HomeController 
        {
            private WifiController _wifiController = new WifiController();
            private AirConditionerController _airConditionerController = new AirConditionerController();
            private LightController _lightController = new LightController();

            public void TurnOn()
            {
                _wifiController.TurnOn();
                _airConditionerController.TurnOn();
                _lightController.TurnOn();
            }

            public void TurnOff()
            {
                _wifiController?.TurnOff();
                _airConditionerController?.TurnOff();
                _lightController?.TurnOff();
            }
        }
        public class WifiController
        {
            public void TurnOn()
            {
                Console.WriteLine("Wifi is on");
            }

            public void TurnOff()
            {
                Console.WriteLine("Wifi is off");
            }
        }

        public class AirConditionerController
        {
            public void TurnOn()
            {
                Console.WriteLine("Aire acondicionado is on");
            }

            public void TurnOff()
            {
                Console.WriteLine("Aire acondicionado is off");
            }
        }

        public class LightController 
        {
            public void TurnOn()
            {
                Console.WriteLine("Luz is on");
            }

            public void TurnOff()
            {
                Console.WriteLine("Luz is off");
            }
        }
        static void Main(string[] args)
        {
            HomeController homeController = new HomeController();

            Console.WriteLine("LLegando a casa... ");
            homeController.TurnOn();
            Console.WriteLine("Saliendo de casa... ");
            homeController.TurnOff();
            Console.ReadLine();
        }
    }
}