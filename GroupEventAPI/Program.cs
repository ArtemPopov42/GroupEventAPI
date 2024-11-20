using GroupEventAPI.Data;
using GroupEventAPI.Services;
using GroupEventAPI.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace GroupEventAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConnectDbContext(builder.Configuration.GetConnectionString("Default"));
            builder.Services.AddRepos();
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddControllers();
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();

            app.UseRouting();
            app.MapControllers();

            app.Run(); 
        }
    }
}