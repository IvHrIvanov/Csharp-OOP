using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string codeName, MisionState misionstate)
        {
            CodeName = codeName;
            Misionstate = misionstate;
        }

        public string CodeName { get; private set; }

        public MisionState Misionstate { get; private set; }

        public void CompleteMision()
        {
            this.Misionstate = MisionState.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {this.Misionstate}";
        }
    }
}
