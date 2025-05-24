using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UAWalks.API.Data
{
    public class UAWalksAuthDbContext : IdentityDbContext
    {
        public UAWalksAuthDbContext(DbContextOptions<UAWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ReaderRoleId = "6fb58203-313a-46e6-9b1e-810a485d398f";
            var AdminRoleId = "896d24fa-1b22-4f37-b0f5-75fcd0e6c007";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = ReaderRoleId,
                    Name = "Reader",
                    ConcurrencyStamp = ReaderRoleId,
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = AdminRoleId,
                    Name = "Admin",
                    ConcurrencyStamp = AdminRoleId,
                    NormalizedName = "Admin".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
