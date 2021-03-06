using System;
using System.Collections.Generic;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(" ");
            string[] sites = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                string currentPhone = input[i];
                if (currentPhone.Length == 10)
                {
                    Smartphone smartphoneCall = new Smartphone();
                    Console.WriteLine(smartphoneCall.Call(currentPhone));
                }
                else if (currentPhone.Length == 7)
                {
                    StationaryPhone stationarPhoneCall = new StationaryPhone();
                    
                    Console.WriteLine(stationarPhoneCall.Call(currentPhone));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            for (int i = 0; i < sites.Length; i++)
            {
                string currentSite = sites[i];
                Smartphone brows = new Smartphone();
                Console.WriteLine(brows.Sites(currentSite));


            }
        }

    }
}