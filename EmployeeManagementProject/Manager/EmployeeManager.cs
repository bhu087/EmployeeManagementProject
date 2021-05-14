/////------------------------------------------------------------------------
////<copyright file="EmployeeManager.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeManagementProject.Manager
{
    using System.Collections.Generic;
    using EmployeeManagement.Models;
    using EmployeeManagementProject.Repository;

    /// <summary>
    /// Employee manager class
    /// </summary>
    public class EmployeeManager : IEmployeeManager
    {
        /// <summary>
        /// employee repository interface
        /// </summary>
        public IEmployeeRepository repository;

        /// <summary>
        /// constructor for employee Manager
        /// </summary>
        /// <param name="repo">repository as a input</param>
        public EmployeeManager(IEmployeeRepository repo)
        {
            this.repository = repo;
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="id">id as input</param>
        /// <returns>returns boolean value</returns>
        public bool Delete(int id)
        {
            return this.repository.Delete(id);
        }

        /// <summary>
        /// Get all employees method
        /// </summary>
        /// <returns>returns boolean result</returns>
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return this.repository.GetAllEmployees();
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="id">input as id</param>
        /// <param name="mobile">input as mobile number</param>
        /// <returns>returns boolean value</returns>
        public bool Login(int id, string mobile)
        {
            return this.repository.Login(id, mobile);
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="employee">employee model as parameter</param>
        /// <returns>returns boolean result</returns>
        public bool Register(EmployeeModel employee)
        {
            return this.repository.Register(employee);
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="employeeModel">employee model as input</param>
        /// <returns>returns boolean value</returns>
        public bool Update(EmployeeModel employeeModel)
        {
            return this.repository.Update(employeeModel);
        }
    }
}
