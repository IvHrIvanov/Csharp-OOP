using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const double WeightMofidire = 0.10;
        private static HashSet<string> AlowedFoods = new HashSet<string>()
        {
            nameof(Fruit)
        };
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight,  AlowedFoods, WeightMofidire, livingRegion)
        {
        }

        public override string ProoducingSound()
        {
            return "Squeak";
        }
    }
}
