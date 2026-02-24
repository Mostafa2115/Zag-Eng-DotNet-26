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
            List<string> words = ["apple", "fig", "banana", "kiwi","grape", "mango", "pear", "plum"];
            // 1. 
            var longWords = words.Where(w => w.Length > 4);
            Console.WriteLine("Words longer than 4 characters:");
            foreach (var word in longWords)
                Console.WriteLine(word);

            // 2. 
            var EIWords = words.Where((w, i) => i % 2 == 0);
            Console.WriteLine("\nWords at even indexes:");
            foreach (var word in EIWords)
                Console.WriteLine(word);

            // 3. 
            var LEIWords = words.Where((w, i) => w.Length > 4 && i % 2 == 0);
            Console.WriteLine("\nWords that are both longer than 4 characters and at even indexes:");
            foreach (var word in LEIWords)
                Console.WriteLine(word);

            // 4. 
            int MIinWords = longWords.ToList().FindIndex(w => w == "mango");
            Console.WriteLine($"\nIndex of 'mango' in long words: {MIinWords}");








        }

    }
}

