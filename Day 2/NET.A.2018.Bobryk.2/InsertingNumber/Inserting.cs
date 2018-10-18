using System;
using System.Collections;

namespace InsertingNumber
{
    public static class Inserting
    {
        /// <summary>
        /// InsertNumbers inserts bits from the first value into second value
        /// </summary>
        /// <param name ="val1"></param>
        /// <param name ="val2"></param>
        /// /// <param name ="i"></param>
        /// /// <param name ="j"></param>
        /// <returns>New number</returns>

        public static int InsertNumbers(int val1, int val2, int i, int j)
        {
            CheckDigits(val1, val2, i, j);

            int span = 2 << j - i;
            int length = span - 1;
            int bitMask = length << i;
            int val2shift = val1 << i;
            int number = (~bitMask & val1) | (bitMask & val2shift);
            return number;
        }

        private static void CheckDigits(int val1, int val2, int i, int j)
        {
            if ((i > 31) || (i < 0))
            {
                throw new ArgumentException(nameof(i));
            }

            if((j < 0) || (j > 31))
            {
                throw new ArgumentException(nameof(j));
            }

            if (i > j)
            {
                throw new ArgumentException(nameof(i),nameof(j));
            }
        }
    }
}
