using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingGCD
{
    /// <summary>
    /// Finding GCD Euclid and Stein method
    /// </summary>
    public static class FindingGCD
    {
        /// <summary>
        /// Find GCD numbers from Euclid
        /// </summary>
        /// <param name ="numbers">
        /// numbers that need to find greatest common divisor
        /// </param>
        /// <returns>time and greatest common divisor</returns>
        public static Tuple<int, int> Euclid_GCD(params int[] numbers)
        {
            CheckArray(numbers);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            int gcd = Euclid(numbers);

            timer.Stop();

            int time = timer.Elapsed.Milliseconds;

            return Tuple.Create(gcd, time);
        }

        /// <summary>
        /// Find GCD numbers from Euclid
        /// </summary>
        /// <param name ="numbers">
        /// numbers that need to find greatest common divisor
        /// </param>
        /// <returns>time and greatest common divisor</returns>
        public static Tuple<int, int> Stein_GCD(params int[] numbers)
        {
            CheckArray(numbers);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            int gcd = Stein(numbers);

            timer.Stop();

            int time = timer.Elapsed.Milliseconds;

            return Tuple.Create(gcd, time);
        }

        private static int Euclid(int num1, int num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            if (num1 == num2)
            {
                return num1;
            }

            if (num1 == 0)
            {
                return num2;
            }

            if (num2 == 0)
            {
                return num1;
            }

            while (num1 != num2)
            {
                if (num1 > num2)
                {
                    num1 = num1 - num2;
                }
                else
                {
                    num2 = num2 - num1;
                }
            }

            return num1;
        }

        private static int Stein(int num1, int num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            if (num1 == num2)
            {
                return num1;
            }

            if (num1 == 0)
            {
                return num2;
            }

            if (num2 == 0)
            {
                return num1;
            }

            if ((~num1 & 1) != 0)
            {
                if ((num2 & 1) != 0)
                {
                    return Stein(num1 >> 1, num2);
                }
                else
                {
                    return Stein(num1 >> 1, num2 >> 1) << 1;
                }
            }

            if ((~num2 & 1) != 0)
            {
                return Stein(num1, num2 >> 1);
            }

            if (num1 > num2)
            {
                return Stein((num1 - num2) >> 1, num2);
            }

            return Stein((num2 - num1) >> 1, num1);
        }

        private static int Stein(params int[] numbers)
        {
            int gdc = Stein(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                gdc = Stein(gdc, numbers[i]);
            }

            return gdc;
        }

        private static int Euclid(params int[] numbers)
        {
            int gdc = Euclid(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                gdc = Euclid(gdc, numbers[i]);
            }

            return gdc;
        }

        private static void CheckArray(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), "No Data");
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException(nameof(numbers), "Can't be less that 2 arguments");
            }
        }
    }
}
