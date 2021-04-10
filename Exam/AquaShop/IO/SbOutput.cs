using AquaShop.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.IO
{
    public class SbOutput : IWriter
    {

        private StringBuilder sb;
        public SbOutput()
        {
            sb = new StringBuilder();
        }
        
        public void Write(string message)
        {
            sb.Append(message);
        }

        public void WriteLine(string message)
        {
            sb.AppendLine(message);
        }
        public override string ToString()
        {
            return sb.ToString().TrimEnd();
        }
    }
}
