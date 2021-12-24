using System;
using System.Collections.Generic;
using System.Threading;
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
        abstract string ToString();
        abstract IEnumerable<ValueTuple<int, Vector<double>>> EnumerateRowsIndexed();
        abstract public Vector<double> Row(int index);
    }

    class Matrix : IMatrix
    {
        private Matrix<double> _internalmatrix;

        Matrix(double[,] matrix)
        {
            _internalmatrix = DenseMatrix.OfArray(matrix);
        }

        public string ToString()
        {
            return _internalmatrix.ToString();
        }

        public IEnumerable<ValueTuple<int, Vector<double>>> EnumerateRowsIndexed()
        {
            return _internalmatrix.EnumerateRowsIndexed();
        }

        public Vector<double> Row(int index)
        {
            Vector<double> row = default;
            _internalmatrix.Row(index, row);
            return row;
        }

    }


}
