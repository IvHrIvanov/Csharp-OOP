using System;
using System.Linq;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

            Vehicles car = CreateVechichle();
            Vehicles truck = CreateVechichle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] driveOrRefuel = Console.ReadLine().Split(" ");
                string operation = driveOrRefuel[0];
                string type = driveOrRefuel[1];
                double fuelOrKm = double.Parse(driveOrRefuel[2]);

                if (type == nameof(Car))
                {
                    if (operation == nameof(car.Drive))
                    {
                        car.Drive(fuelOrKm);
                    }
                    else if ( operation==nameof(car.Refuel))
                    {
                        car.Refuel(fuelOrKm);
                    }
                }
                else if (type==nameof(Truck))
                {
                    if (operation == nameof(truck.Drive))
                    {
                        truck.Drive(fuelOrKm);
                    }
                    else if (operation == nameof(truck.Refuel))
                    {
                        truck.Refuel(fuelOrKm);
                    }
                }

            }
            Console.WriteLine(car.ReturnFuel());
            Console.WriteLine(truck.ReturnFuel());


        }

        private static Vehicles CreateVechichle()
        {
            string[] parts = Console.ReadLine().Split();


            string type = parts[0];
            double fuel = double.Parse(parts[1]);
            double consumption = double.Parse(parts[2]);

            Vehicles vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuel, consumption);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuel, consumption);
            }
            return vehicle;
        }
    }
}