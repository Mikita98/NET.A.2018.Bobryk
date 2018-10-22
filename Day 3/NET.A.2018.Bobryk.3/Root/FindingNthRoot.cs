using System;

namespace Root
{
    /// <summary>
    /// FindingNthRoot Class that have method for find root from number
    /// </summary>
    public static class FindingNthRoot
    {
        /// <summary>
        /// InsertNumbers inserts bits from the first value into second value
        /// </summary>
        /// <param name ="x">
        /// Number that need to root
        /// </param>
        /// <param name ="n">
        /// Level of Root Power
        /// </param>
        /// <param name ="eps">
        /// Accuracy for root
        /// </param>
        /// <returns>New number</returns>
        /// /// <exception cref="ArgumentException"></exception>
        public static double FindNthRoot(double number, int power, double eps)
        {
            CheckDigits(power, number, eps);

            if (power == 1)
            {
                return number;
            }

            double previousNumber = number / power;
            double currentNumber = (1.0 / number) * (((power - 1) * previousNumber) + (number / Math.Pow(previousNumber, power - 1)));

            while (Math.Abs(currentNumber - previousNumber) > eps)
            {
                previousNumber = currentNumber;
                currentNumber = (1.0 / power) * (((power - 1) * previousNumber) + (number / Math.Pow(previousNumber, power - 1)));
            }

            return currentNumber;
        }

        private static void CheckDigits(int power, double number, double eps)
        {
            if (power <= 0)
            {
                throw new ArgumentException(nameof(power));
            }

            if ((number <= 0) && (power % 2 == 0))
            {
                throw new ArgumentException(nameof(number));
            }

            if (eps <= 0 || eps > 1)
            {
                throw new ArgumentException(nameof(eps));
            }
        }
    }
}
