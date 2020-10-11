using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DotNetCore.Models;

namespace Domain.DotNetCore.Repositories
{
    public interface IDefaultRepository
    {
        Task<DefaultModel_Domain> GetDefaultText(string text);
    }
}
