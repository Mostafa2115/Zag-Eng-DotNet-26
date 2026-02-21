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


            // 1. 
            var productsArray = products.ToArray();
            Console.WriteLine("Array length: " + productsArray.Length);

            // 2. 
            var productsDict = products.ToDictionary(p => p.Id);
            Console.WriteLine("Product with Id 2: " + productsDict[2].Name);

            // 3. 
            var productNamesSet = products.Select(p => p.Name).ToHashSet();
            Console.WriteLine("All product names in HashSet: " + string.Join(", ", productNamesSet));

            // 4. 
            var productsLookup = products.ToLookup(p => p.Category);
            Console.WriteLine("Electronics products:");
            foreach (var p in productsLookup["Electronics"])
                Console.WriteLine("- " + p.Name);

            /* 
            > ToDictionary:
                - Creates a dictionary with unique keys, Throws an exception if duplicate keys exist, Use when you expect only one item per key.
            > ToLookup:
                - Creates a lookup (like a dictionary but each key maps to a collection of values), Handles duplicate keys automatically by storing all values under the same key, Use when multiple items can share the same key.
            Exception behavior:
            > ToDictionary throws System.ArgumentException if keys are duplicated, ToLookup does NOT throw; duplicate keys are grouped under the same key.
            */


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
