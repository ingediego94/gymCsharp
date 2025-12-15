using gym.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace gym.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Restrictions for:
        
        // Users:
        var user = modelBuilder.Entity<User>();
        user.HasIndex(u => u.DocNum)
            .IsUnique();
        user.HasIndex(u => u.Email)
            .IsUnique();

        // Branches:
        var branch = modelBuilder.Entity<Branch>();
        branch.HasIndex(b => b.BranchName)
            .IsUnique();
        
        // Admins:
        var admin = modelBuilder.Entity<Admin>();
        admin.HasIndex(a => a.Email)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
    
    // tables:
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Payment> Payments { get; set; }
    
}