using System;
using System.Collections.Generic;
using Functions;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using Utility;


namespace Functionals
{
    interface IFunctional   
    {
        abstract double Value(IFunction function);
    }

    interface IDifferentiableFunctional : IFunctional
    {
        abstract IVector Gradient(IFunction function);
    }

    interface ILeastSquaresFunctional : IFunctional
    {
        abstract IVector Residual(IFunction function);

        abstract IMatrix Jacobian(IFunction function);
    }

    class L1NormLinear : IDifferentiableFunctional
    {
        private IMatrix _pointsx;
        private IVector _pointsy = default;

        public L1NormLinear(IMatrix pointsx, IVector pointsy)
        {
            _pointsx = pointsx;
            _pointsy = pointsy;
        }

        public double Value(IFunction function)
        {
            Vector<double> row = default;
            double sum = 0;
            for (int i =0; i < _pointsy.Count; i++)
            { 
                row = _pointsx.Row(i);
                sum += Math.Abs(function.Value(row as IVector) - _pointsy[i]);
            }

            return sum;
        }

        public IVector Gradient(IFunction function)
        {
            Vector<double> grad = default;
            for (int i = 0; i < grad.Count; i++)
            {
                var func = function as IParametricFunction;
                grad[i] = Value(function);
            }

            return grad as IVector;
        }


    }



}
