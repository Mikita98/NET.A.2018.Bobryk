﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Validators;

namespace Matrix.Matrix
{
    public class DiagonalMarix<T> : Matrix<T> where T : IComparable<T>
    {
        public DiagonalMarix(int number, IValidator<T[,]> validator) : base(number, validator)
        { }

        public DiagonalMarix(T[,] matrix, IValidator<T[,]> validator) : base(matrix, validator)
        { }

        public override void InsertElement(int row, int col, T value)
        {
            if (row != col)
            {
                if (value.CompareTo(default(T)) != 0)
                {
                    throw new InvalidCastException($"Can't change element in this position.");
                }
            }

            this.matrix[row, col] = value;
        }
    }
}
