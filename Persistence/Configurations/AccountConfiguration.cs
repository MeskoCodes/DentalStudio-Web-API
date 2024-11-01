using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            var admin = new Account
            {
                FirstName = "Admin",
                LastName = "Admin",
                Id = "595af844-b3f7-4d70-87ca-eb9c08a2368a",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                UserName = "admin@test.com",
                NormalizedUserName = "ADMIN@TEST.COM",
                EmailConfirmed = true
            };

            var user = new Account
            {
                FirstName = "User",
                LastName = "User",
                Id = "4334dd38-cdd9-4ba8-99c6-856220356d4a",
                Email = "user@test.com",
                NormalizedEmail = "USER@TEST.COM",
                UserName = "user@test.com",
                NormalizedUserName = "USER@TEST.COM",
                EmailConfirmed = true
            };

            builder.HasData(admin, user);
        }
    }
}