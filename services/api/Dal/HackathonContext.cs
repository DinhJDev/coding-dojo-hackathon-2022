using Hackathon.Core;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Dal
{
    public class HackathonContext : DbContext
    {
        public HackathonContext(DbContextOptions<HackathonContext> options) : base(options)
        {

        }

        public DbSet<HotZone>? HotZones { get; set; }
        public DbSet<LostFound>? LostFounds { get; set; }
        public DbSet<Supply>? Supplies{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}