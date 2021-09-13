using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.DotNetCore.Models;
using Domain.DotNetCore.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.DotNetCore.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<EmployeeModel_Domain> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<EmployeeModel_Domain>()
        {
            new EmployeeModel_Domain() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@abc.com" },
            new EmployeeModel_Domain() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@abc.com" },
            new EmployeeModel_Domain() { Id = 3, Name = "Sam", Department = Dept.IT, Email = "sam@abc.com" },
        };
        }


        public async Task<EmployeeModel_Domain> GetEmployee(int Id)
        {
            var result =  _employeeList.FirstOrDefault(e => e.Id == Id);

            return await Task.FromResult(result);
        }

    }
}
