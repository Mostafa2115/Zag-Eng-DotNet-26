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

            List<Course> courses =
            [
                new("C# Basics",["Ali", "Sara", "Omar"]),
                new("LINQ Mastery", ["Sara", "Mona", "Ali"]),
                new("ASP.NET Core", ["Yara", "Omar", "Karim"]),
            ];
            // 1. 
            var allStudents = courses.SelectMany(c => c.Students);
            Console.WriteLine("All Students (with duplicates):");
            foreach (var student in allStudents)
                 Console.WriteLine(student);
            // 2. 
            var DStudents = courses.SelectMany(c => c.Students).Distinct();
            Console.WriteLine("\nDistinct Students:");
            foreach (var student in DStudents)
                Console.WriteLine(student);
            // 3. 
            var SIMCourses = courses.SelectMany(c => c.Students).GroupBy(s => s).Where(g => g.Count() > 1).Select(g => g.Key);
            Console.WriteLine("\nStudents in Multiple Courses:");
            foreach (var student in SIMCourses)
                Console.WriteLine(student);
            // 4. 
            var CSPairs = courses.SelectMany(
                c => c.Students,(course, student) => new { Course = course.Title, Student = student }
            );
            Console.WriteLine("\nCourse-Student Pairs:");
            foreach (var pair in CSPairs)
                Console.WriteLine($"{pair.Student} is enrolled in {pair.Course}");
        }

    }
}

class Course
{
    public string Title { get; set; }
    public List<string> Students { get; set; }

    public Course(string title, List<string> students)
    {
        Title = title;
        Students = students;
    }
}

