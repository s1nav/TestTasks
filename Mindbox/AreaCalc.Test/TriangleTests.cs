using AreaCalc;
using NUnit.Framework;
using System;

namespace AreaCalc.Test
{
    public class TriangleTests
    {
        [Test]
        public void Ctor_IncorrectArgs_ThrowException()
        {
            Assert.Throws(typeof(ArgumentException), delegate { var triangle = new Triangle(20, 8, 10); });
        }

        [Test]
        public void GetArea_CorrectInput_CorrectArea()
        {
            var triangle = new Triangle(6, 8, 10);
            Assert.AreEqual(24, triangle.GetArea());
        }

        [Test]
        public void Right_CorrectInput_True()
        {
            var triangle = new Triangle(6, 8, 10);
            Assert.AreEqual(true, triangle.Right());
        }

        [Test]
        public void Right_IncorrectInput_False()
        {
            var triangle = new Triangle(6, 8, 11);
            Assert.AreEqual(false, triangle.Right());
        }
    }
}