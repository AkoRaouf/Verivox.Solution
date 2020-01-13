using System.Collections.Generic;
using System.Linq;
using Verivox.Api.Core.Comparison;
using Verivox.Api.Core.Interfaces;

namespace Verivox.Api.Core.Products
{
    public class ProductsList : IProductComparison
    {
        public List<Recomendation> recomendations = new List<Recomendation>();
        private readonly List<IProduct> _products;

        public ProductsList(IEnumerable<IProduct> products)
        {
            _products = products.ToList();
        }

        public List<Recomendation> Compare(List<decimal> consumptionPlans)
        {
            consumptionPlans.ForEach(plan => _products.ForEach(product => recomendations.Add(
            new Recomendation()
            {
                TariffName = product.Name,
                AnnualCost = product.Calculate(plan),
                Consumption = plan
            }
            )));

            return recomendations.OrderBy(x => x.AnnualCost).ToList();
        }
    }
}
