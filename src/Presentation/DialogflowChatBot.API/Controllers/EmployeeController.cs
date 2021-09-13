using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Domain.DotNetCore.Models;
using ApplicationServices.DotNetCore.Handlers;
using ApplicationServices.DotNetCore.Models;


namespace DotNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IHandlesAsync<EmployeeQuery, EmployeeResponse> _handler;
        public EmployeeController()
        {
            
        }
        [HttpGet]
        public string Get([FromServices]IHandlesAsync<EmployeeQuery, EmployeeResponse> handler)
        {
            _handler = handler;
            var res = _handler.HandleAsync(new EmployeeQuery() { id = 1 });
            return $"{res.GetAwaiter().GetResult().employee.Name}";
        }

    }
}
