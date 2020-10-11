using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using Domain.DotNetCore.Models;
using ApplicationServices.DotNetCore.Handlers;
using ApplicationServices.DotNetCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHandlesAsync<DefaultQuery, DefaultResponse> _defaultHandler;

        public HomeController(IHandlesAsync<DefaultQuery, DefaultResponse> defaultHandler)
        {
            _defaultHandler = defaultHandler;
        }

        [HttpPost]
        public async Task<IActionResult> MyMethod()
        {

        }
    }
}
