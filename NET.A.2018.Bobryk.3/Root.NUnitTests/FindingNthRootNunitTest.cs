using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Root.NUnitTests
{
    [TestFixture]
    public class FindingNthRootNunitTest
    {
        [Test]
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRootTest_DataTable_ExpectedData(double number, int power, double eps, double expected)
        {
            double actual = FindingNthRoot.FindNthRoot(number, power, eps);

            Assert.AreEqual(actual, expected, eps);
        }

        [Test]
        public void FindNthRootTest_MinusPower_ArgumentException()
        {
            double number = 0.001;
            int power = -2;
            double eps = 0.0001;

            Assert.Throws<ArgumentException>(() => 
                FindingNthRoot.FindNthRoot(number, power, eps));
        }

        [Test]
        public void FindNthRootTest_MinusNumber_ArgumentException()
        {
            double number = -0.01;
            int power = 2;
            double eps = 0.0001;

            Assert.Throws<ArgumentException>(() =>
                FindingNthRoot.FindNthRoot(number, power, eps));
        }

        [Test]
        public void FindNthRootTest_MinusEpsilon_ArgumentException()
        {
            double number = 0.01;
            int power = 2;
            double eps = -1;

            Assert.Throws<ArgumentException>(() =>
                FindingNthRoot.FindNthRoot(number, power, eps));
        }
    }
}
