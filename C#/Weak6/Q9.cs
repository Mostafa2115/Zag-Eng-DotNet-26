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
            List<int> nums = [1, 2, 3, 4, 5];
            var query = nums.Where(n => n > 2); 
            nums.Add(10);
            foreach (var n in query)
                Console.Write(n + " ");

            // Q:1
            // 3 4 5 10 , عشان ال query اتعدل عليها وضفنا 10 قبل م ننفذ ال loop 

            // Q:2
            // هيتنفّذ الكويري فورًا وهيخزن النتايج في ليست

            // Q:3
            // ToList(), ToArray(), and Count() 
        }

    }
}

