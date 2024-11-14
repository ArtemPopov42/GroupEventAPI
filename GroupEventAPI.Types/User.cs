using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Types
{
    public class User: IdentityUser
    {
        public List<Event> Events;

        public User() : base()
        {
            Events = new List<Event>();
        }
        public User(string email, string username):base()
        {
            //identityUser fields
            Email = email;
            UserName = username;
            //

            Events = new List<Event>();
        }
    }
}
