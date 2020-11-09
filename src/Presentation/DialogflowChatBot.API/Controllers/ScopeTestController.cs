using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.DotNetCore.Models;
using ApplicationServices.DotNetCore.Handlers;
using ApplicationServices.DotNetCore.Models;

using DotNetCore.API.Services;

namespace DotNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScopeTestController : ControllerBase
    {
        private readonly ParentService1 __parent1;
        private readonly ParentService2 __parent2;
        public ScopeTestController(ParentService1 myFatherService, ParentService2 myMotherService)
        {
            __parent1 = myFatherService;
            __parent2 = myMotherService;
        }
        [HttpGet]
        public string Get()
        {
            return $"Parent 1 Creation Count : {ParentService1.CreationCount} | " +
                $"Parent 2 Creation Count : {ParentService2.CreationCount} | " +
                $"Child Creation Count : {ChildService.CreationCount}";
        }
    }
}
