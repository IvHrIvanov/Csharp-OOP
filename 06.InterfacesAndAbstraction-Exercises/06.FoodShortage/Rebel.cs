using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Rebel : IPerson,IBuyer
    {
        private const int food = 5;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            this.Food = 0;
        }

        public int Food { get; private set; }
        public string Group { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public void BuyFood()
        {
            Food += food;
        }
    }
}
