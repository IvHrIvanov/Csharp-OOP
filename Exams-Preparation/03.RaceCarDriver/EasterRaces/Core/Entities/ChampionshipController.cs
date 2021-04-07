using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Repositories.Entities;
using EasterRaces.Repositories;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Races;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepo;
        private readonly IRepository<ICar> carRepo;
        private readonly IRepository<IRace> raceRepo;

        public ChampionshipController()
        {
            driverRepo = new DriverRepository();
            carRepo = new CarRepository();
            raceRepo = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var findDriver = driverRepo.GetByName(driverName);
            var car = carRepo.GetByName(carModel);
            if (findDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }
            findDriver.AddCar(car);
        
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var raceFind = raceRepo.GetByName(raceName);
            var findDriver = driverRepo.GetByName(driverName);
            if (raceFind == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (findDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            raceFind.AddDriver(findDriver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);

            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);

            }
            carRepo.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {


            Driver driver = new Driver(driverName);
            driverRepo.Add(driver);
            return $"Driver {driverName} is created.";

        }

        public string CreateRace(string name, int laps)
        {
            var findRace = raceRepo.GetByName(name);
            if (findRace == null)
            {
                Race race = new Race(name, laps);

                raceRepo.Add(race);
                return $"Race {name} is created.";
            }
            else
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
        }
        public string StartRace(string raceName)
        {

            var race = raceRepo.GetByName(raceName);

            var drivers = driverRepo.GetAll();
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            StringBuilder sb = new StringBuilder();
            Dictionary<string, double> final = new Dictionary<string, double>();
            foreach (var item in drivers)
            {
                double racePoints = item.Car.CalculateRacePoints(race.Laps);
                final.Add(item.Name, racePoints);
            }
            var sorter = final.OrderByDescending(x => x.Value).ToDictionary(x => x.Key);
            List<string> sorted = sorter.Keys.ToList();
            IDriver winner = drivers.FirstOrDefault(x => x.Name == sorted[0]);
            winner.WinRace();
            raceRepo.Remove(race);
            ;
            sb.AppendLine($"Driver {sorted[0]} wins {raceName} race.");
            sb.AppendLine($"Driver {sorted[1]} is second in {raceName} race.");
            sb.AppendLine($"Driver {sorted[2]} is third in {raceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}
