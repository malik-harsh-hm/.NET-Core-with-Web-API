using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DotNetCore.Models
{
    public class EmployeeModel_Domain
    {

            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public Dept Department { get; set; }
        
    }
    public enum Dept
    {
        IT,
        HR,
        Payroll,
        Admin
    }
}
