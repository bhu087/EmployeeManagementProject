/////------------------------------------------------------------------------
////<copyright file="EmployeeController.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------

namespace EmployeeManagementProject.Controllers
{
    using EmployeeManagement.Models;
    using EmployeeManagementProject.Manager;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller class for employee
    /// </summary>
    public class EmployeeController : Controller
    {
        /// <summary>
        /// boolean variable for receiving result
        /// </summary>
        private bool response;

        /// <summary>
        /// Interface for manager
        /// </summary>
        private IEmployeeManager _manager;

        /// <summary>
        /// constructor for employee
        /// </summary>
        /// <param name="manager"></param>
        public EmployeeController(IEmployeeManager manager)
        {
            this._manager = manager;
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="employeeModel">employee model as input parameters</param>
        /// <returns>return action results</returns>
        [HttpPost]
        [Route("api/register")]
        public ActionResult Register(EmployeeModel employeeModel)
        {
            EmployeeModel employee = new EmployeeModel
            {
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                Mobile = employeeModel.Mobile,
                Email = employeeModel.Email,
                City = employeeModel.City
            };
            this.response = this._manager.Register(employee);
            if (this.response)
            {
                return this.Ok("Registered Successfully");
            }

            return this.BadRequest("Not registered");
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="id">id as input</param>
        /// <param name="mobile">mobile number as input</param>
        /// <returns>return action result</returns>
        [HttpPost]
        [Route("api/login")]
        public ActionResult Login(int id, string mobile)
        {
            this.response = this._manager.Login(id, mobile);
            if (this.response)
            {
                return this.Ok("Logged in successfully");
            }

            return this.BadRequest("Not Logged in");
        }

        /// <summary>
        /// Updates method
        /// </summary>
        /// <param name="employeeModel">employee model as input parameter</param>
        /// <returns>returns action result</returns>
        [HttpPut]
        [Route("api/update")]
        public ActionResult Update(EmployeeModel employeeModel)
        {
            this.response = this._manager.Update(employeeModel);
            if (this.response)
            {
                return this.Ok("Updated");
            }

            return this.BadRequest("Not updated");
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>returns action results</returns>
        [HttpGet]
        [Route("api/getAll")]
        public ActionResult GetAllEmployees()
        {
            return this.Ok(this._manager.GetAllEmployees());
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="id">id as input</param>
        /// <returns>returns action result</returns>
        [HttpDelete]
        [Route("api/delete")]
        public ActionResult Delete(int id)
        {
            this.response = this._manager.Delete(id);
            if (this.response)
            {
                return this.Ok("Deleted successfully");
            }

            return this.BadRequest("Employee not in DB");
        }
    }
}
