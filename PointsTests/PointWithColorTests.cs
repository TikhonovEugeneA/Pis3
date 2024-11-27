using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pis3;

namespace PointsTests
{
    [TestClass]
    public class PointWithColorTests
    {
        [TestMethod]
        public void PointWithColor_ShouldSetProperties()
        {
            //arrange
            var color = "Blue";
            var point = (111,111);
            //act
            Program.PointWithColor pointWithColor = new Program.PointWithColor(point, color);

            //assert
            ReferenceEquals(pointWithColor, "111;111 \"Blue\"");
        }

        [TestMethod]
        public void PointWithColor_AreEqual()
        {
            //arrange 
            (double?,double) point = (null,111);

            //act and assert
            Assert.AreEqual(point.Item1, null);
        }
    }
    
}
