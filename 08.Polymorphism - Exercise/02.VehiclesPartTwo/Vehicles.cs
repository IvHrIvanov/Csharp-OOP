using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicles
    {
        private double tankCapacity = 0;
        protected Vehicles(double fuelQuantity, double fuelConsumptionPerKm, double airConditioner, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            AirConditioner = airConditioner;
            this.tankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }
        public double AirConditioner { get; set; }
        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            set
            {
                if (tankCapacity < FuelQuantity)
                {
                    FuelQuantity = 0;
                }
            }
        }


        public virtual void Drive(double distance)
        {

            double requiredFuel = (AirConditioner + FuelConsumptionPerKm) * distance;

            if (requiredFuel > FuelQuantity)
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
            else
            {
                FuelQuantity -= requiredFuel;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }

        }
        public virtual void DriveEmpty(double distance)
        {
            double requiredFuel = FuelConsumptionPerKm * distance;

            if (requiredFuel > FuelQuantity)
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
            else
            {
                FuelQuantity -= requiredFuel;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");

            }
        }
        public virtual void Refuel(double refuel)
        {
            if (refuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (TankCapacity-FuelQuantity < refuel)
                {
                    Console.WriteLine($"Cannot fit {refuel} fuel in the tank");
                }
                else
                {
                    if (GetType().Name == nameof(Truck))
                    {
                        FuelQuantity += refuel * 0.95;
                    }
                    else
                    {
                        FuelQuantity += refuel;
                    }
                }
            }
        }

        public virtual string ReturnFuel()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }

    }
}
