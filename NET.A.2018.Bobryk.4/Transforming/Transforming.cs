using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{  
    /// <summary>
    /// Main satic class for Transforming
    /// </summary>
    public static class Transforming
    {
        public delegate string NotGenericTransform(double number);

        /// <summary>
        /// Generic transforming with using Interface
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="numbers"></param>
        /// <param name="transformer"></param>
        /// <returns></returns>
        public static TResult[] Filter<TSource, TResult>(TSource[] numbers, ITransformer<TSource, TResult> transformer)
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
        public static TResult[] Filter<TSource, TResult>(TSource[] numbers, Func<TSource, TResult> transform)
        {
            CheckData<TSource>(numbers);

            TResult[] results = new TResult[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                results[i] = transform(numbers[i]);
            }

            return results;
        }

        /// <summary>
        /// Transform array of double to array of string with using delegate
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="notGenericTransform"></param>
        /// <returns></returns>
        public static string[] Transform(double[] numbers, NotGenericTransform notGenericTransform)
        {
            CheckData<double>(numbers);

            string[] result = new string[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = notGenericTransform(numbers[i]);
            }

            return result;
        }

        /// <summary>
        /// Transform array of double to array of string with using Interface
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="transforming"></param>
        /// <returns></returns>
        public static string[] Transform(double[] numbers, ITransforming transforming)
        {
            CheckData<double>(numbers);

            string[] result = new string[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = transforming.Transform(numbers[i]);
            }

            return result;
        }

        /// <summary>
        /// Checking input data
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="numbers"></param>
        private static void CheckData<TSource>(TSource[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Array is invalid(null)");
            }
        }
    }

}
