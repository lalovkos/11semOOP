using System;
using System.Linq;
using Utility;

namespace Functions
{
        interface IParametricFunction : ICloneable
        {
            IFunction Bind(IVector parameters);
        }

        interface IFunction : ICloneable
        {
            double Value(IVector point);
        }

        interface IDifferentiableFunction : IFunction
        {
            IVector Gradient(IVector point);
        }

        class LinearFunction : IDifferentiableFunction, IParametricFunction, ICloneable
        {
            private IVector _parameters;

            public IVector parameters
            {
                get { return _parameters; }
                set { _parameters = value; }
            }

            public IFunction Bind(IVector parameters)
            {
                this.parameters = parameters;
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
            
            public object Clone()
            {
                return MemberwiseClone();
            }

        }

        class PolinomFunction : IParametricFunction, IFunction, ICloneable
        {
            private IVector _parameters;
            public IVector parameters
            {
                get { return _parameters; }
                set { _parameters = value; }
            }

            public IFunction Bind(IVector parameters)
            {
                this.parameters = parameters;
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
            
            public object Clone()
            {
                return MemberwiseClone();
            }

        }
}
