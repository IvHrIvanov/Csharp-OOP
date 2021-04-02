using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int healtPotionWeight = 5;
        private const int healPotion = 20;

        public HealthPotion()
            : base(healtPotionWeight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += healPotion;
            if (character.Health >= character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
