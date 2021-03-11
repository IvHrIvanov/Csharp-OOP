using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicles
    {
        private const double airConditioner = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, airConditioner,tankCapacity)
        {
           
        }
       
        public override void Drive(double distance)
        {
            base.Drive(distance);
        }
        public override void Refuel(double refuel)
        {
            base.Refuel(refuel);
        }
      
        public override string ReturnFuel()
        {
            return base.ReturnFuel();
        }
    }
}
