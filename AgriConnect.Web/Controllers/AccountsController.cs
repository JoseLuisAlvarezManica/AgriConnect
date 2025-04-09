﻿using AgriConnect.Shared;
using AgriConnect.Shared.DTO;
using AgriConnect.Web.Data;
using AgriConnect.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AgriConnect.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserHelper userHelper;
        private readonly IConfiguration configuration;

        public AccountsController(IUserHelper userHelper, IConfiguration configuration) 
        {
            this.userHelper = userHelper;
            this.configuration = configuration;
        }
         
        //Get
        [HttpGet]
        public IActionResult Login() 
        { 
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(new LoginDTO());
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await userHelper.LoginAsync(loginDTO);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    return RedirectToAction(nameof(Index), "Home");
                }
                ModelState.AddModelError(string.Empty, "Email o contraseña equivocada");
            }
            return View(loginDTO);
        }
        public async Task<IActionResult> Logout()
        {
            await userHelper.LogoutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
        private object? BuildToken(User user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name,user.Email!),

        new Claim(ClaimTypes.Role,user.UserType.ToString()),

        new Claim("FirstName",user.FirstName),

        new Claim("LastName",user.LastName),

        new Claim("Photo",user.PhotoUrl ?? string.Empty),

        new Claim("CityId",user.CityId.ToString())
    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwtKey"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(10);

            var token = new JwtSecurityToken(

                issuer: null,

                audience: null,

                claims: claims,

                expires: expiration,

                signingCredentials: credentials);

            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

        }


    }
}
