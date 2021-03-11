using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {

        private const double baseWeight = 0.35;
        private static HashSet<string> owlAloowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds),
        };

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, owlAloowedFoods, baseWeight)
        {
        }

        public override string ProoducingSound()
        {
            return "Cluck";
        }
    }
}
