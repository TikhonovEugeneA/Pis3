using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pis3;

namespace PointsTests
{
    [TestClass]
    public class CountZeroesTests
    {
        [TestMethod]
        public void CountZeroes_WithNoZeroes()
        {
            string input = "1";
            int expected = 0;   
            int actual = TestClass.CountZeroes(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountZeroes_WithZeroesIncorrectResult()
        {
            string input = "11111";
            int expected = 1;
            int actual = TestClass.CountZeroes(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountZeroes_InvalidInputThrowsException()
        {
            string input = null;
            Assert.ThrowsException<ArgumentNullException>(()=> TestClass.CountZeroes(input));
        }
    }
}
