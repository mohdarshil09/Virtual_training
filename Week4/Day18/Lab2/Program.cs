using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Marks { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Marks: {Marks}";
    }
}

class ByNameComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        return string.Compare(x.Name, y.Name,
            StringComparison.OrdinalIgnoreCase);
    }
}

class StudentRoster
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student s)
    {
        students.Add(s);
    }

    public void RemoveStudent(int id)
    {
        Student student = students.Find(s => s.Id == id);

        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine($"Student {id} removed.");
        }
        else
        {
            Console.WriteLine($"Student {id} not found.");
        }
    }

    public void UpdateMarks(int id, double newMarks)
    {
        Student student = students.Find(s => s.Id == id);

        if (student != null)
        {
            student.Marks = newMarks;
            Console.WriteLine($"Marks updated for student {id}.");
        }
        else
        {
            Console.WriteLine($"Student {id} not found.");
        }
    }

    public Student GetTopStudent()
    {
        return students.Count == 0
            ? null
            : students.MaxBy(s => s.Marks);
    }

    public void PrintRoster()
    {
        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }

    public void SortByMarksDescending()
    {
        students.Sort((a, b) =>
            b.Marks.CompareTo(a.Marks));
    }

    public void SortByNameAscending()
    {
        students.Sort(new ByNameComparer());
    }
}

class Lab2
{
    static void Main()
    {
        Console.WriteLine("===== LAB 2 =====");

        StudentRoster roster = new StudentRoster();

        roster.AddStudent(new Student
        {
            Id = 1,
            Name = "Rahul",
            Marks = 85
        });

        roster.AddStudent(new Student
        {
            Id = 2,
            Name = "Aman",
            Marks = 92
        });

        roster.AddStudent(new Student
        {
            Id = 3,
            Name = "Zoya",
            Marks = 78
        });

        roster.AddStudent(new Student
        {
            Id = 4,
            Name = "Karan",
            Marks = 88
        });

        Console.WriteLine("\nInitial Roster:");
        roster.PrintRoster();

        Console.WriteLine("\nUpdating Marks:");
        roster.UpdateMarks(3, 95);
        roster.PrintRoster();

        Console.WriteLine("\nRemoving Student:");
        roster.RemoveStudent(4);
        roster.PrintRoster();

        Console.WriteLine("\nTop Student:");
        Console.WriteLine(roster.GetTopStudent());

        Console.WriteLine("\nSorted by Marks Descending:");
        roster.SortByMarksDescending();
        roster.PrintRoster();

        Console.WriteLine("\nSorted by Name Ascending:");
        roster.SortByNameAscending();
        roster.PrintRoster();
    }
}