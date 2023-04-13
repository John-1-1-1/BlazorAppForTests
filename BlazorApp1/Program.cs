using System.Security.Claims;
using BlazorApp1;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp1.Data;
using BlazorApp1.DataBaseClasses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IAccountService, AccountService>();
// аутентификация с помощью куки
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();


// получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContextFactory<ApplicationContext>(options => options.UseNpgsql(connection));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.UseAuthentication(); // добавление middleware аутентификации
app.UseAuthorization(); // добавление middleware авторизации 
app.MapFallbackToPage("/_Host");
app.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);
// получение данных TODO:TESTS
app.MapGet("/data", (ApplicationContext db) => db.Users.ToList());

var context = app.Services.CreateScope().ServiceProvider.GetService<ApplicationContext>();
var r = app.Services.GetService<IAccountService>();
r.Init(context);
// https://metanit.com/sharp/razorpages/2.6.php

app.MapPost("/login", async (string? returnUrl,
    ApplicationContext db, HttpContext context) =>
{
    // получаем из формы email и пароль
    var form = context.Request.Form;
    // если email и/или пароль не установлены, посылаем статусный код ошибки 400
    if (!form.ContainsKey("email") || !form.ContainsKey("password"))
        return Results.BadRequest("Email и/или пароль не установлены");
 
    string email = form["email"];
    string password = form["password"];
     
    // находим пользователя 
    User? person = db.Users.FirstOrDefault(p => p.Login == email && 
                                                p.HashPass == password);
    // если пользователь не найден, отправляем статусный код 401
    if (person is null) return Results.Unauthorized();
 
    var claims = new List<Claim> { 
        new Claim(ClaimTypes.Name, person.Login), 
        new Claim(ClaimTypes.Surname, person.Name) };
    // создаем объект ClaimsIdentity
    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    // установка аутентификационных куки
    await context.SignInAsync(claimsPrincipal);
    return Results.Redirect(returnUrl??"/");
});

app.Run();