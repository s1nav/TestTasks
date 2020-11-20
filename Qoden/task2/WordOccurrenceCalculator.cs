using System;
using System.Collections.Generic;
using System.Linq;

namespace task2
{
    public class WordOccurrenceCalculator
    {
        private string[] words;


        public Dictionary<string, int> WordOccurrence { get; private set; }


        public WordOccurrenceCalculator(string input)
        {
            words = input.Split(' ');
            WordOccurrence = words.GroupBy(w => w).ToDictionary(w => w.Key, w => w.Count());
        }


        public void DisplayReport(int frequencyColumnWidth)
        {
            var maxFrequency = WordOccurrence.OrderByDescending(w => w.Value).First().Value;
            var maxWordLength = words.OrderByDescending(w => w.Length).First().Length;

            foreach (var word in WordOccurrence.OrderBy(o => o.Value))
            {
                var underscoreCount = maxWordLength - word.Key.Length;
                var wordItem = new String('_', underscoreCount) + word.Key;

                var dotsCount = (int)Math.Round(((word.Value * (double)frequencyColumnWidth) / maxFrequency), 0, MidpointRounding.AwayFromZero);
                var dotsItem = new String('.', dotsCount);

                Console.WriteLine($"{wordItem} {dotsItem}");
            }
        }
    }
}
