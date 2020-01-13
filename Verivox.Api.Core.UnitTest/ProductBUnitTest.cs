using System;
using Verivox.Api.Core.Interfaces;
using Verivox.Api.Core.Products;
using Xunit;

namespace Verivox.Api.UnitTest
{
    public class ProductBUnitTest
    {
        [Fact]
        public void Test_Conumption_3500()
        {
            //Arrange
            IProduct product = new ProductB();
            decimal consumption = 3500;

            //Act
            var annualCost = product.Calculate(consumption);

            //Assert
            Assert.Equal(800, annualCost);
        }

        [Fact]
        public void Test_Conumption_4500()
        {
            //Arrange
            IProduct product = new ProductB();
            decimal consumption = 4500;

            //Act
            var annualCost = product.Calculate(consumption);

            //Assert
            Assert.Equal(950, annualCost);
        }

        [Fact]
        public void Test_Conumption_6000()
        {
            //Arrange
            IProduct product = new ProductB();
            decimal consumption = 6000;

            //Act
            var annualCost = product.Calculate(consumption);

            //Assert
            Assert.Equal(1400, annualCost);
        }

        [Fact]
        public void Test_Conumption_Exception()
        {
            //Arrange
            IProduct product = new ProductB();
            decimal consumption = 0;
            Exception exception = new Exception();

            //Act
            try
            {
                var annualCost = product.Calculate(consumption);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            //Assert
            Assert.Equal("The consumption must have value have a valid value! (Parameter 'consumption')", exception.Message);
        }
    }
}
