using System;
using System.Collections.Generic;
using System.Text;
using Domain.DotNetCore.Models;
using ApplicationServices.DotNetCore.Models;
using System.Threading.Tasks;
using Domain.DotNetCore.Repositories;

namespace ApplicationServices.DotNetCore.Handlers
{
    public class EmployeeHandler : IHandlesAsync<EmployeeQuery, EmployeeResponse>
    {
        private readonly IEmployeeRepository _empRepo;
        public EmployeeHandler(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }
        public async Task<EmployeeResponse> HandleAsync(EmployeeQuery query)
        {
            var response = await _empRepo.GetEmployee(query.id);
            return new EmployeeResponse
            {
                employee = response
            };
        }
    }

    public class EmployeeQuery : IQuery<EmployeeResponse>
    {
        public int id { get; set; }
    }
}
