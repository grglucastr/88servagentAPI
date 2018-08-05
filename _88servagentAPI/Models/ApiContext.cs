using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _88servagentAPI.Models
{
    public class ApiContext : DbContext
    {
        public DbSet<Device> Device { get; set; }
        public DbSet<HeatHumidity> HeatHumidity { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationRecipient> NotificationRecipient { get; set; }
        public DbSet<NotificationUser> NotificationUser { get; set; }
  
        public ApiContext(DbContextOptions<ApiContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }        
    }
}
