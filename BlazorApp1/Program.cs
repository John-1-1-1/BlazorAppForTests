
using BlazorApp1;
using BlazorApp1.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
// аутентификация с помощью куки
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();

// получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(connection));

builder.Services.AddTransient<IDataBaseService,DataBaseService>();

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
app.MapControllers();
app.UseAuthentication(); // добавление middleware аутентификации
app.UseAuthorization(); // добавление middleware авторизации 
app.MapFallbackToPage("/_Host");
app.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);

// https://metanit.com/sharp/razorpages/2.6.php

app.Run();