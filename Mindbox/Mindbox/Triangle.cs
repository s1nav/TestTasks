using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AreaCalc
{
    public class Triangle : IFigure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }


        public Triangle (double sideA, double sideB, double sideC)
        {
            if (CanConstructTriangle(sideA, sideB, sideC))
            {
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }
            else
            {
                throw new ArgumentException();
            }
        }


        public double GetArea()
        {
            var halfPerimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
        }

        public bool Right()
        {

            if (SideA > SideB && SideA > SideC)
            {
                return Math.Pow(SideA, 2) == Math.Pow(SideB, 2) + Math.Pow(SideC, 2);
            }
            else if (SideB > SideA && SideB > SideC)
            {
                return Math.Pow(SideB, 2) == Math.Pow(SideA, 2) + Math.Pow(SideC, 2);
            }
            else
            {
                return Math.Pow(SideC, 2) == Math.Pow(SideA, 2) + Math.Pow(SideB, 2);
            }
        }


        private bool CanConstructTriangle(double sideA, double sideB, double sideC)
        {
            var sides = new double[] { sideA, sideB, sideC };
            return sides.Max() < sides.Sum() - sides.Max();
        }
    }
}
