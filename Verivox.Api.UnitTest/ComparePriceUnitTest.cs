using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Verivox.Api.Core.Dto;
using Xunit;

namespace Verivox.Api.UnitTest
{
    public class ComparePriceUnitTest
    {
        ///Test server for hosting api and  sending request throgh HTTP Request.
        private readonly TestServer _server;
        ///Clinet for send HTTP request to the hosted service.
        private readonly HttpClient _client;

        public ComparePriceUnitTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        /// <summary>
        /// Checks that the received response is null or not.
        /// </summary>
        [Fact]
        public void Test_Geting_Results_Through_HttpRequest()
        {
            // Act
            var response = _client.GetAsync("/api/compare?consumptionPatterns=1000, 1500, 2300").Result;

            //Assert
            Assert.NotNull(response);
        }

        [Fact]
        public void Test_Minimum_Result_Is_280()
        {
            // Act
            var response = _client.GetAsync("/api/compare?consumptionPatterns=1000, 1500, 2300").Result;
            var recommendations = JsonConvert.DeserializeObject<List<Recommendation>>(response.Content.ReadAsStringAsync().Result);

            //Assert
            Assert.Equal(280, recommendations[0].AnnualCost);
        }

        [Fact]
        public void Test_Missing_Parameters()
        {
            // Act
            var response = _client.GetAsync("/api/compare?consumptionPatterns=kjhads, jsadjh").Result;
            string result = (response.Content.ReadAsStringAsync().Result.ToString());

            var isContin = result.Contains("The provided prameters is not correct!");
            //Assert
            Assert.True(isContin);
        }
    }
}
