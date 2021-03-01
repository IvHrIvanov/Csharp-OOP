using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Person personBubi = new Person("Bubi", "Bubov", 15, 460);
            List<Person> persons = new List<Person>();

            try
            {


                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] input = Console.ReadLine().Split(" ");
                    var person = new Person(input[0], input[1], int.Parse(input[2]),
                                                                decimal.Parse(input[3]));
                    persons.Add(person);

                }
                Team team = new Team("SoftUni");
                persons.ForEach(x => team.AddPlayer(x));

                Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
                Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
