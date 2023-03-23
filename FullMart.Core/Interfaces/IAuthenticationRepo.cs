using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullMart.Core.Models.JwtModels;
using Microsoft.AspNetCore.Authentication;

namespace FullMart.Core.Interfaces
{
    public interface IAuthenticationRepo
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        public Task<bool> GetUserByNameAsync(string UserName);
        public Task<bool> GetUserByEmailAsync(string UserEmail);
    }
}
