using GroupEventAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Services
{
    public interface IAccountService
    {
        public Task<IdentityResult> Register(UserRegisterRequestModel userRegisterRequestModel);
        public Task<LoginResponseModel> Login(LoginRequestModel loginRequest);
    }
}
