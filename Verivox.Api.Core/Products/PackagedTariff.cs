using System;
using System.Collections.Generic;
using System.Text;
using Verivox.Api.Core.Interfaces;

namespace Verivox.Api.Core.Products
{
    /// <summary>
    /// Packaged tariff product.
    /// </summary>
    public class PackagedTariff : ITariff
    {
        ///Name of tariff.
        public string Name => "Packaged tariff";
        ///Basic cost of tariff.
        private readonly decimal BasicCost = 800;
        //Additional cost of tariff.
        private readonly decimal AdditionalCost = 30;

        ///The consumption threshold for tariff.
        private readonly decimal ConsumptionThreshold = 4000;

        /// <summary>
        /// This method will calculate annual cost of tariff based on annual consumption.
        /// </summary>
        /// <param name="consumption">consumption amount.</param>
        /// <returns>annual cost</returns>
        public decimal Calculate(decimal consumption)
        {
            if (consumption <= 0)
                throw new ArgumentException("The consumption must have value have a valid value!", "consumption");

            if (consumption < ConsumptionThreshold)
                return BasicCost;
            else return BasicCost + ((consumption - ConsumptionThreshold) * AdditionalCost)/100;
        }
    }
}
