using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Validators;

namespace Matrix
{
    public class SymmetricalMatrix<T> : Matrix<T>
    {
        public SymmetricalMatrix(int number, IValidator<T[,]> validator) : base(number, validator)
        {}

        public SymmetricalMatrix(T[,] matrix, IValidator<T[,]> validator) : base(matrix, validator)
        {}

        public override void InsertElement(int row, int col, T value)
        {
            this.matrix[row, col] = value;

            if (row != col)
            {
                this.matrix[col, row] = value;
            }
        }
    }
}
