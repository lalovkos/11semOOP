using System;
using Functions;
using Utility;

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

    class L1NormLinear : IFunctional
    {
        private IMatrix _matrix;
        private IVector _points;

        public L1NormLinear(IMatrix matrix, IVector points)
        {
            _matrix = matrix;
            _points = points;
        }

        public double Value(IFunction function)
        {
            double sum = default;
            for (int i = 0; i < _points.Count; i++)
            {
                sum += Math.Abs(function.Value(_matrix.GetRow(i)) - _points[i]);
            }
            return sum;
        }

    }

    class L1NormPolynom : IFunctional
    {
        private IVector _pointsx;
        private IVector _pointsy;

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
                sum += Math.Abs(function.Value(new Vector(_pointsx[i])) - _pointsy[i]);
            }
            return sum;
        }
    }

    class L2NormPolynom : IFunctional
    {
        private IVector _pointsx;
        private IVector _pointsy;

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
