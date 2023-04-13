using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazorApp1.Data; 

public class AccountService: IAccountService {

    private HttpContext context;
    
    public AccountService(IHttpContextAccessor  context) {
        this.context = context.HttpContext;
    }

    public void Login() {
        var claims = new List<Claim> { 
            new Claim(ClaimTypes.Name, "person.Login"), 
            new Claim(ClaimTypes.Surname, "person.Name") };
        // создаем объект ClaimsIdentity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        // установка аутентификационных куки
        context.SignInAsync(claimsPrincipal);
    }

    public void Init(ApplicationContext applicationContext) {
        
    }
}