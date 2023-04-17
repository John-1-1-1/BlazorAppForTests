namespace BlazorApp1.Data;

public interface IDataBaseService {
    public bool IsExistUser(string login, string pass);
}