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
            if (string.IsNullOrEmpty(consumptionPatterns))
            {
                _logger.LogError("The consumptionPatterns parameter is not contain any value.");
                return new BadRequestObjectResult(new { message = "The provided prameters is not correct!", currentDate = DateTime.Now });
            }

            ///Try to featch all consumption patterns based and convert them to a list.
            var decimalSplitedPatterns = consumptionPatterns.Split(',').Select(decimal.Parse).ToList();
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
            _logger.LogError($"The comparison for {consumptionPatterns} has been done.");
            return Ok(compareResult);
        }
    }
}