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
        public static void MaxValueSorting(ref int[][] array)
        {
           CheckData(array);
           for (int i  = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    CompareMax(ref array[j], ref array[j + 1]);
                }
            }
        }

        /// <summary>
        /// Sort method Array by Mun value
        /// </summary>
        /// <param name="array"</param>
        /// <exception cref="ArgumentNullException">
        /// If array should not be represent as null array
        /// </exception>
        public static void MinValueSorting(ref int[][] array)
        {
            CheckData(array);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    CompareMin(ref array[j], ref array[j + 1]);
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
        public static void SumValueSorting(ref int[][] array)
        {
            CheckData(array);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    CompareSum(ref array[j], ref array[j + 1]);
                }
            }
        }

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
            if (sign == 0)
            {
                Swap(ref first, ref second);
                return;
            }
            else
            {
                return;
            }
        }

        private static void CompareMin(ref int[] first, ref int[] second)
        {
            int? temp = CheckForNuLL(first, second);
            if (temp != null)
            {
                SwapArrays(ref first, ref second, temp);
            }
            else
            {
                temp = Compare(first.Min(), second.Min());
                SwapArrays(ref first, ref second, (int)temp);
            }
        }

        private static void CompareMax(ref int[] first, ref int[] second)
        {
            int? temp = CheckForNuLL(first, second);
            if (temp != null)
            {
                SwapArrays(ref first, ref second, temp);
            }
            else
            {
                temp = Compare(first.Max(), second.Max());
                SwapArrays(ref first, ref second, (int)temp);
            }
        }

        private static void CompareSum(ref int[] first, ref int[] second)
        {
            int? temp = CheckForNuLL(first, second);
            if (temp != null)
            {
                SwapArrays(ref first, ref second, temp);
            }
            else
            {
                temp = Compare(first.Sum(), second.Sum());
                SwapArrays(ref first, ref second, (int)temp);
            }
        }

        private static int? CheckForNuLL(int[] first, int[] second)
        {
            if ((second == null && first == null) || (second == null))
            {
                return 1;
            }
            else if (first == null)
            {
                return 0;
            }
            else
            {
                return null;
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
