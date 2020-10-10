using System;
using System.Collections.Generic;
using System.Text;

namespace AreaCalc
{
    public class Circle : IFigure
    {
        public double Radius { get; set; }


        public Circle(double radius)
        {
            if (radius > 0)
            {
                Radius = radius;
            }
            else
            {
                throw new ArgumentException();
            }
        }


        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

    }
}
