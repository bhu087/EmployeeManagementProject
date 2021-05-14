using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$")]
        public string LastName { get; set; }
        [RegularExpression(@"^[0-9]{2}[\s][6-9]{1}[0-9]{9}")]
        public string Mobile { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$")]
        public string City { get; set; }
    }
}