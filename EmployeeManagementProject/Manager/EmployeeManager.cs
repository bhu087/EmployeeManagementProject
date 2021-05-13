﻿using EmployeeManagement.Models;
using EmployeeManagementProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementProject.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        IEmployeeRepository _repository;
        public EmployeeManager(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public bool Login(int id, string mobile)
        {
            return _repository.Login(id, mobile);
        }

        public bool Register(EmployeeModel employee)
        {
            return _repository.Register(employee);
        }

        public bool Update(EmployeeModel employeeModel, int id)
        {
            return _repository.Update(employeeModel, id);
        }
    }
}
