using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private static List<Item> items = new List<Item>();

        public Bag(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load { get; } = 0;

        public IReadOnlyCollection<Item> Items => items;

        public void AddItem(Item item)
        {
            int size = item.Weight + Load;
            if (size >= Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item find = items.FirstOrDefault(x => x.Name == name);
            if(items.Count==0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (!items.Contains(find))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            items.Remove(find);
            return find;
        }
    }
}
