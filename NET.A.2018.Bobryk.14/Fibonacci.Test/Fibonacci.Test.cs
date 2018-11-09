using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fibonacci.Test
{
    [TestFixture]
    public class FibaonacciTest
    {
        [TestCase(new long[] { 0, 1, 1, 2, 3 }, 5)]
        [TestCase(new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 }, 15)]
        public void FibonacciLength_ValidData_ValidResult(long[] array, int length)
        {
            List<long> expected = new List<long>();
            CreateList(ref expected, array);
            List<long> actual = new List<long>();
            FibonacciService service = new FibonacciService();
            actual = service.FibonacciByLength(length);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new long[] { 0, 1, 1, 2, 3 }, 5)]
        [TestCase(new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 }, 400)]
        public void FibonacciValue_ValidData_ValidResult(long[] array, long number)
        {
            List<long> expected = new List<long>();
            CreateList(ref expected, array);
            List<long> actual = new List<long>();
            FibonacciService service = new FibonacciService();
            actual = service.FibonacciByValue(number);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new long[] { 0, 1, 1, 2, 3 }, 7540113804746346430)]
        public void FibonacciValue_InValidData_ArgumentException(long[] array, long number)
        {
            FibonacciService service = new FibonacciService();
            Assert.Throws(typeof(ArgumentException), () => service.FibonacciByValue(number));
        }

        [TestCase(new long[] { 0, 1, 1, 2, 3 }, 10000)]
        public void FibonacciLength_InValidData_ArgumentException(long[] array, int length)
        {
            FibonacciService service = new FibonacciService();
            Assert.Throws(typeof(ArgumentException), () => service.FibonacciByLength(length));
        }

        private void CreateList(ref List<long> list, long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                list.Add(array[i]);
            }
        }
    }
}
