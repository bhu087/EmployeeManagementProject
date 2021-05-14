/////------------------------------------------------------------------------
////<copyright file="IEmployeeManager.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeManagementProject.Manager
{
    using System.Collections.Generic;
    using EmployeeManagement.Models;

    /// <summary>
    /// interface for employee manager
    /// </summary>
    public interface IEmployeeManager
    {
        /// <summary>
        /// Register manager
        /// </summary>
        /// <param name="employee">employee model is input parameter</param>
        /// <returns>returns boolean result</returns>
        bool Register(EmployeeModel employee);

        /// <summary>
        /// Login manager
        /// </summary>
        /// <param name="id">id is the input parameter</param>
        /// <param name="mobile">mobile is the input parameter</param>
        /// <returns>returns boolean result</returns>
        bool Login(int id, string mobile);

        /// <summary>
        /// Update manager
        /// </summary>
        /// <param name="employeeModel">employee model is input parameter</param>
        /// <returns>returns boolean result</returns>
        bool Update(EmployeeModel employeeModel);

        /// <summary>
        /// Get all employees manager
        /// </summary>
        /// <returns>return all employees in the table</returns>
        IEnumerable<EmployeeModel> GetAllEmployees();

        /// <summary>
        /// Delete manager
        /// </summary>
        /// <param name="id">id is the input parameter</param>
        /// <returns>returns boolean result</returns>
        bool Delete(int id);
    }
}
