using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double baseHealth = 100;
        private const double baseArmor = 50;
        private const double ability = 40;
        private static Satchel satchel = new Satchel();
        public Warrior(string name)
            : base(name, baseHealth, baseArmor, ability, satchel)
        {
            Name = name;
            Health = baseHealth;
            Armor = baseArmor;
            AbilityPoints = ability;      
            Bag = satchel;
         
        }
       
        public void Attack(Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                if (character.Name == Name)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                else
                {
                    character.TakeDamage(ability);
                }
            }
        }
    }
}
