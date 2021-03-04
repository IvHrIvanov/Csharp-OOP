using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {

                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    identifiables.Add(new Citizen(name, age, id));

                }
                else if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];
                    identifiables.Add(new Robot(id, model));
                }



                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string detect = Console.ReadLine();

            foreach (var item in identifiables)
            {
                string current = item.Id;
                int firstIndex = current.Length - detect.Length;
                int secondIndex = detect.Length;
                string find = current.Substring(firstIndex, secondIndex);
                if (find == detect)
                {
                    Console.WriteLine(item.Id);
                }
            }

        }
    }
}
