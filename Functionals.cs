using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Functions;
using Utility;
using Vector = Utility.Vector;


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

    class L1NormLinear : IFunctional
    {
        private IMatrix _pointsx = default;
        private IVector _pointsy = default;

        public L1NormLinear(IMatrix pointsx, IVector pointsy)
        {
            _pointsx = pointsx;
            _pointsy = pointsy;
        }

        public double Value(IFunction function)
        {
            IVector row = default;
            double sum = 0;
            for (int i = 0; i < _pointsy.Count; i++)
            {
                row = _pointsx.GetRow(i);
                sum += Math.Abs(function.Value(_pointsx.GetRow(i)) - _pointsy[i]);
            }

            return sum;
        }
    }

    class L1NormPolynom : IFunctional
    {
        private IVector _pointsx = default;
        private IVector _pointsy = default;

        public L1NormPolynom(IVector pointsx, IVector pointsy)
        {
            _pointsx = pointsx;
            _pointsy = pointsy;
        }

        public double Value(IFunction function)
        {
            double sum = 0;
            for (int i = 0; i < _pointsy.Count; i++)
            {
                Vector vec = new Vector();
                vec.Add(_pointsx[i]); 
                sum += Math.Abs(function.Value(vec) - _pointsy[i]);
            }

            return sum;
        }
    }

    class L2NormPolynom : IFunctional
    {
        private IVector _pointsx = default;
        private IVector _pointsy = default;

        public L2NormPolynom(IVector pointsx, IVector pointsy)
        {
            _pointsx = pointsx;
            _pointsy = pointsy;
        }

        public double Value(IFunction function)
        {
            double sum = 0;
            for (int i = 0; i < _pointsy.Count; i++)
            {
                Vector vec = new Vector();
                vec.Add(_pointsx[i]);
                sum += Math.Pow(function.Value(vec) - _pointsy[i], 2);
            }

            return sum;
        }
    }


}
