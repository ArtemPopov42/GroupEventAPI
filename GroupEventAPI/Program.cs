using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using System.Text;

namespace GroupEventAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}