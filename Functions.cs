using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
        interface IParametricFunction
        {
            IFunction Bind(IVector parameters);

        }

        interface IFunction
        {
            double Value(IVector point);
        }

        interface IDifferentiableFunction : IFunction
        {
            // По параметрам исходной IParametricFunction
            IVector Gradient(IVector point);
        }
    }
}
