using AquaShop.Models.Aquariums.Contracts;

using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;

        private readonly ICollection<IFish> fish;
        private readonly ICollection<IDecoration> decorations;
        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            fish = new List<IFish>();
            decorations = new List<IDecoration>();

        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                capacity = value;
            }
        }


        public int Comfort => decorations.Sum(x => x.Comfort);


        public ICollection<IDecoration> Decorations => decorations.ToList().AsReadOnly();

        public ICollection<IFish> Fish => fish.ToList().AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            // check
            if (Capacity <= this.fish.Count)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {

            foreach (var feedAllFish in fish)
            {
                feedAllFish.Eat();
            }
        }

        public string GetInfo()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{name} ({GetType().Name}):");
            if (fish.Count <= 0)
            {
                sb.AppendLine("Fish: none");

            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", fish.Select(x => x.Name))}");

            }

            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
