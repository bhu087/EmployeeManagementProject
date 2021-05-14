using EmployeeManagement.Models;
using EmployeeManagementProject.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementProject.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeManager _manager;
        public EmployeeController(IEmployeeManager manager)
        {
            _manager = manager;
        }
        bool response;
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
            response = _manager.Register(employee);
            if (response)
            {
                return this.Ok("Registered Successfully");
            }
            return this.BadRequest("Not registered");
        }
        [HttpPost]
        [Route("api/login")]
        public ActionResult Login(int id, string mobile)
        {
            response = _manager.Login(id, mobile);
            if (response)
            {
                return this.Ok("Logged in successfully");
            }
            return this.BadRequest("Not Logged in");
        }
        [HttpPut]
        [Route("api/update")]
        public ActionResult Update(EmployeeModel employeeModel)
        {
            response = _manager.Update(employeeModel);
            if (response)
            {
                return this.Ok("Updated");
            }
            return this.BadRequest("Not updated");
        }
        [HttpGet]
        [Route("api/getAll")]
        public ActionResult GetAllEmployees()
        {
            return this.Ok(_manager.GetAllEmployees());
        }
        [HttpDelete]
        [Route("api/delete")]
        public ActionResult Delete(int id)
        {
            response = _manager.Delete(id);
            if (response)
            {
                return this.Ok("Deleted successfully");
            }
            return this.BadRequest("Employee not in DB");
        }
    }
}
