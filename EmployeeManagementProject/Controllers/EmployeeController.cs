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
        public ActionResult Register(string firstName, string lastName, string mobile, string email, string city)
        {
            EmployeeModel employee = new EmployeeModel
            {
                FirstName = firstName,
                LastName = lastName,
                Mobile = mobile,
                Email = email,
                City = city
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
    }
}
