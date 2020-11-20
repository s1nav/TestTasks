using System;

namespace task2
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var wordCalculator = new WordOccurrenceCalculator(input);
            wordCalculator.DisplayReport(10);
        }
    }
}
