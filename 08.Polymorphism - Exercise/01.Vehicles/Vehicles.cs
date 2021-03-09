using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicles
    {

        protected Vehicles(double fuelQuantity, double fuelConsumptionPerKm, double airConditioner)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            AirConditioner = airConditioner;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }
        public double AirConditioner { get; set; }


        public virtual void Drive(double distance)
        {
            double requiredFuel = (AirConditioner +FuelConsumptionPerKm) * distance;

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
           FuelQuantity += refuel;
            
        }

        public virtual string ReturnFuel()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }

    }
}
