using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double health = 50;
        private const double armor = 25;
        private const double ability = 40;
        private static Backpack backpack = new Backpack();
        public Priest(string name)
            : base(name, health, armor, ability, backpack)
        {
            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = ability;
            Bag = backpack;
        }

        public void Heal(Character character)
        {
            if (character.IsAlive && IsAlive)
            {
                character.Health += AbilityPoints;
            }
        }
    }
}
