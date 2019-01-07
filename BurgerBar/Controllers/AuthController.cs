using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BurgerBar.Entities;
using BurgerBar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IAuthService authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            this.configuration = configuration;
            this.authService = authService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var settings = configuration.GetSection("Authentication");

            if (await authService.GetUserAuthenticationAsync(user.Username, user.Password) != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.GetValue<string>("Secret")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: settings.GetValue<string>("Issuer"),
                    audience: settings.GetValue<string>("Audience"),
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}