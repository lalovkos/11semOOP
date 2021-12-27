using System;
using System.Collections.Generic;

namespace Utility
{
    interface IVector : IList<double> , ICloneable
    {
        public string ToString();
    }

    class Vector : List<double>, IVector
    {
        public Vector()
        {

        }

        public Vector(double value)
        {
            Add(value);
        }

        public Vector(IVector vec)
        {
            foreach (var v in vec)
            {
                Add(v);
            }
        }

        public Vector(double[] mas)
        {
            foreach (var i in mas)
            {
                Add(i);
            }
        }

        public new string ToString()
        {
            string ret_string = String.Empty;
            for (int i = 0; i < Count; i++)
            {
                ret_string += this[i] + "; ";
            }
            return ret_string;
        }

        public object Clone(){
            return MemberwiseClone();
        }

}

    interface IMatrix : ICloneable
    {
        public IVector GetRow(int rowNumber);
    }

    class Matrix : IMatrix
    {
        private List<IVector> _internalmatrix;
       
        private List<IVector> matrix
        {
            get { return _internalmatrix; }
            set { _internalmatrix = value; }
        }

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
        
        public object Clone()
        {
            return MemberwiseClone();
        }

    }


}
