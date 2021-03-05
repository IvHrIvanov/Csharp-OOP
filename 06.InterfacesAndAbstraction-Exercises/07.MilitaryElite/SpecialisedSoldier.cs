using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier
            (
            decimal salary, 
            string iD,
            string firstName,
            string lastName, 
            Corps corps
            )
            : base(salary, iD, firstName, lastName)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; private set; }
        public override string ToString()
        {
            return base.ToString()+Environment.NewLine+$"Corps: {Corps}";
        }
    }
}
