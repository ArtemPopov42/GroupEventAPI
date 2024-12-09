using GroupEventAPI.Data;
using GroupEventAPI.Models.Requests;
using GroupEventAPI.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IEventRepo _eventRepo;

        public UserService(IUserRepo userRepo, IEventRepo eventRepo)
        {
            _userRepo = userRepo;
            _eventRepo = eventRepo;
        }

        public async Task CreateEvent(string userId, CreateEventRequestModel createEventRequest)
        {
            var user = await _userRepo.FindById(userId);
            var newEvent = new Event(user, 
                                     createEventRequest.Description,
                                     DateTime.Parse(createEventRequest.Datetime));
            await _eventRepo.AddEvent(newEvent);
        }
        
        public async Task<List<Event>> GetEvents(string userId)
        {
            return await _userRepo.GetEvents(userId);
        }
    }
}
