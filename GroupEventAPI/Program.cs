using GroupEventAPI.Services;
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

            var app = builder.Build();

            app.Run();
        }
    }
}