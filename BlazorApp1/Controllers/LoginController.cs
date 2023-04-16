using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Controllers; 

public class LoginController : Controller {
    // GET
    [HttpGet("login")]
    public IActionResult Index1(string login, string pass) {
        
        var claims = new List<Claim> { 
            new Claim(ClaimTypes.Name, "person.Login"), 
            new Claim(ClaimTypes.Surname, "person.Name") };
        // создаем объект ClaimsIdentity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        CookieOptions options = new CookieOptions();
        options.Expires = DateTime.Now.AddDays(1);
        // установка аутентификационных куки
        HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
        return Redirect("/");
    }
    
   
}