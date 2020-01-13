using System;
using System.Collections.Generic;
using System.Text;
using Verivox.Api.Core.Interfaces;

namespace Verivox.Api.Core.Products
{
    public class ProductB : IProduct
    {
        public string Name => "Packaged tariff";

        private readonly decimal BasicCost = 800;
        private readonly decimal AdditionalCost = 30;

        private readonly decimal BasicConsumption = 4000;

        public decimal Calculate(decimal consumption)
        {
            if (consumption <= 0)
                throw new ArgumentException("The consumption must have value have a valid value!", "consumption");

            if (consumption < BasicConsumption)
                return BasicCost;
            else return BasicCost + ((consumption - BasicConsumption) * AdditionalCost)/100;
        }
    }
}
