using BlazorApp1.DataBaseClasses;
using BlazorApp1.Service;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1; 

public sealed class DataBaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    
    public DataBaseContext(){}

    
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options) {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Tom", Login = "ad" , Pass = HashSha256Service.CreateSha256("12345678")},
            new User { Id = 2, Name = "Bob", Login = "da", Pass = HashSha256Service.CreateSha256("12345678")}
        );
    }
}

