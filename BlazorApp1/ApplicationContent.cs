using BlazorApp1.DataBaseClasses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1; 

public sealed class DataBaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Tom", Login = "ad" , Pass = "12345"},
            new User { Id = 2, Name = "Bob", Login = "da", Pass = "12345"}
        );
    }
}

