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
        public IVector Minimize(IFunctional objective, IParametricFunction function, IVector initialParameters, IVector minimumParameters = default, IVector maximumParameters = default) {

            IVector minimazedVector;


            if (objective is IDifferentiableFunctional)
            {
                //Метод Монте-карло(лучше алгоритм имитации отжига)
                annealing();

            }
            else if (objective is ILeastSquaresFunctional)
            {
                //Метод градиентного спуска (лучше метод сопряжённых градиентов)

            }
            else
            {
                //Алгоритм Гаусса-Ньютона
                solve(function, function, 0);
            }

            return minimazedVector;

        }


        public static double solve(IParametricFunction fx, IParametricFunction dfx, double x0)
        {
            double x1 = x0 - fx(x0) / dfx(x0); // первое приближение
            while (Math.Abs(x1 - x0) > 0.000001)
            { // пока не достигнута точность 0.000001
                x0 = x1;
                x1 = x0 - fx(x0) / dfx(x0); // последующие приближения
            }
            return x1;
        }

        public static double annealing(double energy, double newEnergy, double temperature)
        {
            acceptanceProbability(energy, newEnergy, temperature);
        }

        public static double acceptanceProbability(double energy, double newEnergy, double temperature)
        {
            // If the new solution is better, accept it
            if (newEnergy < energy)
            {
                return 1.0;
            }
            // If the new solution is worse, calculate an acceptance probability
            return Math.Exp((energy - newEnergy) / temperature);
        }

        while (temp > 1) {
            // Create new neighbour tour
            Tour newSolution = new Tour(currentSolution.getTour());

            // Get a random positions in the tour
            int tourPos1 = (int)(newSolution.tourSize() * Math.random());
            int tourPos2 = (int)(newSolution.tourSize() * Math.random());

            // Get the cities at selected positions in the tour
            City citySwap1 = newSolution.getCity(tourPos1);
            City citySwap2 = newSolution.getCity(tourPos2);

            // Swap them
            newSolution.setCity(tourPos2, citySwap1);
            newSolution.setCity(tourPos1, citySwap2);
 
            // Get energy of solutions
            double currentEnergy = currentSolution.getDistance();
            double neighbourEnergy = newSolution.getDistance();
 
            // Decide if we should accept the neighbour
            if (acceptanceProbability(currentEnergy, neighbourEnergy, temp) > Math.random()) {
                currentSolution = new Tour(newSolution.getTour());
            }
 
            // Keep track of the best solution found
            if (currentSolution.getDistance() < best.getDistance()) {
                best = new Tour(currentSolution.getTour());
            }

            // Cool system
            temp *= 1 - coolingRate;
        }

    }


}
