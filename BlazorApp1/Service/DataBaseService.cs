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

    public List<User> GetUsers() {
        return _dataBaseContext.Users.Include(b => b.Post).ToList();
    }
}