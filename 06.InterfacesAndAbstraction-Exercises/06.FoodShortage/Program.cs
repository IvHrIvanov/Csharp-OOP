using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizen = new List<Citizen>();
            List<Rebel> rebel = new List<Rebel>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string name = input[0];
                int age = int.Parse(input[1]);
                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthdate = input[3];
                    citizen.Add(new Citizen(name, age, id, birthdate));

                }
                else if (input.Length == 3)
                {
                    string rebelName = input[2];
                    rebel.Add(new Rebel(name, age, rebelName));
                }

            }
            string names = Console.ReadLine();
            while (names != "End")
            {

                if (rebel.Any(x => x.Name == names))
                {
                    Rebel buy = rebel.FirstOrDefault(x => x.Name == names);
                    buy.BuyFood();
                }
                else if (citizen.Any(x => x.Name == names))
                {
                    Citizen buy = citizen.FirstOrDefault(x => x.Name == names);
                    buy.BuyFood();
                }
                names = Console.ReadLine();
            }
            ;
            int sum = rebel.Sum(x=>x.Food)+citizen.Sum(x=>x.Food);
            Console.WriteLine(sum);
        }
    }
}