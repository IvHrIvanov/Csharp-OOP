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
        private const string firePotion = "FirePotion";
        public FirePotion()
            : base(weight, firePotion)
        {
            
        }
  
        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            
            character.Health -= decrese;
            if(character.Health<=0)
            {
                character.IsAlive = false;
            }
        }
    }
}
