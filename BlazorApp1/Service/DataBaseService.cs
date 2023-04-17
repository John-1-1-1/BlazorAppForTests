using BlazorApp1.Data;

namespace BlazorApp1.Service; 

public class DataBaseService: IDataBaseService {

    readonly DataBaseContext _dataBaseContext = new(); 

    public DataBaseService(DataBaseContext dataBaseContext) {
        this._dataBaseContext = dataBaseContext;
        
    }

    public bool IsExistUser(string login, string pass) {
        var user = _dataBaseContext.Users.FirstOrDefault(p => p.Login == login && p.Pass == pass);
        return user != null;
    } 
}