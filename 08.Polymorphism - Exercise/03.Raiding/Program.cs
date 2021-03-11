using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());
            while (heroes.Count < n)
            {


                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type == nameof(Druid))
                {

                    heroes.Add(new Druid(name));
                }
                else if (type == nameof(Paladin))
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type == nameof(Warrior))
                {
                    heroes.Add(new Warrior(name));
                }
                else if (type == nameof(Rogue))
                {
                    heroes.Add(new Rogue(name));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                   
                }

            }
            int powerBoss = int.Parse(Console.ReadLine());
            int sumPower = 0;
            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
                sumPower += item.Power;
            }
            if(sumPower>=powerBoss)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
