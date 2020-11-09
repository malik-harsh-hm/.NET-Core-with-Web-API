using Domain.DotNetCore.Models;
using Domain.DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DotNetCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<UserModel_Domain> GetUser(string id, string pwd)
        {
            UserModel_Domain result = new UserModel_Domain();

            result.isAuthenticated = (id == "demo" && pwd == "demo");

            return await Task.FromResult(result);
        }

    }
}
