using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomTypes;

namespace Queue.Test
{
    [TestFixture]
    public class QueueTest
    {

        [TestCase(new int[] { -5, 678, 67, 43 })]
        [TestCase(new int[] { -500, 678 })]
        [TestCase(new int[] { 22, 14, 25, 734, 98})]
        public void TakeCollectionTest_ValidResult(int[] expected)
        {
            Queue.Queue<int> actual = new Queue.Queue<int>(expected);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual.Dequeue());
            }
        }

        [Test]
        public void TwoCustomTypes_ContainInQueue()
        {
            Elements element1 = new Elements(1, "100");
            Elements element2= new Elements(12345, "12345");

            Queue.Queue<Elements> elementQueue = new Queue.Queue<Elements>();
            elementQueue.EnQueue(new Elements(1, "100"));
            elementQueue.EnQueue(element2);


            Assert.IsFalse(elementQueue.Contains(element1));
        }

        [Test]
        public void TwoCustomTypesIEquatable_ContainInQueue()
        {
            ElementsIEquatable element1 = new ElementsIEquatable(1, "100");
            ElementsIEquatable element2 = new ElementsIEquatable(1, "100");

            Queue.Queue<ElementsIEquatable> elementQueue = new Queue.Queue<ElementsIEquatable>();
            elementQueue.EnQueue(new ElementsIEquatable(1, "100"));
            elementQueue.EnQueue(element2);


            Assert.IsFalse(elementQueue.Contains(element1));
        }
    }
}
