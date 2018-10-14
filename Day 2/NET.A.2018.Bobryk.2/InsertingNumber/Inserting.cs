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
            if ((i > 31) || (i < 0) || (j > 31) || (j < 0) || (j < i))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                BitArray val_1 = new BitArray(new int[] { val1 });
                BitArray val_2 = new BitArray(new int[] { val2 });
                int p = 0;

                for (int t = i; t <= j; t++)
                {
                    val_2[t] = val_1[p];
                    p++;
                }

                byte[] bytes = new byte[4];
                val_2.CopyTo(bytes, 0);
                int val3 = BitConverter.ToInt32(bytes, 0);
                return val3;
            }
        }
    }
}
