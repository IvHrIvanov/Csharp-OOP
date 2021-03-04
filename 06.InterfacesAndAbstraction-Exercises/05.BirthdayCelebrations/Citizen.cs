using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, Birthdates
    {
        public Citizen(string name, int age, string id, string birthdates)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdates = birthdates;

        }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Id { get; private set; }
        public string Birthdates { get; private set; }



    }
}