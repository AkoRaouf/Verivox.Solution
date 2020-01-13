using System;
using Verivox.Api.Core.Interfaces;

namespace Verivox.Api.Core.Products
{
    /// <summary>
    /// basic electricity tariff product.
    /// </summary>
    public class BasicElectricityTariff : ITariff
    {
        ///Name of tariff.
        public string Name => "basic electricity tariff";

        ///Basic cost of tariff per month.
        private readonly decimal BasicCostPerMonth = 5;

        //The consumption cost of tariff.
        private readonly decimal ConsumptionCost = 22;

        /// <summary>
        /// This method will calculate annual cost of tariff based on annual consumption.
        /// </summary>
        /// <param name="consumption"> consumption amount.</param>
        /// <returns>annual cost</returns>
        public decimal Calculate(decimal consumption)
        {
            if (consumption <= 0)
                throw new ArgumentException("The consumption must have value have a valid value!", "consumption");

            return (BasicCostPerMonth * 12) + (consumption * ConsumptionCost)/100;
        }
    }
}
