namespace Restaurant
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Fish fish = new Fish("Krisa", 2.50M);
            Console.WriteLine(fish.Grams);
            Console.WriteLine(fish.Name);
            Console.WriteLine(fish.Price);

        }
    }
}