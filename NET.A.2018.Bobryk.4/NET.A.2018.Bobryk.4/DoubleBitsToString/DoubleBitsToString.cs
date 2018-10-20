using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleBitsToString
{
    /// <summary>
    /// DoubleBitsToStrings Class transform double number to bits string
    /// </summary>
    public static class DoubleBitsToString
    {
        /// <summary>
        /// InsertNumbers inserts bits from the first value into second value
        /// </summary>
        /// <param name ="number">
        /// Double Number that need to to transform
        /// </param>
        /// <returns>string of bits</returns>
        public static string DoubleToString(double number)
        {
            if (number == 0.0)
            {
                return "0000000000000000000000000000000000000000000000000000000000000000";
            }

            if (number == -0.0)
            {
                return "1000000000000000000000000000000000000000000000000000000000000000";
            }

            if (number == double.PositiveInfinity)
            {
                return "0111111111110000000000000000000000000000000000000000000000000000";
            }

            if (number == double.NegativeInfinity)
            {
                return "1111111111110000000000000000000000000000000000000000000000000000";
            }

            if (number == double.Epsilon)
            {
                return "0000000000000000000000000000000000000000000000000000000000000001";
            }

            if (double.IsNaN(number))
            {
                return "1111111111111000000000000000000000000000000000000000000000000000";
            }

            string sign = CheckSign(number).ToString();
            if (sign == "1")
            {
                number = Math.Abs(number);
            }

            double offset = Math.Pow(2, 52);
            string number_offset_s = string.Empty;
            string e_s = string.Empty;
            double power = 0;
            if (number < 1)
            {
                e_s = "00000000000";
                number_offset_s = FindOffset(number);
            }
            else
            {
                power = CheckPower(number);
                double twoInPower = Math.Pow(2, power);
                double e = 1023 + power;
                double location = (number - twoInPower) / twoInPower;
                double number_offset = offset * location;
                number_offset_s = DoubleToBits(number_offset);

                e_s = DoubleToBits(e);
            }        
            
            string result = sign + e_s + number_offset_s;

            return result;
        }

        private static int CheckSign(double number)
        {
            if (number < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static int CheckPower(double number)
        {
            double n = Math.Truncate(number);
            int i = 0;
            while (n > 1)
            {
                n = Math.Truncate(n / 2);
                i++;
            }

            return i;
        }

        private static string FindOffset(double number)
        {
            double offset = number - Math.Truncate(number);
            string result = string.Empty;
            for (int i = 0; i < 52; i++)
            {
                offset *= 2;
                if (offset >= 1)
                {
                    result += "1";
                    offset -= 1;
                }
                else
                {
                    result += "0";
                }
            }

            return result; 
        }

        private static int CheckPowerLessOne(double number)
        {
            int i = 0;
            while (Math.Pow(2, i) < number)
            {
                i--;
            }
            return i;
        }

        private static string DoubleToBits(double number)
        {
            long n = (long)number;
            double remainder = 0;
            string result_rev = string.Empty;
            while (n > 0)
            {
                remainder = n % 2;
                n /= 2;
                result_rev += remainder.ToString();
            }

            char [] temp = result_rev.ToCharArray();
            Array.Reverse(temp);
            string result = string.Empty; 

            for(int i =0; i < result_rev.Length; i++)
            {
                result += temp[i].ToString();
            }
            return result;
        }
           
    }
}
