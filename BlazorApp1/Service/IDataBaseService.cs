using System.Collections;
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
}