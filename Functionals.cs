using System;
using System.Collections.Generic;
using Functions;
using MathNet.Numerics;
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

    class L1Norm : IDifferentiableFunctional
    {
        private double[] _pointsx = default;
        private double[] _pointsy = default;

        public L1Norm(double [] pointsx, double [] pointsy)
        {
            _pointsx = pointsx;
            _pointsy = pointsy;
        }

        public double Value(IFunction function)
        {
            
            return Distance.SAD(_pointsy, ); 
        }

        public IVector Gradient(IFunction function)
        {
            return;
        }


    }



}
