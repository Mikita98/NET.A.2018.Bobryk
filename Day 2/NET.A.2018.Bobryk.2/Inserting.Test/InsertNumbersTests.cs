using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inserting.Test
{
    [TestClass]
    public class InsertNumbersTests
    {
        [TestMethod]
        public void InsertNumberMethod_FifteenAndNine_Nine()
        {
            // Arrange
            int expected = 9;
            int val1 = 9;
            int val2 = 15;
            int i = 0;
            int j = 0;

            // Act
            int actual = InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberMethod_InvalidIndexI_ArgumentOutOfRangeException()
        {
            // Arrange
            int val1 = 2;
            int val2 = 1;
            int i = -1;
            int j = 0;

            // Act
            int actual = InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberMethod_InvalidIndexJ_ArgumentOutOfRangeException()
        {
            // Arrange
            int val1 = 1;
            int val2 = 2;
            int i = 0;
            int j = -1;

            // Act
            int actual = InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberMethod_InvalidIndexIBiggerJ_ArgumentOutOfRangeException()
        {
            // Arrange
            int val1 = 1;
            int val2 = 2;
            int i = 6;
            int j = 0;

            // Act
            int actual = InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j);
        }

        [TestMethod]
        public void InsertNumberMethod_FifteenOneAndfiifteen_3()
        {
            // Arrange
            int expected = 15;
            int val1 = 15;
            int val2 = 15;
            int i = 0;
            int j = 0;

            // Act
            int actual = InsertingNumber.Inserting.InsertNumbers(val1, val2, i, j);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
