using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Types
{
    public class Event
    {
        public string EventId { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }
        public User Creator { get; set; }
        public DateTime Date { get; set; }

        public Event()
        {
            EventId = Guid.NewGuid().ToString();
            Description = "";
            Creator = new User();
            CreatorId = Creator.Id;
            Date = default;
        }
        public Event(User user, string description = "", DateTime date = default)
        {
            EventId = Guid.NewGuid().ToString();
            Description = description;
            Creator = user;
            CreatorId = Creator.Id;
            Date = date;
        }
    }
}
