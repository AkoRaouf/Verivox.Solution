using System.Collections.Generic;
using System.Linq;
using Verivox.Api.Core.Dto;
using Verivox.Api.Core.Interfaces;

namespace Verivox.Api.Core.Products
{
    /// <summary>
    /// Comparison the annual cost of tariffs.
    /// </summary>
    public class TariffComparison : ITariffComparison
    {
        public List<Recommendation> recommendations = new List<Recommendation>();
        private readonly List<ITariff> _tariffs;

        /// <summary>
        /// Tariffs will injected by this constructor.
        /// </summary>
        /// <param name="tariffs">list of tariffs.</param>
        public TariffComparison(IEnumerable<ITariff> tariffs)
        {
            _tariffs = tariffs.ToList();
        }

        /// <summary>
        /// Compares annual cost of consumption.
        /// </summary>
        /// <param name="consumptionPatterns"></param>
        /// <returns>recommentations based on consumption and tariffs.</returns>
        public List<Recommendation> Compare(List<decimal> consumptionPatterns)
        {
            consumptionPatterns.ForEach(plan => _tariffs.ForEach(product => recommendations.Add(
            new Recommendation()
            {
                TariffName = product.Name,
                AnnualCost = product.Calculate(plan),
                Consumption = plan
            }
            )));

            return recommendations.OrderBy(x => x.AnnualCost).ToList();
        }
    }
}
