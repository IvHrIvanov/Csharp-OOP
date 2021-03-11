using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
   public abstract class Animal
    {
        protected Animal(string name, double weight,  HashSet<string> allowedFood,double weightModifire)
        {
            Name = name;
            Weight = weight;
          
            AllowedFood = allowedFood;
            WeightModifire = weightModifire;
        }
        private double WeightModifire { get; set; }
        private HashSet<string> AllowedFood { get; set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public override string ToString()
        {
            return base.ToString();
        }
        public abstract string ProoducingSound();
        
        public void Eat(Food food)
        {
            string foodType = food.GetType().Name;
            if(!AllowedFood.Contains(foodType))
            {
                Console.WriteLine($"{GetType().Name} does not eat {foodType}!");
            }
            else
            {
                FoodEaten += food.Quantity;
                Weight += WeightModifire * food.Quantity;
            }

        }
    }
}
