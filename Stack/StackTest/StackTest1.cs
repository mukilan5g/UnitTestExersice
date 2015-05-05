using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;
using System.Diagnostics;

namespace StackTest
{
    [TestClass]
    public class StackTest1
    {
        StackExercise stackObject = new StackExercise();

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void EmptyCheck()
        {
            stackObject.Push("mukilan");
            Assert.AreEqual("mukilan", stackObject.Pop());
            stackObject.Pop(); //Try to pop an empty stack
        }

        [TestMethod]
        public void TopCheck()
        {
            stackObject.Push("mukilan");
            Assert.AreEqual("mukilan", stackObject.Top());
            Assert.AreEqual("mukilan", stackObject.Top());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void EmptyPopCheck()
        {
            stackObject.Pop();
        }

        [TestMethod]
        public void NullCheck()
        {
            stackObject.Push("mukilan");
            stackObject.Push(null);
            Assert.AreEqual("mukilan", stackObject.Pop());
        }

        [TestMethod]
        public void AfterExceptionThrownCheck()
        {
            try
            {
                stackObject.Pop();
            }
            catch (IndexOutOfRangeException e) { }
            stackObject.Push("new");
            Assert.IsNotNull(stackObject.IsEmpty());
            Assert.AreEqual("new", stackObject.Top());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "you cant push anymore!!")]
        public void StackOverflowCheck()
        {
            stackObject.Push("mukilan");
            stackObject.Push("mukilan");
            stackObject.Push("mukilan");
            stackObject.Push("mukilan");
            stackObject.Push("mukilan");
            stackObject.Push("mukilan");
            stackObject.Push("mukilan");
            stackObject.Push("mukilan");
            stackObject.Push("mukilan");
            stackObject.Push("mukilan");
            //im calling it 11th time..
            stackObject.Push("mukilan");

        }

        /// <summary>
        /// <!--push value and check isempty is false -->
        /// </summary>
        [TestMethod]
        public void IsEmptyCheck_1()
        {
            stackObject.Push("first");
            Assert.IsFalse(stackObject.IsEmpty());
        }

        /// <summary>
        /// <!--pop that value and check isempty is true-->
        ///</summary>
        [TestMethod]
        public void IsEmptyCheck_2()
        {
            stackObject.Push("first");
            stackObject.Pop();
            Assert.IsTrue(stackObject.IsEmpty());
            
        }

        /// <summary>
        /// <!--push value and check the top ,then check isempty returns false.
        /// so we can assume top is not deleting the value only returning the top of the stack-->
        /// </summary>
        [TestMethod]
        public void IsEmptyCheck_3()
        {
            stackObject.Push("second");
            Assert.IsTrue(stackObject.Top() == "second");
            Assert.IsFalse(stackObject.IsEmpty());
        }

        /// <summary>
        /// <!--push two values and pop once and check isempty return false-->
        /// </summary>
        [TestMethod]
        public void IsEmptyCheck_4()
        {
            stackObject.Push("second");
            stackObject.Push("third");
            stackObject.Pop();
            Assert.IsFalse(stackObject.IsEmpty());
        }
    }
}
