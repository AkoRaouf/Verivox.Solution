using System;
using System.Collections.Generic;
using System.Text;

namespace Verivox.Api.Core.Interfaces
{
    /// <summary>
    /// Interface of tariff.
    /// </summary>
    public interface ITariff
    {
        string Name { get; }

        /// <summary>
        /// Calculates annual cost of tariff based on consumption.
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns>annual cost.</returns>
        decimal Calculate(decimal consumption);
    }
}
