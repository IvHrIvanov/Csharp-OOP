using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        // TODO: Implement the rest of the class.
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");

                }
                name = value;
            }
        }

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > BaseHealth)
                {
                    health = value;
                }
                else
                {
                    health = value;
                }
            }
        }
        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else if (value > BaseArmor)
                {
                    armor = value;
                }
                else
                {
                    armor = value;
                }
            }
        }
        public double AbilityPoints { get; protected set; }

        public Bag Bag { get; protected set; }
        public double BaseArmor { get; protected set; }
        public double BaseHealth { get; protected set; }
        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive == true)
            {
                double decrserHitPoints = armor;
                armor -= hitPoints;
                if (armor <= 0)
                {
                    armor = 0;
                }
                hitPoints -= decrserHitPoints;
                if (hitPoints > 0)
                {
                    health -= hitPoints;
                    if (health <= 0)
                    {
                        health = 0;
                        IsAlive = false;
                    }
                }
            }

        }
        public void UseItem(Item item)
        {
            if (IsAlive == true)
            {
                string name = item.Name;
                if (name == "HealthPotion")
                {
                    Health += 20;
                    if (Health > BaseHealth)
                    {
                        Health = BaseHealth;
                    }

                }
                else if (name == "FirePotion")
                {
                    Health -= 20;
                    if (Health <= 0)
                    {
                        Health = 0;
                        IsAlive = false;
                    }
                }
            }
        }
    }
}