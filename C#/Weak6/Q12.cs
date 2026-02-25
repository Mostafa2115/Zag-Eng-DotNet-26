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
            // Q5
            var employees = new List<Employee>
            {
                new Employee { Name = "Ali", Department = "Engineering", Salary = 9000 },
                new Employee { Name = "Nada", Department = "HR", Salary = 9500 },
                new Employee { Name = "Sara", Department = "Marketing", Salary = 7200 },
                new Employee { Name = "Omar", Department = "Engineering", Salary = 6800 },
                new Employee { Name = "Laila", Department = "Finance", Salary = 5000 }
            };
            // Q11
            List<Course> courses =
            [
                new("C# Basics",["Ali", "Sara", "Omar"]),
                new("LINQ Mastery", ["Sara", "Mona", "Ali"]),
                new("ASP.NET Core", ["Yara", "Omar", "Karim"]),
            ];

            //1.
            var top2PerDept = employees
                .GroupBy(e => e.Department)
                .SelectMany(g => g.OrderByDescending(e => e.Salary).Take(2)).ToList();

            //2.
            var courseStudentCount = courses
                .Where(c => c.Students.Count > 2)
                .ToDictionary(c => c.Name, c => c.Students.Count);

            //3.
            bool anyEngineeringUnder8000 = employees
                .Where(e => e.Department == "Engineering")
                .Any(e => e.Salary < 8000);
            bool allHRAbove5500 = employees 
                .Where(e => e.Department == "HR")
                .All(e => e.Salary > 5500);

            //4.
            var rankedEmployees = employees
                .GroupBy(e => e.Department)
                .SelectMany(g => g.OrderByDescending(e => e.Salary)
                    .Select((e, index) => new
                    {
                        Rank = index + 1,
                        Name = e.Name,
                        Department = e.Department,
                        Salary = e.Salary,
                        SeniorityLevel = e.Salary
                    })).ToList();

            // 5.

            /* 
               1 - Deferred Execution 
               التنفيذ الفعلي حصل عند ToList()
               لأنها بتعمل materialization وبتنّفذ كل الـ pipeline مرة واحدة
               
               2 - Immediate Execution
               التنفيذ حصل عند ToDictionary()
               لأنها بتمر على العناصر فورًا وبتبني Dictionary

               3 - Immediate Execution
               التنفيذ حصل عند Any() و All()
               
               4 - Deferred Execution
               التنفيذ حصل عند ToList() في نهاية الـ pipeline
             */




        }

    }
}

class Course
{
public string Name { get; set; }
public List<string> Students { get; set; }
public Course(string name, List<string> students)
{
Name = name;
Students = students;
}
}
class Employee
{
public string Name { get; set; }
public string Department { get; set; }
public decimal Salary { get; set; }
}



