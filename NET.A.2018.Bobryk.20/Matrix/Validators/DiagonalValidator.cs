using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Validators
{
    public class DiagonalValidator<T> : SquareValidator<T>, IValidator<T[,]> where T : IComparable<T>
    {
        bool IValidator<T[,]>.Validate(T[,] matrix)
        {
            if (!IsSquare(matrix))
            {
                return false;
            }

            int N = (int)Math.Sqrt(matrix.Length);
            return IsDiagonal(matrix, N);
        }

        private bool IsDiagonal(T[,] matrix, int N)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if ((i != j) && (matrix[i, j].CompareTo(default(T)) != 0))
                        return false;
            return true;
        }
    }
}
