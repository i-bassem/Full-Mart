using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FullMart.Core.Helper.JWT;
using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using FullMart.Core.Models.JwtModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace FullMart.Data.Repositories
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly JWT _jwt;
        public AuthenticationRepo(UserManager<AppUser> userManager , RoleManager<IdentityRole> roleManager, IMapper mapper , IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _jwt = jwt.Value;
        }



        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            // ensuring that user is valid to register
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(model.Username) is not null)
                return new AuthModel { Message = "Username is already registered!" };

            var user = _mapper.Map<AppUser>(model);

            //creating new user 
            var result = await _userManager.CreateAsync(user, model.Password); //registeration for user and hashing password 

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            // creating token to assign it to registered user 
            var JwtSecurityToken = await CreateJwtToken(user);
            return new AuthModel
            {
                id = user.Id,//ID of user sent on regiseration
                Email = user.Email,
                ExpiresOn = JwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "user" },
                Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken),
                Username = user.UserName
            };
        }



        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var Authmodel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                Authmodel.Message = "Email or Password Is Incorrect";
                return Authmodel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            Authmodel.IsAuthenticated = true;
            Authmodel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            Authmodel.Email = user.Email;
            Authmodel.Username = user.UserName;
            Authmodel.ExpiresOn = jwtSecurityToken.ValidTo;
            Authmodel.Roles = rolesList.ToList();
            Authmodel.id = user.Id;//ID of User sent on getting his token
            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var ActiveRefreshTokens = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                Authmodel.RefreshToken = ActiveRefreshTokens.Token;
                Authmodel.RefreshTokenExpiration = ActiveRefreshTokens.ExpiresOn;
            }
            else
            {
                var RefreshToken = GenerateRefreshToken();
                Authmodel.RefreshToken = RefreshToken.Token;
                Authmodel.RefreshTokenExpiration = RefreshToken.ExpiresOn;
                user.RefreshTokens.Add(RefreshToken);
                await _userManager.UpdateAsync(user);
            }
            return Authmodel;
        }



        //Creating Token Method 
        private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user); //getting roles to use it in frontend
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key)); //security generated key
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                //expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes), //assigning expiration time 
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(1) );

            return jwtSecurityToken;
        }



        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.User_Id);
            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
            {
                return "Invalid User ID or role!";
            }
            if (await _userManager.IsInRoleAsync(user, model.Role))
            {
                return "user is Allready Assigned to This Role";
            }
            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "something Went Wrong";
        }



        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }

        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            var authModel = new AuthModel();

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens
            .Any(t => t.Token == token));

            if (user == null)
            {
                authModel.Message = "Invalid token";
                return authModel;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
            {
                authModel.Message = "Inactive token";
                return authModel;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            var jwtToken = await CreateJwtToken(user);
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;

            var roles = await _userManager.GetRolesAsync(user);
            authModel.Roles = roles.ToList();
            authModel.RefreshToken = newRefreshToken.Token;
            authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            return authModel;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return true;
        }

        public async Task<bool> GetUserByNameAsync(string UserName)
        {

            return await _userManager.Users.AnyAsync(u => u.UserName == UserName);
        }
        public async Task<bool> GetUserByEmailAsync(string UserEmail)
        {
            return await _userManager.Users.AnyAsync(u => u.Email == UserEmail);
        }
    }
}
