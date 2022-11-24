using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Sandwich
    {
        public string Bread { get; set; }
        public string Veggies { get; set; }
        public string Protein { get; set; }
        public string Condiments { get; set; }
        public string Chesse { get; set; }

        public Sandwich()
        { }

        public Sandwich( string bread, string veggies, string protein, string condiments, string chesse )
        { 
            Bread = bread;
            Veggies = veggies;
            Protein = protein;
            Condiments = condiments;

        }
    }
}
