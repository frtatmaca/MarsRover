using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rower;

namespace TestRover
{
    [TestClass]
    public class TestRover
    {
        [TestMethod]
        public void TestMethod1()
        {
            Rover rover = new Rover(5, 5, 1, 2, "N", "LMLMLMLMM");
            Way lastPosition = rover.calculatePosition();
       
            string result = lastPosition.X + " " + lastPosition.Y + " " + lastPosition.Pole;
            Assert.AreEqual(result, "1 3 N");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Rover rover = new Rover(5, 5, 3, 3, "E", "MMRMMRMRRM");
            Way lastPosition = rover.calculatePosition();

            string result = lastPosition.X + " " + lastPosition.Y + " " + lastPosition.Pole;
            Assert.AreEqual(result, "5 1 E");
        }
    }
}
