using System;
using System.Collections.Generic;

namespace BusinessCaseStudy
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Designation;
        public string Department;
        public int ManagerId;

        public Employee(int id, string name, string designation, string department, int managerId)
        {
            Id = id;
            Name = name;
            Designation = designation;
            Department = department;
            ManagerId = managerId;
        }
    }

    internal class Program
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(1001, "John Smith", "CEO", "Management", 0),
            new Employee(1002, "Michael Johnson", "IT Manager", "IT", 1001),
            new Employee(1003, "Sarah Williams", "HR Manager", "HR", 1001),
            new Employee(1004, "David Brown", "Finance Manager", "Finance", 1001),
            new Employee(1005, "Robert Davis", "Team Lead", "IT", 1002),
            new Employee(1006, "Jennifer Miller", "QA Lead", "IT", 1002),
            new Employee(1007, "William Wilson", "Senior Developer", "IT", 1005),
            new Employee(1008, "Emma Moore", "Senior Developer", "IT", 1005),
            new Employee(1009, "Daniel Taylor", "QA Engineer", "IT", 1006),
            new Employee(1010, "Sophia Anderson", "QA Engineer", "IT", 1006),
            new Employee(1011, "James Thomas", "Recruiter", "HR", 1003),
            new Employee(1012, "Olivia Jackson", "Recruiter", "HR", 1003),
            new Employee(1013, "Benjamin White", "Accountant", "Finance", 1004),
            new Employee(1014, "Charlotte Harris", "Accountant", "Finance", 1004),
            new Employee(1015, "Lucas Martin", "Developer", "IT", 1007),
            new Employee(1016, "Ethan Walker", "Developer", "IT", 1007),
            new Employee(1017, "Mia Hall", "UI Developer", "IT", 1008),
            new Employee(1018, "Alexander Young", "Business Analyst", "IT", 1005),
            new Employee(1019, "Harper King", "HR Executive", "HR", 1011),
            new Employee(1020, "Jack Scott", "Finance Executive", "Finance", 1013)
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("ABC TECHNOLOGIES");
                Console.WriteLine("Organization Hierarchy Management System");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Display Complete Organization Chart");
                Console.WriteLine("2. Find Employee by ID");
                Console.WriteLine("3. Find Employee by Name");
                Console.WriteLine("4. Display Employees under a Manager");
                Console.WriteLine("5. Count Total Employees under a Manager");
                Console.WriteLine("6. Display Hierarchy Level");
                Console.WriteLine("7. Exit");

                Console.Write("\nEnter Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Employee ceo = FindEmployeeById(1001);
                        DisplayHierarchy(ceo, "");
                        break;

                    case 2:
                        Console.Write("Enter Employee ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Employee emp = FindEmployeeById(id);

                        if (emp != null)
                            PrintEmployee(emp);
                        else
                            Console.WriteLine("Employee Not Found.");
                        break;

                    case 3:
                        Console.Write("Enter Employee Name: ");
                        string name = Console.ReadLine();

                        Employee empName = FindEmployeeByName(name);

                        if (empName != null)
                            PrintEmployee(empName);
                        else
                            Console.WriteLine("Employee Not Found.");
                        break;

                    case 4:
                        Console.Write("Enter Manager ID: ");
                        int managerId = Convert.ToInt32(Console.ReadLine());

                        DisplayEmployees(managerId);
                        break;

                    case 5:
                        Console.Write("Enter Manager ID: ");
                        int mId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Total Employees = " + CountEmployees(mId));
                        break;

                    case 6:
                        Console.Write("Enter Employee ID: ");
                        int eId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Hierarchy Level = " + GetLevel(eId));
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }

        static Employee FindEmployeeById(int id)
        {
            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                    return emp;
            }
            return null;
        }

        static Employee FindEmployeeByName(string name)
        {
            foreach (Employee emp in employees)
            {
                if (emp.Name.ToLower() == name.ToLower())
                    return emp;
            }
            return null;
        }

        static void PrintEmployee(Employee emp)
        {
            Console.WriteLine("\nEmployee Details");
            Console.WriteLine("------------------------");
            Console.WriteLine("ID          : " + emp.Id);
            Console.WriteLine("Name        : " + emp.Name);
            Console.WriteLine("Designation : " + emp.Designation);
            Console.WriteLine("Department  : " + emp.Department);
            Console.WriteLine("Manager ID  : " + emp.ManagerId);
        }

        // Recursive Function
        static void DisplayHierarchy(Employee manager, string space)
        {
            Console.WriteLine(space + manager.Name + " (" + manager.Designation + ")");

            foreach (Employee emp in employees)
            {
                if (emp.ManagerId == manager.Id)
                {
                    DisplayHierarchy(emp, space + "   ");
                }
            }
        }

        static void DisplayEmployees(int managerId)
        {
            bool found = false;

            foreach (Employee emp in employees)
            {
                if (emp.ManagerId == managerId)
                {
                    Console.WriteLine(emp.Id + " - " + emp.Name + " (" + emp.Designation + ")");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No Employees Found.");
        }

        // Recursive Function
        static int CountEmployees(int managerId)
        {
            int count = 0;

            foreach (Employee emp in employees)
            {
                if (emp.ManagerId == managerId)
                {
                    count++;
                    count += CountEmployees(emp.Id);
                }
            }

            return count;
        }

        // Recursive Function
        static int GetLevel(int employeeId)
        {
            Employee emp = FindEmployeeById(employeeId);

            if (emp == null)
                return -1;

            if (emp.ManagerId == 0)
                return 1;

            return 1 + GetLevel(emp.ManagerId);
        }
    }
}
