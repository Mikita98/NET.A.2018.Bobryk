﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class FibonacciValue
    {
        public const long FibonaciLongMax = 7540113804746346429;

        /// <summary>
        /// Calculates the Fibonacci sequence
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>IEnumerable of fibonacci numbers</returns>
        /// <exception cref="ArgumentException">
        /// Throw if numbers less or equals zero or bigger than maxValue
        /// </exception>
        public List<long> Generate(long number)
        {
            CheckData(number);

            long first_number = 0;
            long second_number = 1;
            List<long> list = new List<long>();
            list.Add(first_number);

            while (second_number < number)
            {
                ChangeNumbers(ref first_number, ref second_number);
                list.Add(first_number);
            }

            return list;
        }

        private static void CheckData(long number)
        {
            if (number <= 0)
            {
                throw new ArgumentException(nameof(number), "can`t be less or equls zero");
            }

            if (number > FibonaciLongMax)
            {
                throw new ArgumentException(nameof(number), "can`t be more than max number of long");
            }
        }

        private static void ChangeNumbers(ref long first, ref long second)
        {
            long temp = first;
            first = second;
            second = second + temp;
            CheckData(second);
        }
    }
}
