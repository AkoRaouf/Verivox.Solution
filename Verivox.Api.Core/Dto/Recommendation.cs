using System;
using System.Collections.Generic;
using System.Text;

namespace Verivox.Api.Core.Dto
{
    /// <summary>
    /// The final result of comparison.
    /// </summary>
    public class Recommendation
    {
        public string TariffName { get; set; }
        public decimal AnnualCost { get; set; }
        public decimal Consumption { get; set; }
    }
}
