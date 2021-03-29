using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double DefaulHealth = 50;
        private const double DefaultArmor = 25;
        private const double DefaultAbility = 40;
        private static Backpack backpack = new Backpack();
        public Priest(string name)
            : base(name, DefaulHealth, DefaultArmor, DefaultAbility, backpack)
        {

        }

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            character.Health += this.AbilityPoints;
            
        }
    }
}
