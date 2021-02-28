using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string DefaulGender = "Female";
        public Kitten(string name, int age)
            : base(name,age,DefaulGender)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
