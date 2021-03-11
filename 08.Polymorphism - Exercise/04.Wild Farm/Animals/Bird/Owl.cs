using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double baseWeight = 0.25;
        private static HashSet<string> owlAloowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, owlAloowedFoods, baseWeight)
        {
        }

        public override string ProoducingSound()
        {
            return "Hoot Hoot";
        }
    }
}
