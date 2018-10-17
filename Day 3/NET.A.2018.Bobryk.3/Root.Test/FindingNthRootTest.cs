using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace Root.Test
{
    [TestClass]
    public class FindingNthRootTest
    {
        private TestContext testContextInstanse;

        public TestContext TestContext
        {
            get { return testContextInstanse; }
            set { testContextInstanse = value; }
        }

        //Download testing data from excel table
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV","|DataDirectory|\\FindingRootData.csv",
            "FindingRootData#csv", DataAccessMethod.Sequential), DeploymentItem("FindingRootData.csv")]
        public void FindNthRootTest_DataTable_ExpectedData()
        {
            //Arange
            double number = Double.Parse(TestContext.DataRow["Number"].ToString());
            int power = Int32.Parse(TestContext.DataRow["Power"].ToString());
            double eps = Double.Parse(TestContext.DataRow["Eps"].ToString());
            double expected = Double.Parse(TestContext.DataRow["Expected"].ToString());

            //Act
            double actual = FindingNthRoot.FindNthRoot(number, power, eps);

            //Assert
            Assert.AreEqual(actual, expected,eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRootTest_MinusPower_ArgumentException()
        {
            //Arrange
            double number = 0.001;
            int power = -2;
            double eps = 0.0001;

            //Act
            double actual = FindingNthRoot.FindNthRoot(number, power, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRootTest_MinusNumber_ArgumentException()
        {
            //Arrange
            double number = -0.01;
            int power = 2;
            double eps = 0.0001;

            //Act
            double actual = FindingNthRoot.FindNthRoot(number, power, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRootTest_MinusEpsilon_ArgumentException()
        {
            //Arrange
            double number = 0.01;
            int power = 2;
            double eps = -1;

            //Act
            double actual = FindingNthRoot.FindNthRoot(number, power, eps);
        }
    }
}
