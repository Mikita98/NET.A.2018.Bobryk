using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Validators;

namespace Matrix.SumManager
{
    public class StringMatrixAdder : IMatrixAdder<string[,]>
    {
        private string[,] resultMatrix;

        private int Number;

        private IValidator<string[,]> validator;

        public StringMatrixAdder(IValidator<string[,]> validator)
        {
            this.validator = validator;

        }

        public string[,] Sum(string[,] matrix1, string[,] matrix2)
        {
            CheckMatrix(matrix1);
            CheckMatrix(matrix2);
            IsMatrixEquals(matrix1, matrix2);

            this.Number = (int)Math.Sqrt(matrix1.Length);

            this.resultMatrix = new string[Number, Number];

            for (int i = 0; i < Number; i++)
            {
                for (int j = 0; j < Number; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return resultMatrix;
        }

        private void CheckMatrix(string[,] matrix)
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

        private void IsMatrixEquals(string[,] matrix1, string[,] matrix2)
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
