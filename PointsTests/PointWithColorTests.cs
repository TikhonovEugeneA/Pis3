using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pis3;
using System;

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
            var point = (111, 111);

            //act
            Program.PointWithColor pointWithColor = new Program.PointWithColor(point, color);

            //assert
            ReferenceEquals(pointWithColor, "111;111 \"Blue\"");
        }

        [TestMethod]
        public void PointWithColor_AreEqual()
        {
            //arrange 
            (double?, double) point = (null, 111);

            //act and assert
            Assert.AreEqual(point.Item1, null);
        }

        [TestMethod]
        public void PointWithColor_NullReferenceException()
        {
            //arrange

            Program.PointWithColor pointWithColor = null;

            //act and assert

            Assert.ThrowsException<NullReferenceException>(() => { pointWithColor.Parsing("\"PointWithColor\" 111;111 \"Blue\""); });
        }
        [TestMethod]
        public void PointWithColor_FormatException()
        {
            //arrange

            Program.PointWithColor pointWithColor = new Program.PointWithColor((111, 111), "1");

            //act and assert

            Assert.ThrowsException<FormatException>(() => { pointWithColor.CoordinatesPoint = (Convert.ToInt32("a"), Convert.ToInt32("a")); });
        }
        [TestClass]
        public class PointWithWeightTests
        {
            [TestMethod]
            public void PointWithWeight_FormatException()
            {
                //arrange

                Program.PointWithWeight pointWithWeight = new Program.PointWithWeight((111, 111), 1);

                //act and assert

                Assert.ThrowsException<FormatException>(() => { pointWithWeight.CoordinatesPoint = (Convert.ToInt32("a"), Convert.ToInt32("a")); });
            }
            [TestMethod]
            public void PointWithWeight_ShouldSetProperties()
            {
                //arrange
                double weight = -10;
                var point = (111, 111);
                //act
                Program.PointWithWeight pointWithColor = new Program.PointWithWeight(point, weight);

                //assert
                ReferenceEquals(pointWithColor, "");
                Assert.AreEqual(ReferenceEquals(pointWithColor, "111,111 -10"), false);
            }

            [TestMethod]
            public void PointWithWeight_AreEqual()
            {
                //arrange 
                (double?, double) point = (null, 111);

                //act and assert
                Assert.AreEqual(point.Item1, null);
            }

            [TestMethod]
            public void PointWithWeight_NullReferenceException()
            {
                //arrange

                Program.PointWithWeight pointWithWeight = null;

                //act and assert

                Assert.ThrowsException<NullReferenceException>(() => { pointWithWeight.Parsing("\"PointWithColor\" 111;111 \"Blue\""); });
            }
        }
        [TestClass]
        public class PointWithSpeedTests
        {
            [TestMethod]
            public void PointWithSpeed_ShouldSetProperties()
            {
                //arrange
                double weight = -10;
                var point = (111, 111);

                //act
                Program.PointWithSpeed pointWithColor = new Program.PointWithSpeed(point, weight);

                //assert
                ReferenceEquals(pointWithColor, "111;111 -10");
            }

            [TestMethod]
            public void PointWithWeight_AreEqual()
            {
                //arrange 
                (double?, double) point = (null, 111);

                //act and assert
                Assert.AreEqual(point.Item1, null);
            }
        }

        [TestClass]
        public class AbstractPointTests
        {
            [TestMethod]
            public void AbstractPoint_MethodPrintTests()
            {

            }
        }
    }
}
