using System;
using System.Collections.Generic;
using System.Text;
using Domain.DotNetCore.Models;
using ApplicationServices.DotNetCore.Models;
using System.Threading.Tasks;
using Domain.DotNetCore.Repositories;

namespace ApplicationServices.DotNetCore.Handlers
{
    public class AuthenticationHandler : IHandlesAsync<AuthenticationQuery, AuthenticationResponse>
    {
        private readonly IUserRepository _userRepo;
        public AuthenticationHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<AuthenticationResponse> HandleAsync(AuthenticationQuery query)
        {
            var response = await _userRepo.GetUser(query.id, query.pwd);
            return new AuthenticationResponse
            {
                isAuthenticated = response.isAuthenticated
            };
        }
    }

    public class AuthenticationQuery : IQuery<AuthenticationResponse>
    {
        public string id { get; set; }
        public string pwd { get; set; }
    }
}
