using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functions;
using Functionals;

namespace Optimizator
{
    interface IOptimizator
    {
        IVector Minimize(IFunctional objective,

        IParametricFunction function,

        IVector initialParameters,

        IVector minimumParameters = default,

        IVector maximumParameters = default);

    }
}
