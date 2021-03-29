using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private static List<Character> characters = new List<Character>();
        private static Stack<Item> potions = new Stack<Item>();
        private static Dictionary<Character, List<Item>> heroes = new Dictionary<Character, List<Item>>();
        public WarController()
        {
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];


            if (characterType == nameof(Warrior))
            {
                Warrior war = new Warrior(name);
                characters.Add(war);

            }
            else if (characterType == nameof(Priest))
            {
                Priest priest = new Priest(name);
                characters.Add(priest);


            }
            if (!heroes.Any(x => x.Key.Name == name))
            {
                Character currentCharacter = characters.FirstOrDefault(x => x.Name == name);
                heroes.Add(currentCharacter, new List<Item>());
                return $"{name} joined the party!";
            }
            return $"Invalid character type \"{characterType}\"!";

        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            if (nameof(HealthPotion) == itemName)
            {
                HealthPotion healt = new HealthPotion();

                potions.Push(healt);

                return $"{itemName} added to pool.";
            }
            else if (nameof(FirePotion) == itemName)
            {
                FirePotion fire = new FirePotion();
                potions.Push(fire);
                return $"{itemName} added to pool.";
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (!characters.Any(x => x.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (potions.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            Item lastItem = potions.Pop();
            Character currentChar = characters.FirstOrDefault(x => x.Name == characterName);
            if (!heroes.ContainsKey(currentChar))
            {
                heroes.Add(currentChar, new List<Item>());
            }

            currentChar.Bag.AddItem(lastItem);  
            heroes[currentChar].Remove(lastItem);

            return $"{characterName} picked up {lastItem.GetType().Name}!";

        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            if (!heroes.Any(x => x.Key.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            Character current = heroes.Keys.FirstOrDefault(x => x.Name == characterName);

            Item potion = current.Bag.GetItem(itemName);
            current.UseItem(potion);
            
            return $"{current.Name} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Character hero in heroes.Keys.OrderBy(x => x.IsAlive).OrderByDescending(x => x.Health))
            {
                string status = string.Empty;
                if (hero.IsAlive)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }
                sb.AppendLine($"{hero.Name} - HP: {hero.Health}/{hero.BaseHealth}, AP: {hero.Armor}/{hero.BaseArmor}, Status: {status}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            if (!heroes.Any(x => x.Key.Name == attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            else if (!heroes.Any(x => x.Key.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            ;
            Character attacker = heroes.Keys.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = heroes.Keys.FirstOrDefault(x => x.Name == receiverName);
            if (!attacker.IsAlive)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
            if (!receiver.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            if(attacker==null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attacker));

            }
            if (!receiver.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            if (receiver.Name == attacker.Name)
            {
                throw new InvalidCastException("Cannot attack self!");
            }
            StringBuilder sb = new StringBuilder();
            receiver.TakeDamage(attacker.AbilityPoints);
            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            if (!heroes.Any(x => x.Key.Name == healerName))
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            else if (!heroes.Any(x => x.Key.Name == healingReceiverName))
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }
            Priest healer = (Priest)heroes.Keys.FirstOrDefault(x => x.Name == healerName);
            Character receiver = heroes.Keys.FirstOrDefault(x => x.Name == healingReceiverName);
            if (!healer.IsAlive || !receiver.IsAlive)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            if(healer==null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));

            }
            if (receiver==null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));

            }
            healer.Heal(receiver);
            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
