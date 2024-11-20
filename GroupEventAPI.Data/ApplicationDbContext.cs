using GroupEventAPI.Types;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GroupEventAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Event> Events { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var eventModel = modelBuilder.Entity<Event>();
            eventModel.HasKey(e => e.EventId);
            eventModel.Property(e => e.Description);
            eventModel.Property(e => e.Date)
                      .HasColumnType("datetime2");
            eventModel.HasOne(e => e.Creator)
                      .WithMany(u => u.Events)
                      .HasForeignKey(e => e.CreatorId);
        }
    }
}
