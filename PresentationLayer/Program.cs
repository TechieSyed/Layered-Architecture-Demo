using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

using BusinessLogicLayer;
namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display Employees");
                Console.WriteLine("3. Edit Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.WriteLine("\nEnter your choice");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddEmployee(); break;
                    case 2:
                        DisplayAllEmployees(); break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 0);
        }

        private static void DisplayAllEmployees()
        {
            try
            {
                EmployeeBO BO = new EmployeeBO();
                List<Employee> Employees = BO.GetEmployees();

                if (Employees.Count == 0)
                {
                    Console.WriteLine("No employee found");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ID\tName\tEmail");
                    foreach (Employee emp in Employees)
                        Console.WriteLine($"{emp.Id}\t{emp.Name}\t{emp.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        static void AddEmployee()
        {
            try
            {
                Employee emp = new Employee();
                Console.WriteLine("Enter name");
                emp.Name = Console.ReadLine();

                Console.WriteLine("Enter email");
                emp.Email = Console.ReadLine();

                EmployeeBO BO = new EmployeeBO();
                bool IsAdded = BO.Add(emp);
                if (IsAdded)
                    Console.WriteLine("Added successfull");
                else
                    Console.WriteLine("Add failed. Try later");
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine("Validation failed : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
    }
}
