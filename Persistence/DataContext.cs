using Domain.Entities;
using Domain.Entities.Billing;
using Domain.Entities.Scheduling;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public sealed class DataContext : IdentityDbContext<
    Account,
    AccountRole,
    string,
    IdentityUserClaim<string>,
    AccountIdentityUserRole,
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>
>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>().ToTable("AspNetUsers");
        modelBuilder.Entity<AccountIdentityUserRole>().ToTable("AspNetUserRoles");
        modelBuilder.Entity<AccountRole>().ToTable("AspNetRoles");

        modelBuilder.Entity<AccountIdentityUserRole>()
            .HasOne(p => p.User)
            .WithMany(b => b.Roles)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<AccountIdentityUserRole>()
            .HasOne(x => x.Role)
            .WithMany(x => x.Roles)
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
