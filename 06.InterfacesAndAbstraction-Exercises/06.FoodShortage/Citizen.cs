using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthdates, IIdentifiable,IBuyer
    {
        private const int food = 10;
        public Citizen(string name, int age, string id, string birthdates)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdates = birthdates;
            this.Food = 0;

        }
        public int Food { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Id { get; private set; }
        public string Birthdates { get; private set; }

        public void BuyFood()
        {
            Food += food;
        }
    }
}