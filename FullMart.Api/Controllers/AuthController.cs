using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using FullMart.Core.Models.JwtModels;
using FullMart.Core.UnitOfWork;
using FullMart.Data.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FullMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationRepo _authRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        public AuthController(IAuthenticationRepo authRepo, IUnitOfWork unitOfWork ,UserManager<AppUser> userManager)
        {
            _authRepo = authRepo;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        //https://localhost:7191/api/Auth/Register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRepo.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            //SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            var user = await _userManager.FindByEmailAsync(model.Email);

            _unitOfWork.wishListProductRepo.CreateWishlist(user.Id);
            _unitOfWork.Carts.AddCart(user.Id);

            _unitOfWork.Complete();

            return Ok(result);
        }

        //https://localhost:7191/api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] TokenRequestModel model)
        {
            var result = await _authRepo.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            //return Ok(result);
            return Ok(new
            {

                token = result.Token,
                expireson = result.ExpiresOn,
                user_Email = result.Email,
                user_name = result.Username
                
            });
        }


        //https://localhost:7191/api/Auth/AddRole
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authRepo.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }
            return Ok(model);
        }

        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var result = await _authRepo.RefreshTokenAsync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }


        [HttpPost("revokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenDTO model)
        {
            // receiving the token value from body or cookies
            // if model.token is null then request the token from cookies
            var token = model.Token ?? Request.Cookies["refreshToken"]; 
            
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _authRepo.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }



        //https://localhost:7191/api/Auth/GetUserByName?UserName=string
        [HttpGet("GetUserByName")]
        public async Task<IActionResult> GetUserByName(string UserName)
        {
            return Ok(_authRepo.GetUserByNameAsync(UserName).Result);
        }

        //https://localhost:7191/api/Auth/GetUserByEmail?Useremail=string
        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string Useremail)
        {
            return Ok(_authRepo.GetUserByEmailAsync(Useremail).Result);
        }


        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime()
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
