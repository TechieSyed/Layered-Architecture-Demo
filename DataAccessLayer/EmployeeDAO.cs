using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DataAccessLayer
{
    public class EmployeeDAO
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;

        public EmployeeDAO()
        {
            var ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new SqlConnection(ConnectionString);

            command = new SqlCommand();
        }

        public int Add(string name, string email)
        {
            int RowsAdded = 0;
            try
            {
                command.Parameters.Clear();
                command.Connection = connection;
                command.CommandText = "insert into employees values(@p1,@p2)";
                command.Parameters.AddWithValue("@p1", name);
                command.Parameters.AddWithValue("@p2", email);
                connection.Open();
                RowsAdded = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return RowsAdded;
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("select * from Employees", connection);
                adapter.Fill(table);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return table;
        }
    }
}
