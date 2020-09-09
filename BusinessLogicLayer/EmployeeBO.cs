using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class EmployeeBO
    {
        EmployeeDAO employeeDAO;
        public EmployeeBO()
        {
            employeeDAO = new EmployeeDAO();
        }

        private bool Validate(Employee employee, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool IsValid = true;

            if (string.IsNullOrEmpty(employee.Name))
            {
                errorMessage = "Employee name is required";
                IsValid = false;
            }
            else if (employee.Name.Length < 3)
            {
                errorMessage = "Invalid name";
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(employee.Email))
            {
                errorMessage = "Employee email is required";
                IsValid = false;
            }
            else if(!employee.Email.EndsWith(".com") || !employee.Email.Contains("@"))
            {
                errorMessage = "Invalid email format";
                IsValid = false;
            }

            return IsValid;
        }

        public bool Add(Employee employee)
        {
            bool IsAdded = false;
            try
            {
                string Error = string.Empty;
                if(!Validate(employee, out Error))
                {
                    throw new EmployeeException(Error);
                }
                int RowsAffected = employeeDAO.Add(employee.Name, employee.Email);
                IsAdded = (RowsAffected > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> Employees = new List<Employee>();
            try
            {
                DataTable EmployeesTable = employeeDAO.GetAll();
                if (EmployeesTable.Rows.Count > 0)
                {
                    Employee employee;
                    foreach(DataRow row in EmployeesTable.Rows)
                    {
                        employee = new Employee();
                        employee.Id = Convert.ToInt32(row[0]);
                        employee.Name = row[1].ToString();
                        employee.Email = row[2].ToString();

                        Employees.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Employees;
        }
    }
}
