using System.Collections.Generic;

namespace task3
{
    public class PostfixNotationCalculator
    {
        public int Calculate(string input)
        {
            var numbers = new Stack<int>();

            foreach (var item in input.Split(' '))
            {
                if (int.TryParse(item, out int number))
                {
                    numbers.Push(number);
                }
                else
                {
                    var y = numbers.Pop();
                    var x = numbers.Pop();

                    switch (item)
                    {
                        case "+":
                            numbers.Push(x + y);
                            break;
                        case "-":
                            numbers.Push(x - y);
                            break;
                        case "*":
                            numbers.Push(x * y);
                            break;
                        case "/":
                            numbers.Push(x / y);
                            break;
                    }
                }
            }

            return numbers.Pop();
        }
    }
}
