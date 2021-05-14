using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Protocols;
using MySql.Data.MySqlClient;

namespace EmployeeManagementProject.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public static IConfiguration appConfig;
        public static string conString;
        public EmployeeRepository(IConfiguration configuration)
        {
            appConfig = configuration;
            conString = appConfig.GetConnectionString("DefaultConnection");
        }

        public bool Register(EmployeeModel employeeModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddEmployeeToTable", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("FirstName", employeeModel.FirstName);
                    sqlCommand.Parameters.AddWithValue("LastName", employeeModel.LastName);
                    sqlCommand.Parameters.AddWithValue("Mobile", employeeModel.Mobile);
                    sqlCommand.Parameters.AddWithValue("Email", employeeModel.Email);
                    sqlCommand.Parameters.AddWithValue("City", employeeModel.City);
                    connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool Login(int id, string mobile)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = new SqlCommand("spEmployeeLogin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("EmployeeID", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (mobile.ToString().Equals(reader["Mobile"].ToString()))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(EmployeeModel employeeModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command1 = new SqlCommand("spUpdateEmployeeToTable", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command1.Parameters.AddWithValue("EmployeeID", employeeModel.EmployeeID);
                    command1.Parameters.AddWithValue("FirstName", employeeModel.FirstName);
                    command1.Parameters.AddWithValue("LastName", employeeModel.LastName);
                    command1.Parameters.AddWithValue("Mobile", employeeModel.Mobile);
                    command1.Parameters.AddWithValue("Email", employeeModel.Email);
                    command1.Parameters.AddWithValue("City", employeeModel.City);
                    command1.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employeesList = new List<EmployeeModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = new SqlCommand("spGetAllEmployees", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel
                        {
                            EmployeeID = (int)reader["EmployeeID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Mobile = reader["Mobile"].ToString(),
                            Email = reader["Email"].ToString(),
                            City = reader["City"].ToString()
                        };
                        employeesList.Add(employee);
                    }
                }
                return employeesList;
            }
            catch
            {
                return null;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = new SqlCommand("spDeleteEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("EmployeeID", id);
                    var result = command.ExecuteNonQuery();
                    if (result == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
        }
    }
}
