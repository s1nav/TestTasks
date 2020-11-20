using System;

namespace task3
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var calculator = new PostfixNotationCalculator();

            Console.WriteLine(calculator.Calculate(input));
        }
    }
}
