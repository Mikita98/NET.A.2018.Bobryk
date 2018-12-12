using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Matrix;
using Matrix.Validators;
namespace Matrix.SumManager
{
    public class IntMatrixAdder : IMatrixAdder<int>
    {
        private IValidator<int[,]> validator;

        private int Number;

        public IntMatrixAdder(IValidator<int[,]> validator)
        {
            this.validator = validator;

        }

        public void Sum (this SquareMatrix<int> matrix1, SquareMatrix<int> matrix2)
        {
            CheckMatrix(matrix1);
            CheckMatrix(matrix2);
            IsMatrixEquals(matrix1.Number, matrix2.Number);

            this.Number = matrix1.Number;

            SquareMatrix<int> resultMatrix = new SquareMatrix<int>(Number, new SquareValidator<int>);


            for (int i = 0; i < Number; i++)
            {
                for (int j = 0; j < Number; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            matrix1 = resultMatrix;
        }

        public SquareMatrix<int> Sum(this Matrix<int> matrix1, SymmetricalMatrix<int> matrix2)
        {
            CheckMatrix(matrix1);
            CheckMatrix(matrix2);
            IsMatrixEquals(matrix1, matrix2);

            this.Number = (int)Math.Sqrt(matrix1.Length);

            this.resultMatrix = new int[Number, Number];

            for (int i = 0; i < Number; i++)
            {
                for (int j = 0; j < Number; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return resultMatrix;
        }

        public SquareMatrix<int> Sum(this Matrix<int> matrix1, DiagonalMatrix<int> matrix2)
        {
            CheckMatrix(matrix1);
            CheckMatrix(matrix2);
            IsMatrixEquals(matrix1, matrix2.matrix);

            this.Number = (int)Math.Sqrt(matrix1.Length);

            this.resultMatrix = new int[Number, Number];

            for (int i = 0; i < Number; i++)
            {
                for (int j = 0; j < Number; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return resultMatrix;
        }

        private void CheckMatrix(Matrix<int> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix) + "can't be null!");
            }

            if (!validator.Validate(matrix.matrix))
            {
                throw new ArgumentException(nameof(matrix) + "is invalid!");
            }
        }

        private void IsMatrixEquals(int value1, int value2)
        {
            if (value1 != value2)
            {
                throw new ArgumentException("Matrices is't equal!");
            }
        }

    }
}
