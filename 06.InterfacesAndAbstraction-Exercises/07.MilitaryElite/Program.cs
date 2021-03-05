using System;
using System.Collections.Generic;

namespace _07.MilitaryElite
{
    public class Program
    {
        public static void Main(string[] args)
        {
       
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();
            string[] input = Console.ReadLine().Split(" ");

            while (input[0] != "End")
            {
                string type = input[0];
                string id = input[1];
                string firstName = input[2];
                string lastName = input[3];
                
                if (type == nameof(Private))
                {
                    string firt = input[4];
                    decimal salary = decimal.Parse(firt);
                    soldiers[id] = new Private(salary, id, firstName, lastName);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(input[4]);
                    ILieutenantGeneral general = new LieutenantGeneral(salary, id, firstName, lastName);

                    for (int i = 5; i < input.Length; i++)
                    {

                        string privateId = input[i];
                        if (!soldiers.ContainsKey(privateId))
                        {
                            continue;
                        }
                        general.AddPriver((IPrivate)soldiers[privateId]);
                    }
                    soldiers[id] = (ISoldier)general;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(input[4]);
                    bool isValid = Enum.TryParse(input[5], out Corps corps);
                    if (!isValid)
                    {
                        continue;
                        
                    }
                    IEngineer engineer = new Engineer(salary, id, firstName, lastName, corps);
                    for (int i = 6; i < input.Length; i += 2)
                    {
                        string part = input[i];
                        int hourseWorked = int.Parse(input[i + 1]);
                        IRepair repair = new Repair(part, hourseWorked);
                        engineer.AddRepair(repair);
                    }
                    soldiers[id] = engineer;

                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(input[4]);
                    bool isValid = Enum.TryParse(input[5], out Corps corps);
                    if (isValid)
                    {
                        Commando commando = new Commando(salary, id, firstName, lastName, corps);
                        for (int i = 6; i < input.Length; i += 2)
                        {
                            string codeName = input[i];
                            string state = input[i + 1];
                            bool IsMisionStateValid = Enum.TryParse(state, out MisionState states);
                            if (!IsMisionStateValid)
                            {
                                continue;
                            }
                            IMission mission = new Mission(codeName, states);
                            commando.AddMissions(mission);

                        }
                        soldiers[id] = commando;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(input[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers[id] = spy;
                }

                input = Console.ReadLine().Split(" ");
            }
            foreach (var item in soldiers.Values)
            {
                Console.WriteLine(item);
            }
        }
    }
}