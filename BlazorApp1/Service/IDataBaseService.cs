using BlazorApp1.DataBaseClasses;

namespace BlazorApp1.Service;

public interface IDataBaseService {
    public bool IsExistUser(string login, string pass);
    public List<User> GetUsers();

    public User? GetUserByLogin(string login);
}