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
            var employees = new List<Employee>
            {
                new Employee { Name = "Ali", Department = "Engineering", Salary = 9000 },
                new Employee { Name = "Nada", Department = "HR", Salary = 9500 },
                new Employee { Name = "Sara", Department = "Marketing", Salary = 7200 },
                new Employee { Name = "Omar", Department = "Engineering", Salary = 6800 },
                new Employee { Name = "Laila", Department = "Finance", Salary = 5000 }
            };

            // 1. 
            var anonProjection = employees.Select(e => new { FullName = e.Name.ToUpper(), e.Salary }).ToList();
            Console.WriteLine("Anonymous Projection:");
            foreach (var item in anonProjection)
                Console.WriteLine($"Name: {item.FullName}, Salary: {item.Salary}");

            // 2. 
            var formattedStrings = employees.Select(e => $"{e.Name} works in {e.Department} — EGP {e.Salary:N0}").ToList();
            Console.WriteLine("\nFormatted Strings:");
            foreach (var str in formattedStrings)
                Console.WriteLine(str);

            // 3. 
            var rankedEmployees = employees.OrderByDescending(e => e.Salary).Select((e, index) => new 
                {
                    Rank = index + 1,
                    e.Name,
                    e.Salary
                }).ToList();
            Console.WriteLine("\nRanked Employees:");
            foreach (var emp in rankedEmployees)
                Console.WriteLine($"Rank {emp.Rank}: {emp.Name} with Salary {emp.Salary}");


            // bouns
            var employeesWithSeniority = employees.Select(e => new
                {
                    e.Name,
                    e.Department,
                    e.Salary,
                    SeniorityLevel = e.Salary >= 9000 ? "Senior" : e.Salary >= 7000 ? "Mid" : "Junior"
                }).ToList();
            Console.WriteLine("\nEmployees with Seniority Level:");
            foreach (var emp in employeesWithSeniority)
                Console.WriteLine($"{emp.Name} works in {emp.Department} with Salary {emp.Salary} — Seniority: {emp.SeniorityLevel}");


        }

    }
    class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}
