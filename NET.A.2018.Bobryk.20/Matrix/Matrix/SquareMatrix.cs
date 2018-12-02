using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Validators;

namespace Matrix.Matrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(int number, IValidator<T[,]> validator) : base(number, validator)
        { }

        public SquareMatrix(T[,] matrix, IValidator<T[,]> validator) : base(matrix, validator)
        { }

        public override void InsertElement(int row, int col, T value)
        {
            this.matrix[row, col] = value;
        }
    }
}
