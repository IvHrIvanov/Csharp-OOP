using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public string Call(string number)
        {

            foreach (var currentSymbol in number)
            {
                if (Char.IsDigit(currentSymbol))
                {
                    continue;
                }
                return "Invalid number!";
            }
            return $"Calling... {number}";
        }

        public string Sites(string url)
        {

            if(url.Any(x=> char.IsDigit(x)))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {url}!";
        }
    }
}
