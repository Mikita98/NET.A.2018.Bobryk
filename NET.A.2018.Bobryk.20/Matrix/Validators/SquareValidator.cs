using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Validators
{
    public class SquareValidator<T> : IValidator<T[,]> where T : IComparable<T>
    {
        public bool Validate(T[,] matrix)
        {
            return IsSquare(matrix);
        }

        protected bool IsSquare(T[,] matrix)
        {
            var value1 = Math.Sqrt(matrix.Length);
            int value2 = (int)Math.Sqrt(matrix.Length);
            return (value1 == value2);
        }
    }
}
