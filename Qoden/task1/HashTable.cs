using System;

namespace task1
{
    public class HashTable
    {
        private readonly int hashArg;
        private Array<ListNode<int>> values;


        public HashTable(int hashArg)
        {
            values = new Array<ListNode<int>>(hashArg);
            this.hashArg = hashArg;
        }


        private int GetHash(int newValue)
        {
            return newValue % hashArg;
        }


        public void Insert(int newValue)
        {
            var hash = GetHash(newValue);

            if (values.Items[hash] == null)
            {
                values.Items[hash] = new ListNode<int>(newValue);
            }
            else
            {
                values.Items[hash].Insert(newValue);
            }
        }

        public void Display()
        {
            for (int i = 0; i < values.Items.Length; i++)
            {
                Console.WriteLine($"{i}: {values.Items[i]}");
            }
        }
    }
}
