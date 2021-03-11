using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        private const double WeightMofidire = 0.30;
        private static HashSet<string> AlowedFoods = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Meat),
        };

        public Cat(string name, double weight,  string livingRegion, string breed) 
            : base(name, weight, AlowedFoods, WeightMofidire, livingRegion, breed)
        {
        }

        public override string ProoducingSound()
        {
            return "Meow";
        }
    }
}

