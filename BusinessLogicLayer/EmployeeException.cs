using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class EmployeeException : Exception
    {
        public EmployeeException() : base()
        {

        }

        public EmployeeException(string message) : base(message)
        {

        }

        public EmployeeException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
