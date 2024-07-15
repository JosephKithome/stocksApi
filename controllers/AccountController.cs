using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controllers
{
    [Route("api/v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                var user = await _userManager.Users.FirstOrDefaultAsync(user=>user.Email == request.Email.ToLower() || user.PhoneNumber == request.Email);

                if(user == null) return StatusCode(500, new { message = "Invalid credentials!" });
                
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                
                if(!result.Succeeded) return StatusCode(401, new { message = "Invalid credentials" });
                
               return Ok(new NewUserDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Address = user.Address,
                        City = user.City,
                        ZipCode = user.ZipCode,
                        Country = user.Country,
                        State = user.State,
                        PhoneNumber = user.PhoneNumber,
                        Token = _tokenService.createToken(user)
                    });
                

            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", errors = new[] { e.Message } });

            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            try
            {
                Console.WriteLine("Register" + request);

                // Purposely to catch the errors defined in the model for the data fields
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.Email,
                    Password = request.Password,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Country = request.Country,
                    State = request.State,
                    Address = request.Address,
                    City = request.City,
                    ZipCode = request.ZipCode

                };
                var createdUser = await _userManager.CreateAsync(appUser, request.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (!roleResult.Succeeded)
                    {
                        return StatusCode(500, new { message = "Failed to assign role to user", errors = roleResult.Errors });
                    }
                    return Ok(new NewUserDto
                    {
                        FirstName = appUser.FirstName,
                        LastName = appUser.LastName,
                        Email = appUser.Email,
                        Address = appUser.Address,
                        City = appUser.City,
                        ZipCode = appUser.ZipCode,
                        Country = appUser.Country,
                        State = appUser.State,
                        PhoneNumber = appUser.PhoneNumber,
                        Token = _tokenService.createToken(appUser)
                    });
                }
                else
                {
                    return StatusCode(500, new { message = "Failed to create user", errors = createdUser.Errors });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

    }
}