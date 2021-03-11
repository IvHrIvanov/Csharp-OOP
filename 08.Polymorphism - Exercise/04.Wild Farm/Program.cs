using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string[] aniamlParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (aniamlParts[0] != "End")
            {
                Animal createAnimal = CreateAnimal(aniamlParts);
                animals.Add(createAnimal);
                string[] foodParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Food food = CreateFood(foodParts);
                Console.WriteLine(createAnimal.ProoducingSound());
                createAnimal.Eat(food);
                aniamlParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }

        private static Food CreateFood(string[] foodParts)
        {
            string type = foodParts[0];
            int quantity = int.Parse(foodParts[1]);
            Food food = null;
            if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);

            }
            else if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            return food;
        }

        private static Animal CreateAnimal(string[] parts)
        {
            Animal animal = null;
            string type = parts[0];
            string name = parts[1];
            double weight = double.Parse(parts[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = parts[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = parts[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = parts[3];
                string breed = parts[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = parts[3];
                string breed = parts[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            return animal;
        }
    }
}
