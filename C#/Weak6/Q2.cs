using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new (1, "Laptop", 1200m, "Electronics"),
                new (2, "Phone", 800m, "Electronics"),
                new (3, "Desk", 350m, "Furniture"),
                new (4, "Chair", 150m, "Furniture"),
                new (5, "Headphones", 200m, "Electronics"),
            };
            // 1
            var firstE = products.Where(p => p.Category == "Electronics").FirstOrDefault();
            if (firstE != null)
                Console.WriteLine(firstE.Name);
            else
                Console.WriteLine("No Electronics item found.");

            // 2
            var lastP = products.Where(p => p.Price > 1000).LastOrDefault();
            if (lastP != null)
                Console.WriteLine(lastP.Name);
            else
                Console.WriteLine("No product with Price > 1000 found.");

            // 3
            var singleF = products.Where(p => p.Category == "Furniture" && p.Price > 300).SingleOrDefault();
            if (singleF != null)
                Console.WriteLine(singleF.Name);
            else
                Console.WriteLine("No single Furniture item with Price > 300 found (or multiple matches).");

            // 4
            var element3 = products.Find(p => p.Id == 3);
            if (element3 != null)
                Console.WriteLine(element3.Name);
            else
                Console.WriteLine("Element in index 3 not exist");

        }
    }

    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public string Category { set; get; }
        public Product(int id, string name, decimal price, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
