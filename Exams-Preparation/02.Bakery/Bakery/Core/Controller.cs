using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<BakedFood> bakedFoods;
        private List<Drink> drinks;
        private List<Table> tables;
        private decimal totalIncome = 0m;
        public Controller()
        {
            this.bakedFoods = new List<BakedFood>();
            this.drinks = new List<Drink>();
            this.tables = new List<Table>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == nameof(Tea))
            {
                Tea tea = new Tea(name, portion, brand);
                drinks.Add(tea);
            }
            else if (type == nameof(Water))
            {
                Water water = new Water(name, portion, brand);
                drinks.Add(water);
            }
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {

            if (type == nameof(Bread))
            {
                Bread bread = new Bread(name, price);
                bakedFoods.Add(bread);
            }
            else if (type == nameof(Cake))
            {
                Cake cake = new Cake(name, price);
                bakedFoods.Add(cake);
            }
            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == nameof(InsideTable))
            {
                InsideTable insideTable = new InsideTable(tableNumber, capacity);
                tables.Add(insideTable);
            }
            else if (type == nameof(OutsideTable))
            {
                OutsideTable outsideTable = new OutsideTable(tableNumber, capacity);
                tables.Add(outsideTable);
            }
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in tables)
            {
                if (item.IsReserved == false)
                {
                    sb.AppendLine(item.GetFreeTableInfo());
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {


            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            StringBuilder sb = new StringBuilder();

            ITable leaveTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            sb.AppendLine($"Table: {tableNumber}");
            totalIncome += leaveTable.GetBill();
            sb.AppendLine($"Bill: {leaveTable.GetBill():f2}");
            leaveTable.Clear();
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!tables.Any(x => x.TableNumber == tableNumber))
            {
                return ($"Could not find table {tableNumber}");
            }
            if (!drinks.Any(x => x.Name == drinkName && x.Brand == drinkBrand))
            {
                return ($"There is no {drinkName} {drinkBrand} available");
            }
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink orderDrink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            table.OrderDrink(orderDrink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (!tables.Any(x => x.TableNumber == tableNumber))
            {
                return ($"Could not find table {tableNumber}");
            }
            if (!bakedFoods.Any(x => x.Name == foodName))
            {
                return ($"No {foodName} in the menu");
            }
            ;
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IBakedFood orderFood = bakedFoods.FirstOrDefault(x => x.Name == foodName);
            table.OrderFood(orderFood);
            ;
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            if (tables.Any(x => x.IsReserved == false && x.Capacity >= numberOfPeople))
            {
                int tableNumber = 0;
                ITable current = tables.FirstOrDefault(x => x.Capacity >= numberOfPeople && x.IsReserved == false);
                tableNumber = current.TableNumber;

                current.Reserve(numberOfPeople);

                return $"Table {tableNumber} has been reserved for {numberOfPeople} people";
            }
            else
            {
                return $"No available table for {numberOfPeople} people";
            }
        }
    }
}
