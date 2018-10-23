using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggerNumber
{   
    /// <summary>
    /// FindingBiggerNumber Class that have method for find bigger number than yours
    /// </summary>
    public static class FindingBiggerNumber
    {
        /// <summary>
        /// InsertNumbers inserts bits from the first value into second value
        /// </summary>
        /// <param name ="number">
        /// Method find a number from digits contains in this argument
        /// </param>
        /// <returns>New number</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int FindNextBiggerNumber(int number)
        {
            CheckDigit(number);

            int[] array = IntToIntarray(number);

            int index = FindIndex(array);

            if (index == -1)
            {
                return -1;
            }

            if (index < array.Length - 1)
            {
                Switch(ref array[index], ref array[index + 1]);
                Array.Sort(array, index + 1, array.Length - index - 1);
            }

            int result = ArraytoInt(array);
            return result;
        }

        private static int FindIndex(int[] temp)
        {
            for (int i = temp.Length - 1; i > 0; i--)
            {
                if (temp[i] > temp[i - 1])
                {
                    return i - 1;
                }
            }

            return -1;
        }

        private static void Switch(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        private static void CheckDigit(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(nameof(number) + "is invalid. Number must be bigger than zero. ");
            }
        }

        private static int[] IntToIntarray(int number)
        {
            var digits = new List<int>();

            for (; number != 0; number /= 10)
            {
                digits.Add(number % 10);
            }

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }

        private static int ArraytoInt(int[] array)
        {
            string a = string.Empty;
            int output;
            foreach (int test in array)
            {
                a += test.ToString();
            }

            output = int.Parse(a);

            return output;
        }
    }
}
