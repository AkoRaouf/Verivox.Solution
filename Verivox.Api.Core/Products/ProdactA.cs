using System;
using Verivox.Api.Core.Interfaces;

namespace Verivox.Api.Core.Products
{
    public class ProductA : IProduct
    {
        public string Name => "basic electricity tariff";

        private readonly decimal BasicCostPerMonth = 5;
        private readonly decimal ConsumptionCost = 22;

        public decimal Calculate(decimal consumption)
        {
            if (consumption <= 0)
                throw new ArgumentException("The consumption must have value have a valid value!", "consumption");

            return (BasicCostPerMonth * 12) + (consumption * ConsumptionCost)/100;
        }
    }
}
