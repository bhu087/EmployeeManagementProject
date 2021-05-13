﻿using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementProject.Repository
{
    public interface IEmployeeRepository
    {
        bool Register(EmployeeModel employee);
        bool Login(EmployeeModel employee);
    }
}
