using System;
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
        public static IVector Optimize(IFunctional objective, IParametricFunction function, IVector initialParameters,
            IVector minimumParameters, IVector maximumParameters, int maxIter = 10000)
        {
            IVector minimazedVector = new Vector(initialParameters);

            try //Trying to cast and find min functional 
            {
                IParametricFunction minfunc = function.Clone() as IParametricFunction;
                minfunc?.Bind(new Vector(initialParameters));

                for (int iter = 0; iter < maxIter; iter++)
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

                    if (iter % 100 == 0)
                    {
                        Console.WriteLine("functional = " + objective.Value(minfunc as IFunction));
                    }
                }

                return minimazedVector;
            }
            catch
            {
                Console.Write("Function is not IParametricFunction or null");
            }

            return null;
        }

        private static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }

}
