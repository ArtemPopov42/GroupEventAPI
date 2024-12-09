using GroupEventAPI.Models.Requests;
using GroupEventAPI.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Services
{
    public interface IUserService
    {
        public Task CreateEvent(string userId, CreateEventRequestModel createEventRequest);
        public Task<List<Event>> GetEvents(string userId);
    }
}
