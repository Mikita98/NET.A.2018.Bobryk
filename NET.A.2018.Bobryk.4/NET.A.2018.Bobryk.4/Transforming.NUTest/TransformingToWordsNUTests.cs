using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Transforming.NUTest
{
    [TestFixture]
    public class TransformingToWordsNUTests
    {
        [Test]
        [TestCase(-2.4, ExpectedResult = "minus two point four")]
        [TestCase(0, ExpectedResult = "zero")]
        [TestCase(-10956.4567, ExpectedResult = "minus one zero nine five six point four five six seven")]
        [TestCase(100, ExpectedResult = "one zero zero")]
        [TestCase(.4, ExpectedResult = "zero point four")]
        [TestCase(+8, ExpectedResult = "eight")]
        [TestCase(143567.9087654, ExpectedResult = "one four three five six seven point nine zero eight seven six five four")]
        public string TranformingToWordsTest(double number)
        {
            string result = TransformingToWords.TransformToWords(number);
                return result;
        }
    }
}
