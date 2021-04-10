using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish.Contracts
{
    public class FreshwaterFish : Fish
    {
        private int increases = 3;
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            
        }
        public string FreshwaterAquarium { get; private set; }
        public override void Eat()
        {
            this.Size += increases;
          
        }
    }
}
