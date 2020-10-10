using AreaCalc;
using System;
using System.Dynamic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle(5);
            Console.WriteLine(circle.GetArea());

            var triangle = new Triangle(6, 8, 10);
            Console.WriteLine(triangle.GetArea());
            Console.WriteLine(triangle.Right());

            Console.WriteLine(Figure.GetArea(triangle));

            Console.ReadLine();
        }
    }
}
