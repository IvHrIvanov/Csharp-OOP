using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight,double wingSize, HashSet<string> allowedFood, double weightModifire) 
            : base(name, weight, allowedFood, weightModifire)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }
        public override string ToString()
        {
            //"{AnimalType} [{AnimalName}, {WingSize}, {AnimalWeight}, {FoodEaten}]"
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
