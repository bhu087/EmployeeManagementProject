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
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
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
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
