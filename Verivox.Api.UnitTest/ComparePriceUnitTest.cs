using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Verivox.Api.UnitTest
{
    public class ComparePriceUnitTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ComparePriceUnitTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public void Compare()
        {
            // Act
            var response = _client.GetAsync("/api/compare?consumptionPlans=1000, 1500, 2300").Result;

            //Assert
            Assert.NotNull(response);
        }
    }
}
