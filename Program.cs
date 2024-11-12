using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class student
{
    public string Name { get; set; }
    public int Score { get; set; }

    public student(string name, int score)
    {
        Name = name;
        Score = score;
    }
}

public delegate bool score(student student);

public class standard
{
    public static List<student> filter (List<student> students, score criteria)
    {
        return students.Where(s => criteria(s)).ToList();
    }

    public static double average(List<student> students)
    {
        return students.Average(s => s.Score);
    }
}

public static class StudentExtensions
{
    public static void PrintStudentList(this List<student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}: {student.Score}");
        }
    }

    public static student TopScorer(this List<student> students)
    {
        return students.OrderByDescending(s => s.Score).First();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var students = new List<student>
        {
            new student ("Alice", 85 ),
            new student ("Bob", 92),
            new student ("Charlie", 78),
            new student ("David", 98),
            new student ("Emily", 65)
        };

        Console.WriteLine("Passing Students:");
        standard.filter (students, s => s.Score >= 70).PrintStudentList();

        Console.WriteLine("\nFailing Students:");
        standard.filter (students, s => s.Score < 70).PrintStudentList();

        Console.WriteLine("\nAverage Score: " + standard.average(students));

        Console.WriteLine("\nTop Scorer: " + students.TopScorer().Name);
    }
}
