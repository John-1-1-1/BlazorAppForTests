using System.Security.Claims;
using BlazorApp1.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Controllers; 

public class AuthorizationController : Controller {
    private readonly IDataBaseService _dataBaseService;
    public AuthorizationController(IDataBaseService dataBaseService) {
        _dataBaseService = dataBaseService;
    }
    
    [HttpGet("login")]
    public IActionResult Login(string login, string hashPass) {

        if (!_dataBaseService.IsExistUser(login, hashPass)) {
            return Ok("UserNotFound");
        }
        
        // TODO: add another data 
        var claims = new List<Claim> { 
            new Claim("Login", login) };
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