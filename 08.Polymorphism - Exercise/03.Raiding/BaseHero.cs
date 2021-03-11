using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(int power, string name)
        {
            Power = power;
            Name = name;
        }

        public int Power { get; private set; }
        public string Name { get; private set; }
        public abstract string CastAbility();

    }
}