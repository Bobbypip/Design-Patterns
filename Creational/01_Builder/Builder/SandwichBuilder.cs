using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class SandwichBuilder
    {
        protected Sandwich _sandwich;

        public Sandwich Sandwich
        {
            get { return _sandwich; }
        }

        public SandwichBuilder WithMeat()
        {
            _sandwich.Protein = "Carne";
            
            return this;
        }

        public SandwichBuilder WhithChesee()
        {
            _sandwich.Chesse = "Queso Chedar";

            return this;
        }

        public SandwichBuilder WithCondiments()
        {
            _sandwich.Chesse = " Mayonesa, mostaza";

            return this;
        }
    }
}
