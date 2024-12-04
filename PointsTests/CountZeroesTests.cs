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
            string input = "1101011";
            int expected = 2;
            int actual = TestClass.CountZeroes(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountZeroes_InvalidInputThrowsException()
        {
            string input = null;
            Assert.ThrowsException<ArgumentNullException>(()=> TestClass.CountZeroes(input));
        }
        [TestMethod]
        public void FindZeros()
        {
            //arrange 
            string input = "000110000111";
            int countZeros = 3;
           
            
            //act
            LengthNull lengthNull = new LengthNull();
            
            //assert
            Assert.AreEqual(countZeros, lengthNull.CounterZeros(input,'1'));

        }
    }
}
