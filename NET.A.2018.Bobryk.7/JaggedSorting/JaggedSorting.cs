using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorting
{
    public static class JaggedSorting
    {
        /// <summary>
        /// Sort method Array by Max value
        /// </summary>
        /// <param name="array"</param>
        /// <exception cref="ArgumentNullException">
        /// If array should not be represent as null array
        /// </exception>
        
        public static void Sort(this int[][] array, IComparer<int[]> compared)
        {
            CheckData(array);
            array.Sorting(compared.Compare);
        }

        public static void Sorting(this int[][] array, Comparison<int[]> compared)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    SwapArrays(ref array[j], ref array[j + 1], compared(array[j], array[j + 1]));
                }
            }
        }
 

        /// <summary>
        /// Sort method Array by Sum value
        /// </summary>
        /// <param name="array"</param>
        /// <exception cref="ArgumentNullException">
        /// If array should not be represent as null array
        /// </exception>

        private static void CheckData(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Null is invalid type for this array.");
            }
        }

        private static int Compare(int first, int second)
        {
            if (first >= second)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static void SwapArrays(ref int[] first, ref int[] second, int? sign)
        {
            if (sign == -1)
            {
                Swap(ref first, ref second);
                return;
            }
            else
            {
                return;
            }
        }

        private static void Swap(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
    }
}
