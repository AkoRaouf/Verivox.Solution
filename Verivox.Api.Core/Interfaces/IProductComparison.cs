using System;
using System.Collections.Generic;
using System.Text;
using Verivox.Api.Core.Comparison;

namespace Verivox.Api.Core.Interfaces
{
    public interface IProductComparison
    {
        List<Recomendation> Compare(List<decimal> consumptionPlans);
    }
}
