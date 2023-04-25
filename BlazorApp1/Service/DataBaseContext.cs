using System.Diagnostics;
using BlazorApp1.DataBaseClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Service;

public sealed class DataBaseContext : DbContext {
    public DbSet<User?> Users { get; set; } = null!;
    public DbSet<PostUser> PostUsers { get; set; } = null!;
    public DbSet<Role> Role { get; set; } = null!;

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options) {
        Database.EnsureCreated(); // создаем базу данных при первом обращении
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {


        var postUser = new PostUser() { Id = 1, PostName = "Пост.." };
        var role1 = new Role() { Id = 1, Name = "Admin" };
        var role2 = new Role() { Id = 2, Name = "User" };
        var role3 = new Role() { Id = 3, Name = "Customer" };

        var user1 = new User() {
            Id = 1, Login = "ivan", PostId = 1, Name = "Иван", LastName = "Иванов",
            MiddleName = "Иванович", RoleId = 1, Pass = HashSha256Service.CreateSha256("12345678")
        };
        var user2 = new User() {
            Id = 2, Login = "ivan2", PostId = 1, Name = "Иван", LastName = "Иванов",
            MiddleName = "Иванович", RoleId = 2, Pass = HashSha256Service.CreateSha256("12345678")
        };
        var user3 = new User() {
            Id = 2, Login = "ivan3", PostId = 1, Name = "Иван", LastName = "Иванов",
            MiddleName = "Иванович", RoleId = 3, Pass = HashSha256Service.CreateSha256("12345678")
        };

        modelBuilder.Entity<PostUser>().HasData(postUser);
        modelBuilder.Entity<Role>().HasData(role1, role2, role3);
        modelBuilder.Entity<User>().HasData(user1, user2, user3);
    }
}