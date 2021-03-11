using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight,  HashSet<string> allowedFood, double weightModifire, string livingRegion,string breed) 
            : base(name, weight,  allowedFood, weightModifire, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, { Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
