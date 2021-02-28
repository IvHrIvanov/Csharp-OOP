using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public Animal (string name,int age,string gender)
        {
            Age = age;
            Name = name;
            Gender = gender;
        }
        public virtual string ProduceSound()
        {
            return string.Empty;
        }
        public override string ToString()
        {
            return this.GetType().Name +
                Environment.NewLine +
                $"{Name} {Age} {Gender}";
        }
    }
}
