using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Types
{
    internal class Event
    {
        public string Description { get; set; }
        User _creator;
        DateTime _date;


        public Event(User user, string description = "", DateTime date = default)
        {
            Description = description;
            _creator = user;
            _date = date;
        }
    }
}
