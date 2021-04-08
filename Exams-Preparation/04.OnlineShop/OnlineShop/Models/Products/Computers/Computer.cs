using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> perhiperals;
        private decimal price;
        private double ovveralPerformance;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            perhiperals = new List<IPeripheral>();
            this.price = price;
            this.ovveralPerformance = overallPerformance;
        }

        public IReadOnlyCollection<IComponent> Components => components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => perhiperals.ToList().AsReadOnly();
        public decimal Price => this.price + components.Sum(x => x.Price) + perhiperals.Sum(x => x.Price);
        public double OverallPerformance => components.Sum(x => x.OverallPerformance) / components.Count + ovveralPerformance;

        public void AddComponent(IComponent component)
        {
            if (this.components.Contains(component))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.perhiperals.Contains(peripheral))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }
            this.perhiperals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {Id}.");
            }
            var remove = components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(remove);
            return remove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (perhiperals.Count == 0 || !perhiperals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {Id}.");
            }
            var remove = perhiperals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            perhiperals.Remove(remove);
            return remove;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})");
            //if (components.Count == 0)
            //{
            //    return sb.ToString().TrimEnd();
            //}
            sb.AppendLine($" Components ({this.components.Count}):");

            double avarage = perhiperals.Sum(x => x.OverallPerformance);
            foreach (var item in components)
            {
                sb.AppendLine($"  Overall Performance: {item.OverallPerformance:f2}. Price: {item.Price:f2} - {item.GetType().Name}: {item.Manufacturer} {item.Model} (Id: {item.Id}) Generation: {item.Generation}");
            }
            sb.AppendLine($" Peripherals ({perhiperals.Count}); Average Overall Performance ({avarage:f2}):");
            foreach (var item in perhiperals)
            {
                sb.AppendLine($"  Overall Performance: {item.OverallPerformance:f2}. Price: {item.Price:f2} - {item.GetType().Name}: {item.Manufacturer} {item.Model} (Id: {item.Id}) Connection Type: {item.ConnectionType}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
