using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private readonly IDictionary<string, IDriver> drivers;
        private string name;
        private int laps;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new Dictionary<string, IDriver>(); ;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");

                }
                name = value;
            }

        }
        public int Laps
        {
            get
            {
                return laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => drivers.Values.ToList();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("Driver cannot be null.");
            }
            if (driver.CanParticipate == false)
            {
                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");
            }
            if (drivers.Keys.Contains(driver.Name))
            {
                throw new ArgumentNullException($"Driver {driver.Name} is already added in {this.Name} race.");
            }
            drivers.Add(driver.Name, driver);
        }
    }
}
