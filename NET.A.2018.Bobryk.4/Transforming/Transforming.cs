using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{   
    /// <summary>
    /// interface 
    /// </summary>
    public interface ITransforming
    {
        string Transform(double number);
        string[] TransformArray(double[] numbers);
    }

    /// <summary>
    /// Generic interface for transforming
    /// </summary>
    public interface ITransformer<TSource, TResult>
    {
        TResult Transform(TSource number);
    }

    /// <summary>
    /// Generic class for transforming
    /// </summary>
    public static class GenericTransforming
    {
        /// <summary>
        /// Generic transforming with using Interface
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="numbers"></param>
        /// <param name="transformer"></param>
        /// <returns></returns>
        public static TResult[] TranformTo<TSource, TResult>(TSource[] numbers, ITransformer<TSource, TResult> transformer)
        {
            CheckData<TSource>(numbers);

            TResult[] results = new TResult[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                results[i] = transformer.Transform(numbers[i]);
            }

            return results;
        }

        /// <summary>
        /// Generic transforming with using Delegate
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="numbers"></param>
        /// <param name="transform"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">if array null</exception>
        public static TResult[] TranformTo<TSource, TResult>(TSource[] numbers, Func<TSource, TResult> transform)
        {
            CheckData<TSource>(numbers);

            TResult[] results = new TResult[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                results[i] = transform(numbers[i]);
            }

            return results;
        }

        private static void CheckData<TSource>(TSource[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Array is invalid(null)");
            }
        }
    }

    /// <summary>
    /// Class for tranforming double to words
    /// </summary>
    public class DoubleToWords: ITransforming, ITransformer<double, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string Transform(double number) => TransformingToWords.TransformToWords(number);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
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
    }

    /// <summary>
    /// Class for transforming double to bits
    /// </summary>
    public class DoubleToBits : ITransforming, ITransformer<double, string>
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

    }
}
