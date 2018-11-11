using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Transforming.NUTest
{
    [TestFixture]
    public class TransformingToWordsTests
    {
        [TestCase(new double[1] { 4294967295.0 }, ExpectedResult = new string[1] { "0100000111101111111111111111111111111111111000000000000000000000" })]
        public string[] DoubleToBitsTransformDelegate_ValidData_ValidResult(double[] numbers)
        {
            DoubleToBits doubleToBits = new DoubleToBits();
            return GenericTransforming.TranformTo<double, string>(numbers, doubleToBits.Transform);
        }

        [TestCase(new double[2] { -2.4, 3.7 }, ExpectedResult = new string[2] { "minus two point four", "three point seven" })]
        public string[] DoubleToWordsTransformDelegate_ValidData_ValidResult(double[] numbers)
        {
            DoubleToWords doubleToWords = new DoubleToWords();
            return GenericTransforming.TranformTo<double, string>(numbers, doubleToWords.Transform);
        }

        [TestCase(new double[1] { 4294967295.0 }, ExpectedResult = new string[1] { "0100000111101111111111111111111111111111111000000000000000000000" })]
        public string[] DoubleToBitsTransformInterface_ValidData_ValidResult(double[] numbers)
        {
            return GenericTransforming.TranformTo<double, string>(numbers, new DoubleToBits());
        }

        [TestCase(new double[2] { -2.4, 3.7 }, ExpectedResult = new string[2] { "minus two point four", "three point seven" })]
        public string[] DoubleToWordsTransformInterface_ValidData_ValidResult(double[] numbers)
        {
            return GenericTransforming.TranformTo<double, string>(numbers, new DoubleToWords());
        }
    }
}
