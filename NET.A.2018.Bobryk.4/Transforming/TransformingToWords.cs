using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleBitsToString;

namespace Transforming
{
    /// <summary>
    /// TransformingToWords Class that have method 
    /// for transform double number to string on human language
    /// </summary>
    public static class TransformingToWords
    {
        /// <summary>
        /// Transform double number to string on human language
        /// </summary>
        /// <param name ="number">
        ///  double number for transform
        /// </param>
        /// <returns>string on human language</returns>
        public static string TransformToWords(double number)
        {
            string[] dictionary = new string[] 
            {
                "zero", "one", "two", "three", "four",
                "five", "six", "seven", "eight", "nine"
            };
            char[] char_number = DoubleToCharArray(number);

            string result = string.Empty;

            for (int i = 0; i < char_number.Length; i++)
            {
                if (char_number[i].ToString() == ".")
                {
                    AddSymbol(ref result, "point");
                    continue;
                }

                if (char_number[i].ToString() == "-")
                {
                    AddSymbol(ref result, "minus");
                    continue;
                }
                else
                {
                    AddSymbol(ref result, dictionary[Convert.ToInt32(char_number[i]) - 48]);
                }
            }

            result = result.TrimEnd();
            return result;
        }

        /// <summary>
        /// Transform array of double to array of words
        /// </summary>
        /// <param name ="numbers">
        /// array of numbers to transform
        /// </param>
        /// <returns>array of string wits words</returns>
        public static string[] TransformArray(double[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Array is invalid(null)");
            }

            string[] result = { };
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = TransformToWords(numbers[i]);
            }

            return result;
        }
  
        private static void AddSymbol(ref string result, string symbol)
        {
            result += symbol + " ";
        }

        private static char[] DoubleToCharArray(double number)
        {
            string string_number = number.ToString("G");
            char[] char_number = string_number.ToCharArray();
                return char_number;
        }
    }
}
