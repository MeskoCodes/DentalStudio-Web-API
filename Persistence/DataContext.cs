global using Domain.Entities;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Persistence.Configurations;
using Domain.Entities.Billing;
using Domain.Entities.JointTables;

namespace Persistence;

public sealed class DataContext(DbContextOptions options) : IdentityDbContext<
    Account,
    AccountRole,
    string,
    IdentityUserClaim<string>, // TUserClaim
    AccountIdentityUserRole, // TUserRole,
    IdentityUserLogin<string>, // TUserLogin
    IdentityRoleClaim<string>, // TRoleClaim
    IdentityUserToken<string> // TUserToken
>(options)
{
 protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Account>().ToTable("AspNetUsers");
    modelBuilder.Entity<AccountIdentityUserRole>().ToTable("AspNetUserRoles");
    modelBuilder.Entity<AccountRole>().ToTable("AspNetRoles");

    // Povezivanje Account sa AccountIdentityUserRole
    modelBuilder.Entity<AccountIdentityUserRole>()
        .HasOne(p => p.User)
        .WithMany(b => b.AccountRoles)  // Koristi novu kolekciju AccountRoles
        .HasForeignKey(p => p.UserId);

    // Povezivanje AccountRole sa AccountIdentityUserRole
    modelBuilder.Entity<AccountIdentityUserRole>()
        .HasOne(x => x.Role)
        .WithMany(x => x.AccountRoleAssociations)  // Koristi novu kolekciju AccountRoleAssociations
        .HasForeignKey(p => p.RoleId);

    modelBuilder.ApplyConfiguration(new RoleConfiguration());
    modelBuilder.ApplyConfiguration(new AccountConfiguration());
    modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
}



    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Patient> Patients { get; set; }
}
