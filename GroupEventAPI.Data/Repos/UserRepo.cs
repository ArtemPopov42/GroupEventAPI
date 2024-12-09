using GroupEventAPI.Types;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Data
{
    public class UserRepo: IUserRepo
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public UserRepo(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public Task<IdentityResult> Create(User newUser, string password)
        {
            return _userManager.CreateAsync(newUser, password);
        }

        public Task<User> FindByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<User> FindById(string Id)
        {
            return _userManager.FindByIdAsync(Id);
        }

        public Task<List<Event>> GetEvents(string userId)
        {
            return Task.FromResult(_dbContext.Events.Where(x => x.CreatorId == userId).ToList());
            //var user = await _userManager.FindByIdAsync(userId);
            //return user.Events;
        }

        public Task<SignInResult> SignIn(User user, string password)
        {
            return _signInManager.PasswordSignInAsync(user, password, false, false);
        }


    }
}
