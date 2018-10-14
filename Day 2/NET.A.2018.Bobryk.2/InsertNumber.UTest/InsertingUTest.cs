using System;
using NUnit.Framework;

namespace InsertNumber.UTest
{
    [TestFixture]
    public class InsertingUTest
    {
        [Test]
        public void InsertNumberMethod_OneAndTwo_3()
        {
            // Arrange
            int expected = 3;
            int val1 = 1;
            int val2 = 2;
            int i = 0;
            int j = 0;

            // Act
            int actual = InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertNumberMethod_TwoValuesOne_One()
        {
            // Arrange
            int val1 = 1;
            int val2 = 1;
            int i = 1;
            int j = 9;

            // Act
            int actual = InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j);
        }

        [Test]
        public void InsertNumberMethod_MinusOneAndTwo_3()
        {
            // Arrange
            int expected = 3;
            int val1 = -1;
            int val2 = 2;
            int i = 0;
            int j = 0;

            // Act
            int actual = InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertNumberMethod_InvalidIndexI_ArgumentOutOfRangeException()
        {
            // Arrange
            int val1 = 1;
            int val2 = 2;
            int i = -1;
            int j = 0;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j));
        }

        [Test]
        public void InsertNumberMethod_InvalidIndexJ_ArgumentOutOfRangeException()
        {
            // Arrange
            int val1 = 1;
            int val2 = 2;
            int i = 0;
            int j = -1;

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j));
        }

        [Test]
        public void InsertNumberMethod_InvalidIndexIBiggerJ_ArgumentOutOfRangeException()
        {
            // Arrange
            int val1 = 1;
            int val2 = 2;
            int i = 6;
            int j = 0;

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j));
        }
    }
}
