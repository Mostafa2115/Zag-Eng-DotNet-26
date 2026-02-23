using LINQ3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> scores = new List<int> { 88, 92, 75, 60, 55, 80, 91, 45 };
            // 1. 
            var HScores = scores.TakeWhile(s => s >= 70).ToList();
            foreach (var score in HScores)
                Console.Write(score + " ");
            Console.WriteLine();
            // 2. 
            var LScores = scores.SkipWhile(s => s >= 70).ToList();
            foreach (var score in LScores)
                Console.Write(score + " ");

            // 3. 
            // TakeWhile and SkipWhile operate on the sequence until a condition fails,
            // whereas Where filters the entire sequence based on a condition
        }

    }
}
