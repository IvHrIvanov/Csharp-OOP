using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decoration;
        private ICollection<IAquarium> aquarium;
        public Controller()
        {
            decoration = new DecorationRepository();
            aquarium = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "SaltwaterAquarium")
            {
                aquarium.Add(new SaltwaterAquarium(aquariumName));
            }
            else if (aquariumType == "FreshwaterAquarium")
            {
                aquarium.Add(new FreshwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decoration.Add(new Ornament());
                
            }
            else if (decorationType == "Plant")
            {
                decoration.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {

            Fish fish = null;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            var findAquarium = aquarium.FirstOrDefault(x => x.Name == aquariumName);

            if (fish.GetType().Name == nameof(FreshwaterFish) && findAquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                findAquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else if (fish.GetType().Name == nameof(SaltwaterFish) && findAquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                findAquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return "Water not suitable.";
            }

        }

        public string CalculateValue(string aquariumName)
        {
            var findAquarium = aquarium.FirstOrDefault(x => x.Name == aquariumName);
            decimal value = 0;
            value += findAquarium.Fish.Sum(x => x.Price);
            value += findAquarium.Decorations.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {value:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var findAquarium = aquarium.FirstOrDefault(x => x.Name == aquariumName);
            findAquarium.Feed();
            return $"Fish fed: {findAquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var findDecoration = decoration.FindByType(decorationType);
            if (findDecoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            var findAquarium = aquarium.FirstOrDefault(x => x.Name == aquariumName);
            findAquarium.AddDecoration(findDecoration);
            decoration.Remove(findDecoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in aquarium)
            {
                sb.AppendLine(item.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
