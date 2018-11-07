using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    public interface ITransforming
    {
        string Transform(double number);
        string[] TransformArray(double[] numbers);
        string[] TransformArray(TransformingDelegate.Transforming transforming, double[] numbers);

    }

    public class DoubleToWords: ITransforming
    {
        public string Transform(double number) => TransformingToWords.TransformToWords(number);

        public string[] TransformArray(double[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Array is invalid(null)");
            }
            string[] result = { };
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Transform(numbers[i]);
            }

            return result;
        }

        public string[] TransformArray(TransformingDelegate.Transforming transforming, double[] numbers)
        => transforming(numbers);
    }

    public class DoubleToBits : ITransforming
    {
        public string Transform(double number) => DoubleBitsToString.DoubleBitsToString.DoubleToString(number);

        public string[] TransformArray(double[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Array is invalid(null)");
            }
            string[] result = { };
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Transform(numbers[i]);
            }

            return result;
        }

        public string[] TransformArray(TransformingDelegate.Transforming transforming, double[] numbers)
            => transforming(numbers);
    }
}
