using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AreaCalc.Test
{
    public class FigureTests
    {
        [Test]
        public void GetArea_TriangleInput_CorrectArea()
        {
            var triangle = new Triangle(6, 8, 10);
            Assert.AreEqual(24, Figure.GetArea(triangle));
        }
    }
}
