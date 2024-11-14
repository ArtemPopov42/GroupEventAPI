using Microsoft.Extensions.DependencyInjection;
using GroupEventAPI.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GroupEventAPI.Services
{
    public static class DataConnector
    {
        public static void ConnectDbContext(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(context => context.UseSqlServer(connectionString));
        }

        public static void AddRepos(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserRepo, UserRepo>();
            serviceCollection.AddTransient<IEventRepo, EventRepo>();
        }
    }
}
