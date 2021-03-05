using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(decimal salary, string iD, string firstName, string lastName)
            : base(iD, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:f2}";
        }


    }
}
