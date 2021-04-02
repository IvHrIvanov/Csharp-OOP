using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Messages;
using System.Linq;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private  ICollection<IBakedFood> foodOrders;
        private  ICollection<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private bool isReserved;
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;    
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved
        {
            
            get => this.isReserved;
            private set
            {
                this.isReserved = value;
            }
        }

        public decimal Price
        {
            get => this.foodOrders.Sum(x => x.Price) + this.drinkOrders.Sum(x => x.Price) + PricePerPerson * NumberOfPeople;

        }
      

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            isReserved = false;
            Capacity = 0;

        }

        public decimal GetBill()
        {
            
            return Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
          
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
           
            foodOrders.Add(food);

        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            isReserved = true;
        }
    }
}
