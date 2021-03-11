using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
