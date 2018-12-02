using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using Matrix.Validators;
namespace Matrix.SumManager
{
    public class IntMatrixAdder : IMatrixAdder<int[,]>
    {
        private int[,] resultMatrix;

        private int Number;

        private IValidator<int[,]> validator;

        public IntMatrixAdder(IValidator<int[,]> validator)
        {
            this.validator = validator;

        }

        public int[,] Sum (int[,] matrix1, int[,] matrix2)
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

        private void CheckMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix) + "can't be null!");
            }

            if (!validator.Validate(matrix))
            {
                throw new ArgumentException(nameof(matrix) + "is invalid!");
            }
        }

        private void IsMatrixEquals(int[,] matrix1, int[,] matrix2)
        {
            int value1 = (int)Math.Sqrt(matrix1.Length);
            int value2 = (int)Math.Sqrt(matrix2.Length);

            if (value1 != value2)
            {
                throw new ArgumentException("Matrices is't equal!");
            }
        }

    }
}
