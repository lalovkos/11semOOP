using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using Utility;

namespace Functions
{
        interface IParametricFunction
        {
            abstract IFunction Bind(IVector parameters);
            abstract IFunction Copy();
        }

        interface IFunction
        {
            abstract double Value(IVector point);
        }

        interface IDifferentiableFunction : IFunction
        {
            abstract IVector Gradient(IVector point);
        }

        class LinearFunction : IDifferentiableFunction, IParametricFunction
        {
            private IVector _parameters;

            public IFunction Bind(IVector parameters)
            {
                this._parameters = parameters;
                return this;
            }

            public double Value(IVector point)
            {
                double sum = default;
                for (int i = 0; i < point.Count(); i++)
                {
                    sum += _parameters[i] * point[i];
                }
                return sum + _parameters.Last();
            }

            public IVector Gradient(IVector point)
            {
                IVector gradient = new Vector();
                for (int i = 0; i < _parameters.Count()-1; i++)
                {
                    gradient.Add(_parameters[i]);
                }
                return gradient;
            }

            public IFunction Copy()
            {
                return new LinearFunction();
            }

        }

        class PolinomFunction : IParametricFunction, IFunction
        {
            private IVector _parameters;

            public IFunction Bind(IVector parameters)
            {
                this._parameters = parameters;
                return this;
            }

            public double Value(IVector point)
            {
                double sum = default;
                for (int i = 0; i < _parameters.Count(); i++)
                {
                    sum += _parameters[i] * Math.Pow(point[0], _parameters.Count() - i - 1);
                }

                return sum;
            }
            public IFunction Copy()
            {
                return new PolinomFunction();
            }

    }
}
