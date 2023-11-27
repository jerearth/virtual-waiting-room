using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reason> Reason { get; set; }
        public DbSet<RoomTemplate> RoomTemplates { get; set; }
        public DbSet<ReasonTemplate> ReasonTemplates { get; set; }
        public DbSet<QueuedUser> QueuedUsers { get; set; }
        public DbSet<RoomAdmin> RoomAdmins { get; set; }
        public DbSet<AllowedUser> AllowedUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}