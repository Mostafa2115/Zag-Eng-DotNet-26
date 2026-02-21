using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> orders = new List<string>
            {
               "ORD-001",
               "ORD-002",
               "ORD-003",
               "ORD-004",
               "ORD-005",
               "ORD-006",
               "ORD-007"
            };

            int pageSize = 3;

            // 1. 
            var page1 = orders.Take(pageSize).ToList();
            Console.WriteLine("Page 1: " + string.Join(", ", page1));

            // 2. 
            var page2 = orders.Skip(pageSize).Take(pageSize).ToList();
            Console.WriteLine("Page 2: " + string.Join(", ", page2));

            // 3. 
            var last2Orders = orders.TakeLast(2).ToList();
            Console.WriteLine("Last 2 orders: " + string.Join(", ", last2Orders));

            // 4. 
            var middleOrders = orders.Skip(1).SkipLast(1).ToList();
            Console.WriteLine("Orders without first and last: " + string.Join(", ", middleOrders));

            // 5. bouns: Generic Paginate method
            var page3 = Paginate(orders, pageNumber: 3, pageSize: pageSize);
            Console.WriteLine("Page 3 using generic method: " + string.Join(", ", page3));


        }
        static List<T> Paginate<T>(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
