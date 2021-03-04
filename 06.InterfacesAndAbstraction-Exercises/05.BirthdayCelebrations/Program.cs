using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Birthdates> identifiables = new List<Birthdates>();
            List<IIdentifiable> robots = new List<IIdentifiable>();
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                string currentPerson = input[0];
                if (currentPerson == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string bitrhdate = input[4];
                    identifiables.Add(new Citizen(name, age, id, bitrhdate));

                }
                else if (currentPerson == "Robot")
                {
                    string model = input[0];
                    string id = input[1];
                    robots.Add(new Robot(id, model));
                }
                else if (currentPerson == "Pet")
                {
                    string birthdates = input[2];

                    identifiables.Add(new Pet(currentPerson, birthdates));
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string findYear = Console.ReadLine();

            List<Birthdates> filtered = identifiables.Where(x => x.Birthdates.EndsWith(findYear)).ToList();
           
                foreach (var item in filtered)
                {
                    Console.WriteLine(item.Birthdates);
                }
            
        }
    }
}