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
        public static double FindNthRoot(double x, int n, double eps)
        {
            CheckDigits(n, x, eps);

            if (n == 1)
            {
                return x;
            }

            double n_double = (double)n;
            double x0 = x / n_double;
            double x1 = (1 / n_double) * (((n_double - 1) * x0) + (x / Power(x0, n - 1)));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n_double) * (((n_double - 1) * x0) + x / Power(x0, n - 1));
            }

            return x1;
        }

        private static double Power(double x, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= x;
            }

            return result;
        }

        private static void CheckDigits(int n, double x, double eps)
        {
            if(n <= 0)
            {
                throw new ArgumentException(nameof(n));
            }

            if ((x <= 0) && (n % 2 == 0))
            {
                throw new ArgumentException(nameof(x));
            }

            if (eps <= 0 || eps > 1)
            {
                throw new ArgumentException(nameof(eps));
            }
        }
    }
}
