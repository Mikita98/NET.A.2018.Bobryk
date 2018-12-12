using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Matrix;
using Matrix.Validators;

namespace Matrix.SumManager
{
    public static class MatrixOperations
    {
        private static int Number { get; set; }

        public static void Sum<T>(this SquareMatrix<T> matrix1, SquareMatrix<T> matrix2) where T : IComparable
        {
            matrix1.CheckMatrix();
            matrix2.CheckMatrix();

            IsMatrixEquals(matrix1.Number, matrix2.Number);

            Number = matrix1.Number;

            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(Number, new SquareValidator<T>);


            for (int i = 0; i < Number; i++)
            {
                for (int j = 0; j < Number; j++)
                {
                    resultMatrix[i, j] = (dynamic)matrix1[i, j] + (dynamic)matrix2[i, j];
                }
            }

            matrix1 = resultMatrix;
        }

        public static void Sum<T>(this SquareMatrix<int> matrix1, SymmetricalMatrix<int> matrix2) where T: IComparable
        {
            matrix1.CheckMatrix();
            matrix2.CheckMatrix();

            IsMatrixEquals(matrix1.Number, matrix2.Number);

            Number = matrix1.Number;

            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(Number, new SquareValidator<T>);

            for (int i = 0; i < Number; i++)
            {
                for (int j = 0; j < Number; j++)
                {
                    resultMatrix[i, j] = (dynamic)matrix1[i, j] + matrix2[i, j];
                }
            }

            return resultMatrix;
        }

        public static SquareMatrix<int> Sum(this Matrix<int> matrix1, DiagonalMatrix<int> matrix2)
        {
            matrix1.CheckMatrix();
            matrix2.CheckMatrix();
            IsMatrixEquals(matrix1.Number, matrix2.Number);

            this.Number = matrix1.Number;

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

        private static void IsMatrixEquals(int value1, int value2)
        {
            if (value1 != value2)
            {
                throw new ArgumentException("Matrices is't equal!");
            }
        }
    }
}
