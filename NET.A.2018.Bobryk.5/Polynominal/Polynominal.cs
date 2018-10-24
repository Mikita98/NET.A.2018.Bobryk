using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynominal
{
    public class Polynominal
    {
        private static readonly double eps = 10e-5;

        readonly double[] coefficient;

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="coefficient">Polynomial coefficients</param>
        /// <exception cref="ArgumentNullException">
        /// If Parameters is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If Length less zero
        /// </exception>
        public Polynominal(params double[] polynomial_coefficients)
        {
            CheckData(polynomial_coefficients);
            coefficient = new double[polynomial_coefficients.Length];
            polynomial_coefficients.CopyTo(coefficient, 0);
        }

        /// <summary>
        /// Get power of Polynominal
        /// </summary>
        public int Power
        {
            get
            {
                return coefficient.Length - 1;
            }

        }

        public double this[int index]
        {
            get
            {
                return coefficient[index];
            }

            private set
            {
                coefficient[index] = value;
            }
        }


        public double[] Coefficient
        {
            get
            {
                return coefficient;
            }

        }

        /// <summary>
        /// Equals of two polynomial objects
        /// </summary>
        /// <param name="another">Object to compare with</param>
        /// <returns> Result of Equals </returns>
        public override bool Equals(object next)
        {
            if ((GetType() != next.GetType()) || (next == null))
            {
                return false;
            }
            else
            {
                return this == (Polynominal)next;
            }
        }

        /// <summary>
        /// Get hash code of polynomial
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                for (int i = 0; i < Power; i++)
                {
                    hash = hash * 23 + coefficient[i].GetHashCode();
                }

                return hash;
            }
        }

        /// <summary>
        /// Get string representation of polynomial
        /// </summary>
        /// <returns>String representation of polynomial</returns>
        public override string ToString()
        {
            string stringPolynom = string.Empty;

            int index = GetCoefficients().Length - 1;

            foreach (double coeff in GetCoefficients())
            {
                if (index == 0)
                {
                    stringPolynom = string.Concat(stringPolynom, $"{coeff}");
                }
                else
                {
                    stringPolynom = string.Concat(stringPolynom, $"{coeff}*x^{index}+");
                }

                index--;
            }

            return stringPolynom;
        }

        public static Polynominal operator *(Polynominal first, Polynominal second)
        {
            double[] shortNumber = first.GetCoefficients();
            double[] longNumber = second.GetCoefficients();

            double[] result = new double[shortNumber.Length + longNumber.Length - 1];

            for (int i = 0; i < shortNumber.Length; i++)
            {
                for (int j = 0; j < longNumber.Length; j++)
                {
                    result[i + j] += shortNumber[i] * longNumber[j];
                }
            }

            return new Polynominal(result);
        }

        public static Polynominal operator +(Polynominal first, Polynominal second)
        {
            (double[] shortNumber, double[] longNumber) sameArrays = MakeSameArray(first, second);

            double[] shortNumber = sameArrays.shortNumber;
            double[] longNumber = sameArrays.longNumber;

            double[] result = new double[longNumber.Length];

            for (int i = 0; i < longNumber.Length; i++)
            {
                result[i] = shortNumber[i] + longNumber[i];
            }

            return new Polynominal(result);
        }

        public static Polynominal operator -(Polynominal first, Polynominal second)
        {
            bool firstIsShortest = first.GetCoefficients().Length < second.GetCoefficients().Length;
            (double[] shortest, double[] longest) normalizedArrays = MakeSameArray(first, second);

            double[] shortest = normalizedArrays.shortest;
            double[] longest = normalizedArrays.longest;

            double[] result = new double[longest.Length];

            if (firstIsShortest)
            {
                for (int i = 0; i < longest.Length; i++)
                {
                    result[i] = shortest[i] - longest[i];
                }
            }
            else
            {
                for (int i = 0; i < longest.Length; i++)
                {
                    result[i] = longest[i] - shortest[i];
                }
            }

            return new Polynominal(result);
        }

        public static bool operator ==(Polynominal first, Polynominal second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }

            if (first.Power != first.Power)
            {
                return false;
            }

            if (ReferenceEquals(first, second))
            {
                return true;
            }

            for (int i = 0; i < first.coefficient.Length; i++)
            {
                if (!(Math.Abs(first[i] - second[i]) < eps))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(Polynominal first, Polynominal second)
        {
            return !(first == second);
        }

        private static (double[], double[]) MakeSameArray(Polynominal firstCoefficents, Polynominal secondCoefficents)
        {
            double[] first = firstCoefficents.GetCoefficients();
            double[] second = secondCoefficents.GetCoefficients();

            double[] longNumber = (first.Length >= second.Length) ? first : second;
            double[] shortNumber = (longNumber == first) ? second : first;

            double[] result = new double[longNumber.Length];
            Array.Copy(shortNumber, result, shortNumber.Length);

            int count = longNumber.Length - shortNumber.Length;
            count = count % result.Length;
            double[] temp = new double[result.Length];

            for (int i = result.Length - 1; i >= 0; i--)
            {
                temp[i] = result[(i - count + result.Length) % result.Length];
            }

            result = temp;

            return (result, longNumber);
        }

        private void CheckData(double[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "is invalid type null");
            }

            if (data.Length == 0)
            {
                throw new ArgumentException(nameof(data), "Length must be great then zero");
            }
        }

        private double[] GetCoefficients()
        {
            double[] array = new double[coefficient.Length];
            Array.Copy(coefficient, array, coefficient.Length);
            return array;
        }
    }
}
