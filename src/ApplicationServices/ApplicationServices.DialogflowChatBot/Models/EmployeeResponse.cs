using System;
using System.Collections.Generic;
using System.Text;
using Domain.DotNetCore.Models;

namespace ApplicationServices.DotNetCore.Models
{
    public class EmployeeResponse
    {
        public EmployeeModel_Domain employee { get; set; }
    }
}
