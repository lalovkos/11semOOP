using System;
using System.Collections.Generic;
using Functions;
using Utility;
using MathNet.Numerics.LinearAlgebra;


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

        //TODO: Изменить на IMatrix
        Matrix<double> Jacobian(IFunction function);
    }
}
