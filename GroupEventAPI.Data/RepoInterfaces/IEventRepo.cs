using GroupEventAPI.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Data
{
    public interface IEventRepo
    {
        public Task AddEvent(Event userEvent);

    }
}
