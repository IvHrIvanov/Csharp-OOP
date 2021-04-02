using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int capacity = 20;
        private static List<Item> items;
        public Satchel() 
            : base(capacity)
        {
            items = new List<Item>();
        }
    }
}
