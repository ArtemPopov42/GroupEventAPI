using GroupEventAPI.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Data
{
    public class EventRepo: IEventRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public EventRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEvent(Event userEvent)
        {
            await _dbContext.AddAsync(userEvent);
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task RemoveEvent(Event userEvent)
        {
            _dbContext.Remove(userEvent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Event?> GetById(string eventId)
        {
            Event? result = await _dbContext.FindAsync<Event>(eventId);

            return result;
        }
    }
}
