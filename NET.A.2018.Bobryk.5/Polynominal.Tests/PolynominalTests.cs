using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Polynominal.Tests
{
    [TestFixture]
    public class PolynominalTests
    {
        [TestCase(new double[] { 2, 4, 7 })]
        [TestCase(new double[] { 9, 5, 3 })]
        public void TestEqualsMethod_ValidData_ValidReult(double[] coefficients)
        {
            Polynominal first = new Polynominal(coefficients);
            Polynominal second = new Polynominal(coefficients);
            Polynominal third = new Polynominal(new double[] { 0, 0 });
            Assert.True(first != third);
            Assert.True(first == second);
            Assert.True(first.Equals(second));
        }

        [TestCase(new double[] { 9, 10, 7 }, ExpectedResult = "3*x^2+10*x^1+7")]
        [TestCase(new double[] { 4, 3, 2 }, ExpectedResult = "4*x^2+3*x^1+2")]
        [TestCase(new double[] { -9, 3, 6 }, ExpectedResult = "-9*x^2+3*x^1+6")]
        [TestCase(new double[] { 6, 2, -4 }, ExpectedResult = "6*x^2+2*x^1-4")]
        public string TestToString_ValidData_ValidResult(double[] coefficients)
        {
            Polynominal first = new Polynominal(coefficients);
            return first.ToString();
        }

        public void TestGetHashCode_SameObjects_ValiDResult()
        {
            Polynominal first = new Polynominal(new double[] { 6, 2, 1 });
            Polynominal second = new Polynominal(new double[] { 6, 2, 1 });
            Assert.IsTrue(first.GetHashCode() == second.GetHashCode());
        }

        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 2, 4 }, ExpectedResult = new double[] { 4, 5, 8 })]
        [TestCase(new double[] { 1, 9, -3 }, new double[] { 9, 6, 2 }, ExpectedResult = new double[] { 10, 15, -1 })]
        [TestCase(new double[] { -1, -9, 3 }, new double[] { -9, -6, -2 }, ExpectedResult = new double[] { -10, -15, 1 })]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 5, 2, 2, 4 }, ExpectedResult = new double[] { 5, 2, 2, 4 })]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 0, -9, 4 }, ExpectedResult = new double[] { 2, -6, 8 })]
        public double[] TestPlus_ValidData_ValidResult(double[] coefficent1, double[] coefficent2)
        {
            Polynominal first = new Polynominal(coefficent1);
            Polynominal second = new Polynominal(coefficent2);
            Polynominal result =  first + second;
            return result.Coefficient;
        }

        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 2, 4 }, ExpectedResult = new double[] { 0, 1, 0 })]
        [TestCase(new double[] { -2, -3, 4 }, new double[] { 2, 2, 4 }, ExpectedResult = new double[] { -4,- 5, 0 })]
        [TestCase(new double[] { 7, 5, 8, 0 }, new double[] { 2, 2, 4 }, ExpectedResult = new double[] { 7, 3, 6, -4 })]
        public double[] TestMinus_ValidData_ValidResult(double[] coefficent1, double[] coefficent2)
        {
            Polynominal first = new Polynominal(coefficent1);
            Polynominal second = new Polynominal(coefficent2);
            Polynominal result = first - second;
            return result.Coefficient;
        }

        [TestCase(new double[] { 1, 1, 1 }, new double[] { 2, 2, 2 }, ExpectedResult = new double[] { 2, 4, 6, 4, 2 })]
        [TestCase(new double[] { 5, 3, 2, 1 }, new double[] { 4, 7, 8 }, ExpectedResult = new double[] { 20, 47, 69, 42, 23, 8 })]
        public double[] TestMultiplication_ValidData_ValidResult(double[] coefficent1, double[] coefficent2)
        {
            Polynominal first = new Polynominal(coefficent1);
            Polynominal second = new Polynominal(coefficent2);
            Polynominal result = first * second;
            return result.Coefficient;
        }

    }
}
