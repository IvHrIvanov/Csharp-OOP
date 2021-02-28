namespace PlayersAndMonsters
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight blade = new BladeKnight("Ivan", 80);
            Console.WriteLine(blade);
        }
    }
}