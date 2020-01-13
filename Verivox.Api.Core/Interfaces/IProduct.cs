using System;
using System.Collections.Generic;
using System.Text;

namespace Verivox.Api.Core.Interfaces
{
    public interface IProduct
    {
        string Name { get; }

        decimal Calculate(decimal consumption);
    }
}
