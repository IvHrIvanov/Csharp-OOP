using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double WeightMofidire = 1.00;
        private static HashSet<string> AlowedFoods = new HashSet<string>()
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight,string livingRegion, string breed) 
            : base(name, weight,  AlowedFoods, WeightMofidire, livingRegion, breed)
        {
        }

        public override string ProoducingSound()
        {
            return "ROAR!!!";
        }
    }
}
