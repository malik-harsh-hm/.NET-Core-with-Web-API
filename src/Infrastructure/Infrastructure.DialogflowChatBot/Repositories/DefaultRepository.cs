using Domain.DotNetCore.Models;
using Domain.DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DotNetCore.Repositories
{
    public class DefaultRepository : IDefaultRepository
    {
        public async Task<DefaultModel_Domain> GetDefaultText(string text)
        {
            DefaultModel_Domain result = new DefaultModel_Domain();

            result.text = "Default_" + text;

            return await Task.FromResult(result);
        }

    }
}
