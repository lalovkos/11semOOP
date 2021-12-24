using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functions;
using Functionals;
using Utility;

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

    class Universal : IOptimizator
    {
        public IVector Minimize(IFunctional objective, IParametricFunction function, IVector initialParameters,
            IVector minimumParameters = default, IVector maximumParameters = default)
        {
            return Annealing.Optimize(objective, function, initialParameters, minimumParameters, maximumParameters);
        }
    }

    static class Annealing
    {
        public static IVector Optimize(IFunctional objective, IParametricFunction function, IVector initialParameters, IVector minimumParameters, IVector maximumParameters)
        {
            IVector minimazedVector = new Vector(initialParameters);
            IParametricFunction minfunc = function.Copy() as IParametricFunction;
            minfunc.Bind(new Vector(initialParameters));

            for (int c = 0; c < 10000; c++)
            {
                for (int i = 0; i < minimumParameters.Count; i++)
                {
                    initialParameters[i] = GetRandomNumber(minimumParameters[i], maximumParameters[i]);
                }

                function.Bind(initialParameters);

                if (objective.Value(function as IFunction) < objective.Value(minfunc as IFunction))
                {
                    minimazedVector = new Vector(initialParameters);
                    minfunc.Bind(minimazedVector);
                }

                if (c % 100 == 0)
                {
                    Console.WriteLine("functional = " + objective.Value(minfunc as IFunction));
                }
            }
            return minimazedVector;
        }

        private static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
