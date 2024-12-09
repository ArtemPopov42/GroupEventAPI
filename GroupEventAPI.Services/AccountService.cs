using GroupEventAPI.Data;
using GroupEventAPI.Models;
using GroupEventAPI.Types;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Services
{
    public class AccountService: IAccountService
    {

        private readonly IUserRepo _userRepo;
        

        private readonly IConfiguration _configuration;

        public AccountService(IUserRepo userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public async Task<IdentityResult> Register(UserRegisterRequestModel userRegisterRequestModel)
        {
            var newUser = new User() {
                Email = userRegisterRequestModel.Email,
                UserName = userRegisterRequestModel.UserName
            };
            var result = await _userRepo.Create(newUser, userRegisterRequestModel.Password);
            
            return result;
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel loginRequest)
        {
            var user = await _userRepo.FindByEmail(loginRequest.Email);
            if(user == null)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Message = "Cant find user with email" + loginRequest.Email,
                    Token = string.Empty,
                    User = null
                };
            }

            var res = await _userRepo.SignIn(user, loginRequest.Password);
            if (!res.Succeeded)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Message = "Password is incorrect",
                    Token = string.Empty,
                    User = user
                };
            }

            var token =  CreateJWTToken(user);

            return new LoginResponseModel {
                Success = true,
                Message = "Login is successful",
                Token = token,
                User = user
            };
        }

        private string CreateJWTToken(User user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(Double.Parse(_configuration["Jwt:ExparationTime"]));
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                CreateClaims(user),
                expires: expiration,
                signingCredentials: CreateSigningCredentials()
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
        private Claim[] CreateClaims(IdentityUser user) =>
            new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

        private SigningCredentials CreateSigningCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256
            );
    }
}
