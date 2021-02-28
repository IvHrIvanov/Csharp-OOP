namespace Animals
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Beast!")
                {
                    break;
                }
                string[] input = Console.ReadLine().Split(" ");

                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender) || age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (command == "Cat")
                {

                    Cat car = new Cat(name, age, gender);
                    Console.WriteLine(car);
                    Console.WriteLine(car.ProduceSound());

                }
                else if (command == "Dog")
                {

                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());

                }
                else if (command == "Frog")
                {

                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if (command == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }
                else if (command == "Kitten")
                {

                    Kitten kitten = new Kitten(name, age);
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }

            }
        }
    }
}
