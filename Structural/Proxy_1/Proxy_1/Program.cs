using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("El automovil esta siendo conducido");
        }
    }

    public class Driver
    {
        private int _age;
        private bool _hasLicense;

        public Driver(int age, bool hasLicense)
        {
            _age = age;
            _hasLicense = hasLicense;
        }

        internal bool CanDrive() => _age >= 18 && _hasLicense;
    }

    public class CarProxy : ICar
    {
        private Car _car = new Car();
        private Driver _driver;

        public CarProxy(Driver driver)
        {
            _driver = driver;
        }

        public void Drive()
        {
            if (_driver.CanDrive())
                _car.Drive();
            else
                Console.WriteLine("El conductor no puede conducir");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver(17, true));
            car.Drive();
            Console.ReadLine();
        }
    }


}
