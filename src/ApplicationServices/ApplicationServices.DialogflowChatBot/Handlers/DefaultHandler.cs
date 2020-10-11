using System;
using System.Collections.Generic;
using System.Text;
using Domain.DotNetCore.Models;
using ApplicationServices.DotNetCore.Models;
using System.Threading.Tasks;
using Domain.DotNetCore.Repositories;

namespace ApplicationServices.DotNetCore.Handlers
{
    public class DefaultHandler : IHandlesAsync<DefaultQuery, DefaultResponse>
    {
        private readonly IDefaultRepository _defaultRepository;
        public DefaultHandler(IDefaultRepository defaultRepository)
        {
            _defaultRepository = defaultRepository;
        }
        public async Task<DefaultResponse> HandleAsync(DefaultQuery query)
        {
            var response = await _defaultRepository.GetDefaultText(query.text);
            return new DefaultResponse
            {
                Text = response.text
            };
        }
    }

    public class DefaultQuery : IQuery<DefaultResponse>
    {
        public string text { get; set; }
    }
}
