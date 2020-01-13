using System;
using System.Collections.Generic;
using System.Text;
using Verivox.Api.Core.Interfaces;
using Verivox.Api.Core.Products;
using Xunit;

namespace Verivox.Api.Core.UnitTest
{
    public class ProductListUnitTest
    {
        [Fact]
        public void ProductList_Recommendation()
        {
            //Arrange
            ITariff productA = new BasicElectricityTariff();
            ITariff productB = new PackagedTariff();

            //Act
            var products = new List<ITariff>();
            products.Add(productA);
            products.Add(productB);

            var productList = new TariffComparison(products);
            var recommendation = productList.Compare(new List<decimal> { 1000, 3500, 4500, 6000, 7200, 10000 });
            //Assert
            Assert.Equal(280, recommendation[0].AnnualCost);
        }
    }
}
