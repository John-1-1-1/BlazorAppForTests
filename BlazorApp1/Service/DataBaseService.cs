using BlazorApp1.DataBaseClasses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Service; 

public class DataBaseService: IDataBaseService {

    readonly DataBaseContext _dataBaseContext; 

    public DataBaseService(DataBaseContext dataBaseContext) {
        this._dataBaseContext = dataBaseContext;
    }

    public bool IsExistUser(string login, string pass) {
        var user = _dataBaseContext.Users.FirstOrDefault(p => p.Login == login && p.Pass == pass);
        return user != null;
    }

    public List<User>? GetUsers() {
        return _dataBaseContext.Users.Include(b => b.Post).Include(b => b.Role).ToList();
    }

    public User? GetUserByLogin(string login) {
        return _dataBaseContext.Users.Include(b => b.Post).Include(b => b.Role).FirstOrDefault(u => u.Login == login);
    }

    public List<Role>? GetRoles() {
        return _dataBaseContext.Roles.ToList();
    }
    
    public List<PostUser>? GetPosts() {
        return _dataBaseContext.PostUsers.ToList();
    }

    public void DeleteUser(int userId) {
        _dataBaseContext.Users.Remove(GetUserById(userId));
        _dataBaseContext.SaveChanges();
    }

    public User GetUserById(int userId) {
        return _dataBaseContext.Users.FirstOrDefault(u => u.Id == userId);
    }

    public void AddUser(User user) {
        _dataBaseContext.Users.Add(user);
        _dataBaseContext.SaveChanges();
    }

    public void AddRole(Role role) {
        _dataBaseContext.Roles.Add(role);
        _dataBaseContext.SaveChanges();
    }

    public void DeleteRole(int roleId) {
        
        _dataBaseContext.Roles.Remove(GetRoleById(roleId));
        _dataBaseContext.SaveChanges();
    }

    public void AddPost(PostUser post) {
        _dataBaseContext.PostUsers.Add(post);
        _dataBaseContext.SaveChanges();
    }

    public void DeletePost(int postId) {
        _dataBaseContext.PostUsers.Remove(GetPostById(postId));
        _dataBaseContext.SaveChanges();
    }

    public List<Order> GetOrders() {
        return _dataBaseContext.Orders.
            Include(o => o.User).
            Include(o => o.OrderState).ToList();
    }

    public void AddOrder(Order order) {
        var orderState = new OrderStates() {
            StateOrder = 1,
        };
        order.OrderState = orderState;
        _dataBaseContext.Orders.Add(order);
        _dataBaseContext.SaveChanges();
    }

    public void GetWork(Order order, int userId) {
        order.OrderState.UserId = userId;
        order.OrderState.StateOrder += 1;
        
        _dataBaseContext.Orders.Update(order);
        _dataBaseContext.SaveChanges();
    }

    public List<Order> GetOrdersByUserId(int userId) {
        return _dataBaseContext.Orders.
                Include(o => o.User).
                Include(o => o.OrderState).
            Where(o => o.OrderState.UserId == userId).ToList();
    }

    public void PerformWork(Order order) {
        order.OrderState.StateOrder = States.ListStates[States.ListStates.Count-1].id;
        _dataBaseContext.Orders.Update(order);
        _dataBaseContext.SaveChanges();
    }

    public List<Order> GetOrdersByCustomerId(int userId) {
        return _dataBaseContext.Orders.
            Include(o => o.User).
            Include(o => o.OrderState).
            Where(o => o.UserId == userId).ToList();
    }

    private PostUser GetPostById(int postId) {
        return _dataBaseContext.PostUsers.FirstOrDefault(u => u.Id == postId);
    }

    private Role GetRoleById(int roleId) {
        return _dataBaseContext.Roles.FirstOrDefault(u => u.Id == roleId);
    }
}