using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DefaulGender = "Male";
        public Tomcat(string name,int age)
            : base(name,age,DefaulGender)
        {

        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
