using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class 
    DatabaseContext: DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .Property(s => s.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<User> Users { get; set; }
}