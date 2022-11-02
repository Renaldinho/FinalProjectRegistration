using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class StudentDbContext: DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .Property(s => s.Id)
            .ValueGeneratedOnAdd();
    }

    public DbSet<Student> Students { get; set; }
}