using BlazorApp1.Shared;

namespace BlazorApp1.Data; 

public class DataBaseManager {

    private readonly DataBaseContext _dataBaseContext;
    
    public DataBaseManager(DataBaseContext dataBaseContext) {
        this._dataBaseContext = dataBaseContext;
    }

    public bool IsExistUser(string login, string pass) {
        var user = _dataBaseContext.Users.FirstOrDefault(p => p.Login == login && p.Pass == pass);
        return user != null;
    } 
}