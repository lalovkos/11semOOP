using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Utility
{

    interface IVector : IList<double>
    {
        abstract void Push_back(double element);
    }

    class Vector : List<double>, IVector
    {
        public void Push_back(double element) 
        {
            this.Add(element);
        }
    }
    interface IMatrix
    {
    }

    class Matrix: IMatrix
    {
        private Matrix<double> _internalmatrix;

        Matrix(List<List<double>> i) 
        { 
            
        } 
    }


}
