using Microsoft.AspNetCore.Http;
using OnlineRivalMarket.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Infrasturcture.Services
{
    public sealed class ApiService : IApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserIdByToken()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Contains("authentication"))?.Value;
            return userId ?? string.Empty;
        }
    }
}
