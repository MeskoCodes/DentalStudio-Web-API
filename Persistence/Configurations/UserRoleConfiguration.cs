using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<AccountIdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<AccountIdentityUserRole> builder)
        {
            builder.HasData(
                new AccountIdentityUserRole
                {
                    RoleId = "1", //ADMIN
                    UserId = "595af844-b3f7-4d70-87ca-eb9c08a2368a" //admin@test.com
                },
                new AccountIdentityUserRole
                {
                    RoleId = "2", //fachadmin
                    UserId = "4334dd38-cdd9-4ba8-99c6-856220356d4a" //org@test.com
                });
        }
    }
}