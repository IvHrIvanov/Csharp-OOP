using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int capacity = 100;
        private static List<Item> items;
       
        public Backpack() 
            : base(capacity)
        {
            items = new List<Item>();
        }
    }
}
