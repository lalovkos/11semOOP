using System;
using System.Collections.Generic;
using System.Net.Http;
using Functions;
using Utility;

namespace _11semOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            IVector par = new Vector();
            IParametricFunction func = new LinearFunction();
            func.Bind(par);

        }
    }
}