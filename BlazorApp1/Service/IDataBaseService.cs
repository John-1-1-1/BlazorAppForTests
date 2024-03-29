﻿using System.Collections;
using BlazorApp1.DataBaseClasses;

namespace BlazorApp1.Service;

public interface IDataBaseService {
    public bool IsExistUser(string login, string pass);
    public List<User>? GetUsers();

    public User? GetUserByLogin(string login);
    public List<Role>? GetRoles();
    public List<PostUser>? GetPosts();
    public void DeleteUser(int userId);
    public User GetUserById(int userId);
    public void AddUser(User user);
    public void AddRole(Role role);
    public void DeleteRole(int roleId);
    public void AddPost(PostUser post);
    public void DeletePost(int postId);
    public List<Order> GetOrders();
    public void AddOrder(Order order);

    public void GetWork(Order order, int userId);
    public List<Order> GetOrdersByUserId(int userId);
    public void PerformWork(Order order);
    public List<Order> GetOrdersByCustomerId(int userId);
}