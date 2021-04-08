
using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Component = OnlineShop.Models.Products.Component;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computer;
        private List<Component> component;
        private List<Peripheral> peripheral;
        public Controller()
        {
            computer = new List<IComputer>();
            component = new List<Component>();
            peripheral = new List<Peripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            Component componentCreate = null;
            var addToComp = computer.FirstOrDefault(x => x.Id == computerId);
            if (addToComp == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            if (component.Any(x => x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType == nameof(CentralProcessingUnit))
            {

                componentCreate = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                componentCreate = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                componentCreate = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == nameof(SolidStateDrive))
            {

                componentCreate = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == nameof(VideoCard))
            {
                componentCreate = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == nameof(Motherboard))
            {
                componentCreate = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);

            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            addToComp.AddComponent(componentCreate);
            component.Add(componentCreate);
            return $"Component {componentCreate.GetType().Name} with id {componentCreate.Id} added successfully in computer with id {computerId}.";

        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer comp = null;
            if (computer.Any(x => x.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }
            if (computerType == nameof(Laptop))
            {
                comp = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == nameof(DesktopComputer))
            {
                comp = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            computer.Add(comp);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            Peripheral pheripheralCreate = null;
            if (this.peripheral.Any(x => x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }
            if (peripheralType == nameof(Headset))
            {
                pheripheralCreate = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Keyboard))
            {
                pheripheralCreate = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else if (peripheralType == nameof(Monitor))
            {
                pheripheralCreate = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Mouse))
            {
                pheripheralCreate = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }
            var compFind = computer.FirstOrDefault(x => x.Id == computerId);
            if (compFind == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            compFind.AddPeripheral(pheripheralCreate);
            this.peripheral.Add(pheripheralCreate);
            return $"Peripheral {pheripheralCreate.GetType().Name} with id {pheripheralCreate.Id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {

            IComputer buyBest = null;
            double best = 0;
            foreach (var item in computer)
            {
                if(item.OverallPerformance>best && item.Price<=budget)
                {
                    buyBest = item;
                    best = item.OverallPerformance;
                }
            }

            if (buyBest == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            computer.Remove(buyBest);
            return buyBest.ToString();
        }

        public string BuyComputer(int id)
        {
            var findComp = computer.FirstOrDefault(x => x.Id == id);
            if (findComp == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            computer.Remove(findComp);
            return findComp.ToString();
        }

        public string GetComputerData(int id)
        {
            var compData = computer.FirstOrDefault(x => x.Id == id);
            if (compData == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            return compData.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var compFind = computer.FirstOrDefault(x => x.Id == computerId);
            if (compFind == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            compFind.RemoveComponent(componentType);
            var remove = component.FirstOrDefault(x => x.GetType().Name == componentType);
            component.Remove(remove);

            return $"Successfully removed {remove.GetType().Name} with id {remove.Id}.";


        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var findComp = computer.FirstOrDefault(x => x.Id == computerId);
            if (findComp == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            findComp.RemovePeripheral(peripheralType);
            var findPherip = peripheral.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripheral.Remove(findPherip);

            return $"Successfully removed {findPherip.GetType().Name} with id {findPherip.Id}.";
        }
    }
}
