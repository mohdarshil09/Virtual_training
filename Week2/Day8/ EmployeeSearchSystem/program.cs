using System;
using System.Collections.Generic;

namespace EmployeeSearchSystem
{
    class Employee
    {
        public int Id; public string Name, Department, Designation, City;
        public int Experience; public double Salary;
        public Employee(int id, string name, string dept, string des, int exp, double sal, string city)
        { Id = id; Name = name; Department = dept; Designation = des; Experience = exp; Salary = sal; City = city; }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(1001,"Rahul Sharma","IT","Software Engineer",2,45000,"Chennai"),
            new Employee(1002,"Priya Singh","HR","HR Executive",3,40000,"Bangalore"),
            new Employee(1003,"Amit Kumar","Finance","Accountant",5,55000,"Hyderabad"),
            new Employee(1004,"Neha Patel","IT","Senior Developer",6,85000,"Pune"),
            new Employee(1005,"Arjun Reddy","Sales","Sales Executive",2,38000,"Chennai"),
            new Employee(1006,"Sneha Iyer","Marketing","Marketing Executive",4,52000,"Coimbatore"),
            new Employee(1007,"Karan Mehta","IT","Team Lead",8,95000,"Mumbai"),
            new Employee(1008,"Divya Nair","Support","Support Engineer",1,32000,"Kochi"),
            new Employee(1009,"Rohit Verma","IT","Software Engineer",3,50000,"Delhi"),
            new Employee(1010,"Anjali Gupta","Finance","Financial Analyst",4,65000,"Noida"),
            new Employee(1011,"Suresh Kumar","Admin","Administrator",7,58000,"Madurai"),
            new Employee(1012,"Pooja Sharma","HR","Recruiter",2,42000,"Bangalore"),
            new Employee(1013,"Vikram Das","IT","System Engineer",5,62000,"Chennai"),
            new Employee(1014,"Meena Joshi","Support","Technical Support",3,41000,"Trichy"),
            new Employee(1015,"Naveen Raj","Sales","Sales Manager",9,98000,"Salem"),
            new Employee(1016,"Kavya R","Marketing","SEO Analyst",2,45000,"Chennai"),
            new Employee(1017,"Ajay Kumar","IT","DevOps Engineer",4,72000,"Hyderabad"),
            new Employee(1018,"Lakshmi Devi","Finance","Senior Accountant",6,76000,"Coimbatore"),
            new Employee(1019,"Manoj Singh","IT","QA Engineer",3,53000,"Pune"),
            new Employee(1020,"Deepika Rao","HR","HR Manager",8,90000,"Bangalore")
        };

        static void Display(Employee e)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("ID: " + e.Id);
            Console.WriteLine("Name: " + e.Name);
            Console.WriteLine("Department: " + e.Department);
            Console.WriteLine("Designation: " + e.Designation);
            Console.WriteLine("Experience: " + e.Experience);
            Console.WriteLine("Salary: " + e.Salary);
            Console.WriteLine("City: " + e.City);
        }

        static void DisplayAll() { foreach (Employee e in employees) Display(e); }

        static void LinearSearchID(int id)
        {
            foreach (Employee e in employees) { if (e.Id == id) { Display(e); return; } }
            Console.WriteLine("Employee not found.");
        }

        static void BinarySearchID(int id)
        {
            Employee[] a = employees.ToArray();
            for (int i = 0; i < a.Length - 1; i++)
                for (int j = 0; j < a.Length - 1 - i; j++)
                    if (a[j].Id > a[j + 1].Id) { Employee t = a[j]; a[j] = a[j + 1]; a[j + 1] = t; }

            int low = 0, high = a.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (a[mid].Id == id) { Display(a[mid]); return; }
                if (a[mid].Id < id) low = mid + 1; else high = mid - 1;
            }
            Console.WriteLine("Employee not found.");
        }

        static void SearchName(string s)
        {
            bool f = false;
            foreach (Employee e in employees)
                if (e.Name.ToLower().Contains(s.ToLower())) { Display(e); f = true; }
            if (!f) Console.WriteLine("Employee not found.");
        }

        static void SearchDept(string s)
        {
            bool f = false;
            foreach (Employee e in employees)
                if (e.Department.Equals(s, StringComparison.OrdinalIgnoreCase)) { Display(e); f = true; }
            if (!f) Console.WriteLine("Employee not found.");
        }

        static void SearchCity(string s)
        {
            bool f = false;
            foreach (Employee e in employees)
                if (e.City.Equals(s, StringComparison.OrdinalIgnoreCase)) { Display(e); f = true; }
            if (!f) Console.WriteLine("Employee not found.");
        }

        static void SearchExp(int exp)
        {
            bool f = false;
            foreach (Employee e in employees)
                if (e.Experience == exp) { Display(e); f = true; }
            if (!f) Console.WriteLine("Employee not found.");
        }

        static void SearchSalary(double min, double max)
        {
            bool f = false;
            foreach (Employee e in employees)
                if (e.Salary >= min && e.Salary <= max) { Display(e); f = true; }
            if (!f) Console.WriteLine("Employee not found.");
        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n1.Display All\n2.Linear Search ID\n3.Binary Search ID\n4.Search Name\n5.Search Department\n6.Search City\n7.Search Experience\n8.Search Salary Range\n9.Exit");
                Console.Write("Choice: ");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1: DisplayAll(); break;
                    case 2: Console.Write("ID: "); LinearSearchID(int.Parse(Console.ReadLine())); break;
                    case 3: Console.Write("ID: "); BinarySearchID(int.Parse(Console.ReadLine())); break;
                    case 4: Console.Write("Name: "); SearchName(Console.ReadLine()); break;
                    case 5: Console.Write("Department: "); SearchDept(Console.ReadLine()); break;
                    case 6: Console.Write("City: "); SearchCity(Console.ReadLine()); break;
                    case 7: Console.Write("Experience: "); SearchExp(int.Parse(Console.ReadLine())); break;
                    case 8: Console.Write("Min Salary: "); double mn = double.Parse(Console.ReadLine()); Console.Write("Max Salary: "); double mx = double.Parse(Console.ReadLine()); SearchSalary(mn, mx); break;
                    case 9: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }
    }
}
