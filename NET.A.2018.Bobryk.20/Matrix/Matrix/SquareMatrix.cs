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
        public readonly T[,] matrix;

        public SquareMatrix(int number, IValidator<T[,]> validator)
        {
            CheckValidator(validator);
            this.Number = number;
            this.validator = validator;
            this.matrix = new T[Number, Number];
        }


        public override void InsertElement(int row, int col, T value)
        {
            this.matrix[row, col] = value;
        }

        public override T this[int row, int col]
        {
            get
            {
                this.CheckValue(row, col);

                return this.matrix[row, col];
            }
            set
            {
                this.CheckValue(row, col);

                this.InsertElement(row, col, value);

                this.OnChangeElement(row, col);
            }
        }

        public override void CheckMatrix()
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix can't be null!");
            }

            if (!validator.Validate(matrix))
            {
                throw new ArgumentException("Matrix is invalid!");
            }
        }
    }
}
