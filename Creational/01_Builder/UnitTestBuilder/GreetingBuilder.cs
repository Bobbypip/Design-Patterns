using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBuilder
{
    public class GreetingBuilder
    {
        private readonly Greet _greeting;

        public GreetingBuilder()
        {
            _greeting = new Greet();
        }

        public static GreetingBuilder CreateNew()
        {
            return new GreetingBuilder();
        }

        public GreetingBuilder TimeOfDay(string tiomeOfDay)
        {
            _greeting.TimeOfDay = tiomeOfDay;
            return this;
        }

        public GreetingBuilder To(string to)
        {
            _greeting.To = to;
            return this;
        }

        public Greet Build()
        {
            return _greeting;
        }

    }
}
