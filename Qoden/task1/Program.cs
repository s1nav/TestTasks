using System;

namespace task1
{
    class Program
    {
        static void Main()
        {
            var hashArg = Console.ReadLine();
            var inputString = Console.ReadLine();

            var hashTable = new HashTable(int.Parse(hashArg));

            foreach (var item in inputString.Split(' '))
            {
                var number = int.Parse(item);
                hashTable.Insert(number);
            }

            hashTable.Display();
        }
    }
}
