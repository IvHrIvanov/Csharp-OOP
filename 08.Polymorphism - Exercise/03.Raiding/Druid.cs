using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {

        private const int DruidPower = 80;

        public Druid(string name)
            : base(DruidPower, name)
        {
        }

        public override string CastAbility()
        {
          return $"{GetType().Name} - {Name} healed for {Power}";
        }

    }
}
