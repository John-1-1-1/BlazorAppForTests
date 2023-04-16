namespace BlazorApp1.Data; 

public interface IAccountService {
    void Init(ApplicationContext applicationContext);
    Task Login();
}