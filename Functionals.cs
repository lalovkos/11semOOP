using System;
using System.Collections.Generic;
using Functions;

namespace Functionals
{
    interface IFunctional   
    {
        double Value(IFunction function);
    }

    interface IDifferentiableFunctional : IFunctional
    {
        IVector Gradient(IFunction function);
    }

    interface ILeastSquaresFunctional : IFunctional
    {
        IVector Residual(IFunction function);
        IMatrix Jacobian(IFunction function);
    }
}
