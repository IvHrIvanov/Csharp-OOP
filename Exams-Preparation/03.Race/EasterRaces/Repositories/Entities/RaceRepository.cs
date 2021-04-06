using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Utilities.Messages
{
    public class RaceRepository: IRepository<IRace>
    {
        private readonly IDictionary<string, IRace> race;
        public RaceRepository ()
        {
            race = new Dictionary<string, IRace>();
        }
        public void Add(IRace model)
        {
            if (race.ContainsKey(model.Name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, model.Name));
            }
            race.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return race.Values.ToList();
        }

        public IRace GetByName(string name)
        {
            IRace racers = null;
            if (race.ContainsKey(name))
            {
                racers = race[name];
            }
            return racers;
        }

        public bool Remove(IRace model)
        {
            return race.Remove(model.Name);
        }
    }
}
