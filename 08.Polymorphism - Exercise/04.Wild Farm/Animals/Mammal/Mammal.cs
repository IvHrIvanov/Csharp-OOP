using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, HashSet<string> allowedFood, double weightModifire,string livingRegion)
            : base(name, weight,  allowedFood, weightModifire)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
        public override string ToString()
        {
            //"{AnimalType} [{AnimalName}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
