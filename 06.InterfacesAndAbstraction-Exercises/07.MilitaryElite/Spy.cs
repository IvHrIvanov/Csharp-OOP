using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string iD, string firstName, string lastName,int codeNumber)
            : base(iD, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }
        public override string ToString()
        {
            return base.ToString()
                +Environment.NewLine+
                $"Code Number: {CodeNumber}";
        }
    }
}
