using System;
using System.Collections;

namespace InsertingNumber
{
    public static class Inserting
    {
        /// <summary>
        /// InsertNumbers inserts bits from the first value into second value
        /// </summary>
        /// <param name ="value1"></param>
        /// <param name ="value2"></param>
        /// /// <param name ="left"></param>
        /// /// <param name ="right"></param>
        /// <returns>New number</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int InsertNumbers(int value1, int value2, int left, int right)
        {
            CheckDigits(value1, value2, left, right);

            int span = 2 << (left - right);
            int length = span - 1;
            int bitMask = length << left;
            int val2shift = value1 << left;
            int number = (~bitMask & value1) | (bitMask & val2shift);
            return number;
        }

        private static void CheckDigits(int value1, int value2, int left, int right)
        {
            if ((left > 31) || (left < 0))
            {
                throw new ArgumentException(nameof(left) + "is invallid left border. It must be between 0 and max bit and less then right border");
            }

            if ((right < 0) || (right > 31))
            {
                throw new ArgumentException(nameof(right) + "is invallid right border.It must be between 0 and max bit and bigger then left border");
            }

            if (left > right)
            {
                throw new ArgumentException(nameof(left), nameof(right) + "are invalid borders.Right border must be bigger than left border");
            }
        }
    }
}
