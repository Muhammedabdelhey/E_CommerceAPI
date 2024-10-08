﻿using E_Commerce.Application.Common.Interfaces;
using System.Security.Claims;

namespace E_Commerce.Presentation.Services
{
    public class CurrentUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        // should registerd as service 
        public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
