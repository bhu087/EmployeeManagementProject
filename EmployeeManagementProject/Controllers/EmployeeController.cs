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
            bool responce = _manager.Register(employee);
            if (responce)
            {
                return this.Ok("Registered Successfully");
            }
            return this.BadRequest("Not registered");
        }
    }
}
