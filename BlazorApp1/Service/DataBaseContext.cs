using System.Diagnostics;
using BlazorApp1.DataBaseClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Service; 

public sealed class DataBaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<PostUser> PostUsers { get; set; } = null!;
    public DbSet<Userr> Userrs { get; set; } = null!;
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options) {
        Database.EnsureCreated();   // создаем базу данных при первом обращении

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>()
            .HasOne(p => p.Post)
            .WithOne(t => t.User)
            .HasForeignKey<User>(p => p.PostId).IsRequired();
        var r = new PostUser() { Id = 1, PostName = "sf" };
        var u = new User() {
            Id = 1, Login = "ivan", PostId = 1, Name = "Иван", LastName = "Иванов", 
            MiddleName = "Иванович", Role = "d", Pass = HashSha256Service.CreateSha256("12345678")};
        modelBuilder.Entity<PostUser>().HasData(r);
        modelBuilder.Entity<User>().HasData(u);
        
        modelBuilder.Entity<Userr>().HasData(
            new Userr { Id = 1, Name = "Tom", Age = 23 },
            new Userr { Id = 2, Name = "Alice", Age = 26 },
            new Userr { Id = 3, Name = "Sam", Age = 28 }
        );
    }
}
public class Userr
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}