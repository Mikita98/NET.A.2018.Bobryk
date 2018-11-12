using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Transforming.Test
{
    [TestFixture]
    public class TransformTest
    {
        [TestCase(new double[1] { 4294967295.0 }, ExpectedResult = new string[1] { "0100000111101111111111111111111111111111111000000000000000000000" })]
        public string[] DoubleToBitsTransformDelegate_ValidData_ValidResult(double[] numbers)
        {
            return Transforming.Transform(numbers, DoubleBitsToString.DoubleBitsToString.DoubleToString );
        }

        [TestCase(new double[2] { -2.4, 3.7 }, ExpectedResult = new string[2] { "minus two point four", "three point seven" })]
        public string[] DoubleToWordsTransformDelegate_ValidData_ValidResult(double[] numbers)
        {
            return Transforming.Transform(numbers, TransformingToWords.TransformToWords);
        }

        [TestCase(new double[1] { 4294967295.0 }, ExpectedResult = new string[1] { "0100000111101111111111111111111111111111111000000000000000000000" })]
        public string[] DoubleToBitsTransformInterface_ValidData_ValidResult(double[] numbers)
        {
            return Transforming.Transform(numbers, new BitsTransformingAdapter());
        }

        [TestCase(new double[2] { -2.4, 3.7 }, ExpectedResult = new string[2] { "minus two point four", "three point seven" })]
        public string[] DoubleToWordsTransformInterface_ValidData_ValidResult(double[] numbers)
        {
            return Transforming.Transform(numbers, new WordTransformingAdapter());
        }
    }

    [TestFixture]
    public class FilterTest
    {
        [TestCase(new double[1] { 4294967295.0 }, ExpectedResult = new string[1] { "0100000111101111111111111111111111111111111000000000000000000000" })]
        public string[] DoubleToBitsFilterDelegate_ValidData_ValidResult(double[] numbers)
        {
            return Transforming.Filter<double, string>(numbers, DoubleBitsToString.DoubleBitsToString.DoubleToString);
        }

        [TestCase(new double[2] { -2.4, 3.7 }, ExpectedResult = new string[2] { "minus two point four", "three point seven" })]
        public string[] DoubleToWordsFilterDelegate_ValidData_ValidResult(double[] numbers)
        {
            return Transforming.Filter<double, string>(numbers, TransformingToWords.TransformToWords);
        }

        [TestCase(new double[1] { 4294967295.0 }, ExpectedResult = new string[1] { "0100000111101111111111111111111111111111111000000000000000000000" })]
        public string[] DoubleToBitsFilterInterface_ValidData_ValidResult(double[] numbers)
        {
            return Transforming.Filter<double, string>(numbers, new BitsTransformerAdapter());
        }

        [TestCase(new double[2] { -2.4, 3.7 }, ExpectedResult = new string[2] { "minus two point four", "three point seven" })]
        public string[] DoubleToWordsFilterInterface_ValidData_ValidResult(double[] numbers)
        {
            return Transforming.Filter<double, string>(numbers, new WordTransformerAdapter());
        }
    }
}
