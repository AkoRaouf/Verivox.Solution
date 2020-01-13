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
            IProduct productA = new ProductA();
            IProduct productB = new ProductB();

            //Act
            var products = new List<IProduct>();
            products.Add(productA);
            products.Add(productB);

            var productList = new ProductsList(products);
            var recommendation = productList.Compare(new List<decimal> { 1000, 3500, 4500, 6000, 7200, 10000 });
            //Assert
            Assert.Equal(280, recommendation[0].AnnualCost);
        }
    }
}
