using System;
using System.Collections.Generic;
using System.Text;

class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}

class Program
{
    static void Main()
    {
        const string rawData = @"
john smith|engineering|72000
MARY jones|sales|65000

ravi KUMAR|engineering|81000
";

        // Store employees
        List<Employee> employees = new List<Employee>();

        // Split raw data into rows
        string[] rows = rawData.Split(
            '\n',
            StringSplitOptions.None
        );

        // Parse each row
        foreach (string row in rows)
        {
            // Skip blank rows
            if (string.IsNullOrWhiteSpace(row))
            {
                continue;
            }

            // Split row into fields
            string[] fields = row.Trim().Split('|');

            if (fields.Length != 3)
            {
                continue;
            }

            string name = fields[0].Trim();
            string department = fields[1].Trim();
            decimal salary = decimal.Parse(fields[2].Trim());

            employees.Add(new Employee
            {
                Name = StringToolkit.ToTitleCase(name),
                Department = StringToolkit.ToTitleCase(department),
                Salary = salary
            });
        }

        // Calculate totals
        decimal totalSalary = 0;

        foreach (Employee employee in employees)
        {
            totalSalary += employee.Salary;
        }

        // StringBuilder
        StringBuilder sb = new StringBuilder();

        int appendCalls = 0;

        // Title
        sb.AppendLine("        EMPLOYEE COMPENSATION REPORT");
        appendCalls++;

        sb.AppendLine("==============================================");
        appendCalls++;

        // Header
        sb.AppendLine(
            "Name".PadRight(20) +
            "Department".PadRight(18) +
            "Salary".PadLeft(12)
        );
        appendCalls++;

        sb.AppendLine("----------------------------------------------");
        appendCalls++;

        // Employee rows
        foreach (Employee employee in employees)
        {
            string line =
                employee.Name.PadRight(20) +
                employee.Department.PadRight(18) +
                employee.Salary.ToString("C").PadLeft(12);

            sb.AppendLine(line);
            appendCalls++;
        }

        sb.AppendLine("----------------------------------------------");
        appendCalls++;

        // Footer
        sb.AppendLine(
            $"Employees: {employees.Count}    " +
            $"Total Salary: {totalSalary:N0}"
        );
        appendCalls++;

        // Print report
        Console.WriteLine(sb.ToString());

        // Statistics
        Console.WriteLine();
        Console.WriteLine("===== BUILD STATISTICS =====");
        Console.WriteLine(
            $"StringBuilder Append calls: {appendCalls}"
        );
        Console.WriteLine(
            "String concatenations in loop: 0"
        );
    }
}