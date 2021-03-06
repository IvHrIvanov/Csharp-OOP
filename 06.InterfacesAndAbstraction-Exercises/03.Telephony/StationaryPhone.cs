using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : ICalling
    {
        public  string Call(string number)
        {
            foreach (var currentSymbol in number)
            {
                if (Char.IsDigit(currentSymbol))
                {
                    continue;
                }
                return "Invalid number!";
            }
            return $"Dialing... {number}";
        }
    }
}
