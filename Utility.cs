using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace Utility
{

    interface IVector : IList<double>
    {
        public new string ToString();
    }

    class Vector : List<double>, IVector
    {
        public Vector()
        {
        }

        public Vector(IVector vec)
        {
            foreach (var v in vec)
            {
                this.Add(v);
            }
            
        }

        public Vector(double[] mas)
        {
            foreach (var i in mas)
            {
                this.Add(i);
            }
        }

        public new string ToString()
        {
            string sumstr = default;
            for (int i = 0; i < this.Count; i++)
            {
                sumstr += this[i] + " ";
            }

            return sumstr;
        }

        public void Push_back(double element) 
        {
            this.Add(element);
        }
    }

    interface IMatrix
    {
        public IVector GetRow(int rowNumber);

    }

    class Matrix : IMatrix
    {
        private List<IVector> _internalmatrix;

        public IVector this[int index]
        {
            get
            {
                return _internalmatrix[index];
            }
            set
            {
                _internalmatrix[index] = value;
            }

        }

        public Matrix(List<IVector> matrix)
        {
            _internalmatrix = matrix;
        }

        public IVector GetRow(int rowNumber)
        {
            return _internalmatrix[rowNumber];
        }
    }


}
