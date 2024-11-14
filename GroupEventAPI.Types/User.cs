using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Types
{
    internal class User: IdentityUser
    {
        List<Event> _events;

        public User(string email, string username):base()
        {
            //identityUser fields
            Email = email;
            UserName = username;
            //

            _events = new List<Event>();
        }
    }
}
