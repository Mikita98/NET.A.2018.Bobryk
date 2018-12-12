using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Validators;

namespace Matrix.Matrix
{
    public class DiagonalMatrix<T> : Matrix<T> where T : IComparable<T>
    {
        public readonly T[] matrix;

        public DiagonalMatrix(int number, IValidator<T[,]> validator)
        {
            CheckValidator(validator);
            this.Number = number;
            this.validator = validator;
            this.matrix = new T[Number];
        }


        public override void InsertElement(int row, int col, T value)
        {
            if (row != col)
            {
                if (value.CompareTo(default(T)) != 0)
                {
                    throw new InvalidCastException($"Can't change element in this position.");
                }
            }

            this.matrix[row] = value;
        }

        public override T this[int row, int col]
        {
            get
            {
                this.CheckValue(row, col);

                if (row != col)
                {
                    return default(T);
                }
                else
                {
                    return this.matrix[row];
                }
                
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
