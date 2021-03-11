using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicles
    {
        private const double airConditioner = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity) 
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
        public override void DriveEmpty(double distance)
        {
            base.DriveEmpty(distance);
        }
    }
}
