using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AreaCalc.Test
{
    public class CircleTests
    {
        [Test]
        public void Ctor_IncorrectInput_ThrowException()
        {
            Assert.Throws(typeof(ArgumentException), delegate { var circle = new Circle(-2); });
        }

        [Test]
        public void GetArea_CorrectInput_CorrectArea()
        {
            var circle = new Circle(5);
            Assert.AreEqual(78.54, Math.Round(circle.GetArea(), 2));
        }
    }
}
