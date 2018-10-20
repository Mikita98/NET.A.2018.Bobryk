using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FindingGCDTests
{
    [TestFixture]
    public class FindingGCDNUTests
    {
        [Test]
        [TestCase(1, 100, ExpectedResult = 1)]
        [TestCase(-5, 5, ExpectedResult = 5)]
        [TestCase(17, 3, ExpectedResult = 1)]
        [TestCase(6, 66, ExpectedResult = 6)]
        [TestCase(71, 25411681, ExpectedResult = 71)]
        public int EuclidGDC_ValidDataTwoArguments_ValidResult(int num1, int num2)
        {
            Tuple<int,int> GDC = FindingGCD.FindingGCD.Euclid_GCD(num1, num2);
            return GDC.Item1;
        }

        [Test]
        [TestCase(1, 100, ExpectedResult = 1)]
        [TestCase(-3, 5, ExpectedResult = 1)]
        [TestCase(-5, 5, ExpectedResult = 5)]
        [TestCase(-42, 30, ExpectedResult = 6)]
        [TestCase(17, 3, ExpectedResult = 1)]
        [TestCase(0, 66, ExpectedResult = 66)]
        [TestCase(71, 25411681, ExpectedResult = 71)]
        public int SteinGDC_ValidDataTwoArguments_ValidResult(int num1, int num2)
        {
            Tuple<int, int> GDC = FindingGCD.FindingGCD.Stein_GCD(num1, num2);
            return GDC.Item1;
        }

        [Test]
        [TestCase(1, 100, 1000, ExpectedResult = 1)]
        [TestCase(-5, 5, 25, ExpectedResult = 5)]
        [TestCase(0, 0, 8, ExpectedResult = 8)]
        [TestCase(6, 66, 42, ExpectedResult = 6)]
        [TestCase(71, 25411681, 5041, ExpectedResult = 71)]
        public int EuclidGDC_ValidDataThreeArguments_ValidResult(int num1, int num2, int num3)
        {
            Tuple<int, int> GDC = FindingGCD.FindingGCD.Euclid_GCD(num1, num2, num3);
            return GDC.Item1;
        }

        [Test]
        [TestCase(1, 100, 9, ExpectedResult = 1)]
        [TestCase(-3, 5, 7, ExpectedResult = 1)]
        [TestCase(-5, 5, 35, ExpectedResult = 5)]
        [TestCase(-42, 30, 66, ExpectedResult = 6)]
        [TestCase(17, 3, 5, ExpectedResult = 1)]
        [TestCase(0, 0, 666, ExpectedResult = 666)]
        [TestCase(71, 25411681, 5041, ExpectedResult = 71)]
        public int SteinGDC_ValidDataThreeArguments_ValidResult(int num1, int num2, int num3)
        {
            Tuple<int, int> GDC = FindingGCD.FindingGCD.Stein_GCD(num1, num2, num3);
            return GDC.Item1;
        }

        [Test]
        [TestCase(10, 100, 1000, 500, ExpectedResult = 10)]
        [TestCase(-5, 5, 25, 725, ExpectedResult = 5)]
        [TestCase(0, 0, 8, 8, ExpectedResult = 8)]
        [TestCase(666, 66, 42, 36, ExpectedResult = 6)]
        [TestCase(71, 25411681, 5041, 0, ExpectedResult = 71)]
        public int EuclidGDC_ValidDataFourArguments_ValidResult(int num1, int num2, int num3, int num4)
        {
            Tuple<int, int> GDC = FindingGCD.FindingGCD.Euclid_GCD(num1, num2, num3, num4);
            return GDC.Item1;
        }

        [Test]
        [TestCase(10, 100, 1000, 500, ExpectedResult = 10)]
        [TestCase(-5, 5, 25, 725, ExpectedResult = 5)]
        [TestCase(0, 0, 8, 8, ExpectedResult = 8)]
        [TestCase(666, 66, 42, 36, ExpectedResult = 6)]
        [TestCase(71, 25411681, 5041, 0, ExpectedResult = 71)]
        public int SteinGDC_ValidDataFourArguments_ValidResult(int num1, int num2, int num3, int num4)
        {
            Tuple<int, int> GDC = FindingGCD.FindingGCD.Stein_GCD(num1, num2, num3, num4);
            return GDC.Item1;
        }

        [TestCase]
        public void EuclidGCD_NullAray_ArgumentNullException()
           => Assert.Throws(typeof(ArgumentNullException), () => FindingGCD.FindingGCD.Euclid_GCD(null));

        [TestCase]
        public void SteinGCD_NullAray_ArgumentNullException()
           => Assert.Throws(typeof(ArgumentNullException), () => FindingGCD.FindingGCD.Stein_GCD(null));

        [TestCase]
        public void EuclidGCD_OneNumber_ArgumentException()
           => Assert.Throws(typeof(ArgumentException), () => FindingGCD.FindingGCD.Euclid_GCD(1));

        [TestCase]
        public void SteinGCD_OneNumber_ArgumentException()
           => Assert.Throws(typeof(ArgumentException), () => FindingGCD.FindingGCD.Stein_GCD(1));
    }
}
