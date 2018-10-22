using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\FindingRootData.csv",
            "FindingRootData#csv", DataAccessMethod.Sequential), DeploymentItem("FindingRootData.csv")]
        public void FindNthRootTest_DataTable_ExpectedData()
        {
            double number = double.Parse(TestContext.DataRow["Number"].ToString());
            int power = int.Parse(TestContext.DataRow["Power"].ToString());
            double eps = double.Parse(TestContext.DataRow["Eps"].ToString());
            double expected = double.Parse(TestContext.DataRow["Expected"].ToString());

            double actual = FindingNthRoot.FindNthRoot(number, power, eps);

            Assert.AreEqual(actual, expected, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRootTest_MinusPower_ArgumentException()
        {
            double number = 0.001;
            int power = -2;
            double eps = 0.0001;

            double actual = FindingNthRoot.FindNthRoot(number, power, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRootTest_MinusNumber_ArgumentException()
        {
            double number = -0.01;
            int power = 2;
            double eps = 0.0001;

            double actual = FindingNthRoot.FindNthRoot(number, power, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRootTest_MinusEpsilon_ArgumentException()
        {
            double number = 0.01;
            int power = 2;
            double eps = -1;

            double actual = FindingNthRoot.FindNthRoot(number, power, eps);
        }
    }
}
