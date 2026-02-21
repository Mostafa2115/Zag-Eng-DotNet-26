using System;
using System.Collections.Generic;
using LINQ3;

namespace TestCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 3, 18, 7, 42, 10, 5, 29, 14, 6, 100 };
            var result1 = numbers.Where(n => n % 2 == 0 && n > 10).Select(n => n).OrderDescending().ToList();
            var result2 = from num in numbers
                          where num % 2 == 0 && num > 10
                          orderby num descending
                          select num;
            foreach (var res in result1)
                Console.Write($"{res} ");
            Console.WriteLine();
            foreach (var res in result2)
                Console.Write($"{res} ");



        }
    }

}
