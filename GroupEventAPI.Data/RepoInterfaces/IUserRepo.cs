using GroupEventAPI.Types;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Data
{
    public interface IUserRepo
    {
        public Task<IdentityResult> Create(User newUser, string Password);
        public Task<User> FindByEmail(string email);
        public Task<User> FindById(string id);
        public Task<SignInResult> SignIn(User user, string password);
        public Task<List<Event>> GetEvents(string userId);

    }
}
