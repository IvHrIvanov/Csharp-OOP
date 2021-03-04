using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Pet : Birthdates
    {
        public Pet(string name, string birthdates)
        {
            Name = name;
            Birthdates = birthdates;
            this.Id = Id;
        }

        public string Name { get; private set; }

        public string Birthdates { get; private set; }

        public string Id { get; set; }

    }
}
