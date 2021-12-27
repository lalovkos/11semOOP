using System;
using System.Collections.Generic;
using Functionals;
using Functions;
using Optimizator;
using Utility;

namespace _11semOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();
            Test3();
        }

        private static void Test1()
        {
            Console.WriteLine("_________________________L1Linear______________________________");
            LinearFunction func = new LinearFunction();
            Vector parameters = new Vector(new double[] { 1, 1, 1, 1 });
            func.Bind(parameters as IVector);

            List<IVector> tmpList = new List<IVector>();
            tmpList.Add(new Vector(new double[] { 2, 1, 1 }));
            tmpList.Add(new Vector(new double[] { 1, 2, 1 }));
            tmpList.Add(new Vector(new double[] { 1, 1, 2 }));

            Vector pointsy = new Vector(new double[] {1,2,3});

            Matrix mat = new Matrix(tmpList);

            L1NormLinear obj = new L1NormLinear(mat, pointsy);

            var Opt = new Universal();
            Vector minpar = new Vector(new double[] { -10, -10, -10, -10 });
            Vector maxpar = new Vector(new double[] { 10, 10, 10, 10 });
            IVector minimazed = Opt.Minimize((IFunctional) obj, func, parameters, minpar, maxpar);
            Console.WriteLine(minimazed.ToString());

            func.Bind(minimazed);
            Console.WriteLine("MinfuncValue first point = " + func.Value(tmpList[0]));
            Console.WriteLine("Minfunctional = " + obj.Value(func));

        }
        private static void Test2()
        {
            Console.WriteLine("_________________________L1Poly______________________________");
            PolinomFunction func = new PolinomFunction();
            Vector parameters = new Vector(new double[] { 1, 1, 1, 1 });
            func.Bind(parameters as IVector);

            Vector pointsx = new Vector(new double[] { -1, 0, 1, 2 });
            Vector pointsy = new Vector(new double[] {  1, 4, 3, 2 });

            L1NormPolynom obj = new L1NormPolynom(pointsx, pointsy);

            var Opt = new Universal();
            Vector minpar = new Vector(new double[] { -5, -5, -5, -5 });
            Vector maxpar = new Vector(new double[] { 5, 5, 5, 5 });
            IVector minimazed = Opt.Minimize((IFunctional)obj, func, parameters, minpar, maxpar);
            Console.WriteLine(minimazed.ToString());

            func.Bind(minimazed);
            Console.WriteLine("MinfuncValue first point = " + func.Value(new Vector(new double[]{pointsx[0]} )));
            Console.WriteLine("Minfunctional = " + obj.Value(func));

        }
        private static void Test3()
        {
            Console.WriteLine("_________________________L2Poly______________________________");
            PolinomFunction func = new PolinomFunction();
            Vector parameters = new Vector(new double[] { 1, 1, 1, 1 });
            func.Bind(parameters as IVector);

            Vector pointsx = new Vector(new double[] { -1, 0, 1, 2 });
            Vector pointsy = new Vector(new double[] { 1, 4, 3, 2 });

            L2NormPolynom obj = new L2NormPolynom(pointsx, pointsy);

            var Opt = new Universal();
            Vector minpar = new Vector(new double[] { -5, -5, -5, -5 });
            Vector maxpar = new Vector(new double[] { 5, 5, 5, 5 });
            IVector minimazed = Opt.Minimize((IFunctional)obj, func, parameters, minpar, maxpar);
            Console.WriteLine(minimazed.ToString());

            func.Bind(minimazed);
            Console.WriteLine("MinfuncValue first point = " + func.Value(new Vector(new double[] { pointsx[0] })));
            Console.WriteLine("Minfunctional = " + obj.Value(func));
        }
    }
}