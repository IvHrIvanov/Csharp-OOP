using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicles
    {
        private const double airConditioner = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm, airConditioner)
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
