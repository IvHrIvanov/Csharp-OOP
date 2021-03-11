using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double WeightMofidire = 0.40;
        private static HashSet<string> AlowedFoods = new HashSet<string>()
        {
          
            nameof(Meat)
        };
        public Dog(string name, double weight,  string livingRegion) 
            : base(name, weight,  AlowedFoods, WeightMofidire, livingRegion)
        {
        }

        public override string ProoducingSound()
        {
            return "Woof!";
        }
    }
}
