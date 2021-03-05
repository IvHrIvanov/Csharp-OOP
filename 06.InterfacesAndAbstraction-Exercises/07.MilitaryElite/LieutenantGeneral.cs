using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        public LieutenantGeneral(decimal salary, string iD, string firstName, string lastName) 
            : base(salary, iD, firstName, lastName)
        {
            privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => privates.AsReadOnly();

        public void AddPriver(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var item in privates)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd(); ;
        }
    }
}
