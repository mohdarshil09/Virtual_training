using System;
using System.Collections.Generic;

namespace Lab4
{
    // Abstract base class
    public abstract class Employee
    {
        public string Name { get; }
        public decimal BaseSalary { get; }

        // Constructor
        protected Employee(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        // Abstract method
        // Every derived class MUST implement this
        public abstract decimal CalculatePay();

        // Concrete method
        // Works for every subclass
        public void PrintPaySlip()
        {
            Console.WriteLine($"{Name}: {CalculatePay():C}");
        }
    }


    // Salaried employee
    public class SalariedEmployee : Employee
    {
        public SalariedEmployee(string name, decimal baseSalary)
            : base(name, baseSalary)
        {
        }

        // Override abstract method
        public override decimal CalculatePay()
        {
            return BaseSalary;
        }
    }


    // Commission employee
    public class CommissionEmployee : Employee
    {
        public decimal CommissionEarned;

        public CommissionEmployee(
            string name,
            decimal baseSalary,
            decimal commission)
            : base(name, baseSalary)
        {
            CommissionEarned = commission;
        }

        // Override abstract method
        public override decimal CalculatePay()
        {
            return BaseSalary + CommissionEarned;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // List of base-class references
            List<Employee> employees = new List<Employee>();

            // Salaried employee
            employees.Add(
                new SalariedEmployee("Alice", 4500m)
            );

            // Commission employee
            employees.Add(
                new CommissionEmployee("Bob", 3000m, 200m)
            );

            // Commission employee
            employees.Add(
                new CommissionEmployee("Carla", 3500m, 650m)
            );


            // Polymorphism
            foreach (Employee employee in employees)
            {
                employee.PrintPaySlip();
            }
        }
    }
}