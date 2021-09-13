using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using Domain.DotNetCore.Models;
using ApplicationServices.DotNetCore.Handlers;
using ApplicationServices.DotNetCore.Models;

using DotNetCore.API.Filters;
using System.Web.Http;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCore.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHandlesAsync<AuthenticationQuery, AuthenticationResponse> _defaultHandler;

        public HomeController(IHandlesAsync<AuthenticationQuery, AuthenticationResponse> defaultHandler)
        {
            _defaultHandler = defaultHandler;
        }

        [System.Web.Http.HttpGet]
        public async Task<string> Get()
        {

            var result =  await ProcessCommBankPayment();

            if (result != null && result == "success")
            {
                return "Success";
            }
            else
            {
                return "Fail";
            }

        }

        private async Task<string> ProcessCommBankPayment()
        {
            bool success = false;

            try
            {
                await Task.Factory.StartNew(async() =>
                {
                    try
                    {
                        await Task.Delay(5000);
                        success = false;
                    }
                    catch (Exception)
                    {
                    }
                    if (!success)
                    {
                        throw new Exception("Retry");
                    }

                });
            }
            catch (Exception)
            {
            }
            if (success)
            {
                return "success";
            }  
            else
                return "fail";
        }
    }
}
