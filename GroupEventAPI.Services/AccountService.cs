using GroupEventAPI.Models;
using GroupEventAPI.Types;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Services
{
    public class AccountService: IAccountService
    {
        private readonly UserManager<User> _userManager;

        public AccountService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(UserRegisterRequestModel userRegisterRequestModel)
        {
            var newUser = new User() {
                Email = userRegisterRequestModel.Email,
                UserName = userRegisterRequestModel.UserName
            };
            var result = await _userManager.CreateAsync(newUser, userRegisterRequestModel.Password);
            
            return result;
        }
    }
}
