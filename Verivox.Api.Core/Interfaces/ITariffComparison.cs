using System;
using System.Collections.Generic;
using System.Text;
using Verivox.Api.Core.Dto;

namespace Verivox.Api.Core.Interfaces
{
    /// <summary>
    /// Basic interface, for tariff.
    /// </summary>
    public interface ITariffComparison
    {
        /// <summary>
        /// This method is for camparing of annual costs based of all tariffs.
        /// </summary>
        /// <param name="consumptionPatterns"></param>
        /// <returns>recommentations based on consumption and tariffs.</returns>
        List<Recommendation> Compare(List<decimal> consumptionPatterns);
    }
}
