using BlazorApp1.DataBaseClasses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1; 

public sealed class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Tom", Login = "ad" , HashPass = "12345"},
            new User { Id = 2, Name = "Bob", Login = "da", HashPass = "12345"}
        );
    }
}

