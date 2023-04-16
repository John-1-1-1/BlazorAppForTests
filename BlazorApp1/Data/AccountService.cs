﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazorApp1.Data; 

public class AccountService: IAccountService {

    private IHttpContextAccessor httpContextAccessor;
    private HttpClient httpClient;
    public AccountService(
        IHttpContextAccessor HttpContextAccessor) {
        httpContextAccessor = HttpContextAccessor;
    }

    public async Task Login() {
        var claims = new List<Claim> { 
            new Claim(ClaimTypes.Name, "person.Login"), 
            new Claim(ClaimTypes.Surname, "person.Name") };
        // создаем объект ClaimsIdentity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        CookieOptions options = new CookieOptions();
        options.Expires = DateTime.Now.AddDays(1);
        // установка аутентификационных куки
        await httpContextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
    }
    


    public void Init(ApplicationContext applicationContext) {
        
    }
}