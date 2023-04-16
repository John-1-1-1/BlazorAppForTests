using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Controllers; 

public class AuthorizationController : Controller {
    [HttpGet("login")]
    public IActionResult Login(string login, string pass) {
        
        var claims = new List<Claim> { 
            new Claim("Login", login), 
            new Claim(ClaimTypes.Surname, pass) };
        // создаем объект ClaimsIdentity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        // установка аутентификационных куки
        HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
        return Redirect("/");
    }

    [HttpGet("logout")]
    public IActionResult Logout() {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/");
    }
    
}