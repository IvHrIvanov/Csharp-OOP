using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int weight = 5;
        private const int decrese = 20;

        public FirePotion()
            : base(weight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            if (character.Health > decrese)
            {
                character.Health -= decrese;
            }
            else
            {
                character.Health = 0;
                character.IsAlive = false;
            }
        }
    }
}
