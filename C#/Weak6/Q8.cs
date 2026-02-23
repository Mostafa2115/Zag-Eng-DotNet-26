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
            List<Employee> employees =
            [
                new("Ali","Engineering", 9000m),
                new("Sara","Engineering", 8500m),
                new("Omar","HR", 6000m),
                new("Mona","HR", 6200m),
                new("Yara","Marketing", 7000m),
                new("Karim","Marketing", 7500m),
                new("Nada","Engineering", 9500m),
            ];
            // 1. 
            var groupedByDepartment = employees.GroupBy(e => e.Department).Select(g => new
                                                                          {
                                                                               Department = g.Key,
                                                                               Count = g.Count(),
                                                                               AvgSalary = g.Average(e => e.Salary)
                                                                          });
            foreach (var group in groupedByDepartment)
                Console.WriteLine($"{group.Department} -> Count: {group.Count}, Avg: {group.AvgSalary}");


            // 2. 
            var HBDepartment = groupedByDepartment.OrderByDescending(g => g.AvgSalary).FirstOrDefault();
            if (HBDepartment != null)
                Console.WriteLine($"Highest Budget Department: {HBDepartment.Department} -> Avg: {HBDepartment.AvgSalary}");


            // 3. 
            var EByDepartment = employees.GroupBy(e => e.Department).Select(g => new
                                                                    {
                                                                        Department = g.Key,
                                                                        Employees = g.OrderByDescending(e => e.Salary)
                                                                    });
            foreach (var group in EByDepartment)
            {
                Console.WriteLine($"Department: {group.Department}");
                foreach (var emp in group.Employees)
                    Console.WriteLine($" - {emp.Name}: {emp.Salary}");
            }   
        }

    }
}

class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public Employee(string name, string department, decimal salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }
}
