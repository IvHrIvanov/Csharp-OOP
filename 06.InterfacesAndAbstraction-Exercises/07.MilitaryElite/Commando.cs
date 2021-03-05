using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(decimal salary, string iD, string firstName, string lastName, Corps corps) 
            : base(salary, iD, firstName, lastName, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missons => missions.AsReadOnly();

        public void AddMissions(IMission mission)
        {
            this.missions.Add(mission);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var item in missions)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
