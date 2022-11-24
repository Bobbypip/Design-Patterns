using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBuilder
{
    public sealed class Greet
    {
        public string TimeOfDay;
        public string To;

        public string Message => $"Buenas {TimeOfDay} {To}";
    }
}
