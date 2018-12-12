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
        public readonly T[][] matrix;

        public SymmetricalMatrix(int number, IValidator<T[,]> validator)
        {
            CheckValidator(validator);
            this.Number = number;
            this.validator = validator;
            this.matrix = CreateMatrix(number);
        }

        public override void InsertElement(int row, int col, T value)
        {
            if (col < row)
            {
                this.matrix[col][row] = value;
            }
            else
            {
                this.matrix[row][col] = value;
            }
        }

        public override T this[int row, int col]
        {
            get
            {
                this.CheckValue(row, col);

                if ((row != col) && (col < row))
                {
                    return this.matrix[col][row];
                }
                else
                {
                    return this.matrix[row][col];
                }
            }

            set
            {
                this.CheckValue(row, col);

                this.InsertElement(row, col, value);

                this.OnChangeElement(row, col);
            }
        }

        private T[][] CreateMatrix (int number)
        {
            T[][] matrix = new T[number][];
            int i = 0;

            while (number >= 0)
            {
                matrix[i] = new T[number];
                number--;
                i++;
            }

            return matrix;
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
