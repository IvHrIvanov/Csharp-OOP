using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string iD, string firstName, string lastName)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
        }

        public string ID { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {ID}";
        }
    }
}
