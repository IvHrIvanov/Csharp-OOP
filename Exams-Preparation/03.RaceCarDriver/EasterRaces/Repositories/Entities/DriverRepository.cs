using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository: IRepository<IDriver>
    {
        private readonly IDictionary<string, IDriver> drivers;
        public DriverRepository()
        {
            drivers = new Dictionary<string, IDriver>();
        }
        public void Add(IDriver model)
        {
           if(drivers.ContainsKey(model.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists,model.Name));
            }
            drivers.Add(model.Name, model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return drivers.Values.ToList();
        }

        public IDriver GetByName(string name)
        {
            IDriver driver = null;
            if (drivers.ContainsKey(name))
            {
                driver = drivers[name];
            }
            return driver;
        }

        public bool Remove(IDriver model)
        {
            return drivers.Remove(model.Name);
        }
    }
}
