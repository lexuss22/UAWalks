using Microsoft.EntityFrameworkCore;
using UAWalks.API.Model.Domain;

namespace UAWalks.API.Data
{
    public class UAWalksDbContext: DbContext
    {
        public UAWalksDbContext(DbContextOptions<UAWalksDbContext> options) : base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
    }
}
