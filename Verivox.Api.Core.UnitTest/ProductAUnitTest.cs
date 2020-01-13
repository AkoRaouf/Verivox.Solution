using System;
using Verivox.Api.Core.Interfaces;
using Xunit;

namespace Verivox.Api.Core.UnitTest
{
    public class ProductAUnitTest
    {
        [Fact]
        public void Test_Conumption_3500()
        {
            //Arrange
            ITariff product = new Products.BasicElectricityTariff();
            decimal consumption = 3500;

            //Act
            var annualCost = product.Calculate(consumption);

            //Assert
            Assert.Equal(830, annualCost);

        }

        [Fact]
        public void Test_Conumption_4500()
        {
            //Arrange
            ITariff product = new Products.BasicElectricityTariff();
            decimal consumption = 4500;

            //Act
            var annualCost = product.Calculate(consumption);

            //Assert
            Assert.Equal(1050, annualCost);
        }

        [Fact]
        public void Test_Conumption_6000()
        {
            //Arrange
            ITariff product = new Products.BasicElectricityTariff();
            decimal consumption = 6000;

            //Act
            var annualCost = product.Calculate(consumption);

            //Assert
            Assert.Equal(1380, annualCost);
        }

        [Fact]
        public void Test_Conumption_Exception()
        {
            //Arrange
            ITariff product = new Products.BasicElectricityTariff();
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
