﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggerNumber
{
    public static class FindingBiggerNumber
    {
        public static int FindNextBiggerNumber(int number)
        {
            CheckDigit(number);

            string number_s = number.ToString();
            int length = number_s.Length;
            int[] array = IntToIntarray(number, length);
            int max = array[array.Length - 1];
            int min = array.Length - 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] > array[max])
                {
                    int temp = array[i];
                    array[i] = array[min];
                    array[min] = temp;

                    Array.Sort(array, i - 2, array.Length - i + 1);
                    break;

                }
                else if (array[i] < array[min])
                {
                    array[min] = array[i];
                }
            }

            return number;
        }

            private static void CheckDigit(int number)
            {
                if (number < 0)
                {
                    throw new ArgumentException(nameof(number));
                }
            }

        private static int[] IntToIntarray(int number, int length)
        {
            int[] digitArray = new int[length];
            while (number != 0)
            {
                digitArray[0] = number % 10;
                number /= 10;
            }

            return digitArray;
        }
    }
}
