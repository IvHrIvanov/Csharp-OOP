namespace NeedForSpeed
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar race = new SportCar(250, 10);
            race.Drive(50);
            Console.WriteLine(race.Fuel);

        }
    }
}