using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Verivox.Api.Core.Dto;
using Verivox.Api.Core.Interfaces;

namespace Verivox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompareController : ControllerBase
    {
        ///The logger could be any log providers.
        private readonly ILogger<CompareController> _logger;
        ///The tariff comparison object.
        private readonly ITariffComparison _productComparison;
        public CompareController(ILogger<CompareController> logger, ITariffComparison productComparison)
        {
            _logger = logger;
            _productComparison = productComparison;
        }

        [HttpGet]
        public IActionResult Compare([FromQuery] string consumptionPatterns)
        {
            #region Paramitter Validation
            if (string.IsNullOrEmpty(consumptionPatterns))
            {
                _logger.LogError("The consumptionPatterns parameter is not contain any value.");
                return new BadRequestObjectResult(new { message = "There are no provided prameters!", currentDate = DateTime.Now });
            }
            #endregion

            #region Featching Parameters
            ///Try to featch all consumption patterns based and convert them to a list.
            var decimalSplitedPatterns = GetParameters(consumptionPatterns);
            if (decimalSplitedPatterns.Count == 0)
            {
                _logger.LogError("The consumptionPatterns parameter is not contain any valid value.");
                return new BadRequestObjectResult(new { message = "The provided prameters is not correct!", currentDate = DateTime.Now });
            }
            #endregion

            #region Comparison
            var compareResult = new List<Recommendation>();
            try
            {
                ///Try to compare annual costs based on patterns. 
                compareResult = _productComparison.Compare(decimalSplitedPatterns);
            }
            catch (Exception exception)
            {
                _logger.LogError("There some errors in comparing plans!", exception);
                return NotFound(compareResult);
            }
            _logger.LogInformation($"The comparison for {consumptionPatterns} has been done.");
            return Ok(compareResult); 
            #endregion
        }

        public List<decimal> GetParameters(string consumptionPatterns)
        {
            var decimalSplitedPatterns = new List<decimal>();
            foreach (var item in consumptionPatterns.Split(',').ToList())
            {
                if (decimal.TryParse(item, out decimal parsedValue))
                    decimalSplitedPatterns.Add(parsedValue);
            }

            return decimalSplitedPatterns;
        }
    }
}