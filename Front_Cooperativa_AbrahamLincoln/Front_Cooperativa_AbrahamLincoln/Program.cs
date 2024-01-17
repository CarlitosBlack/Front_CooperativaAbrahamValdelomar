using Microsoft.Extensions.Hosting;
using Front_Cooperativa_AbrahamLincoln.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Front_Cooperativa_AbrahamLincoln.Servicios;
using Front_Cooperativa_AbrahamLincoln.Models;
using System.Configuration;
using System;
using Front_Cooperativa_AbrahamLincoln;

var builder = WebApplication.CreateBuilder(args);

//INSTANCIA DE STARTUP CREADO 4/1/2024
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true; // La cookie de sesión solo puede ser accedida mediante HTTP
    options.Cookie.IsEssential = true; // Marcar la cookie de sesión como esencial para el funcionamiento de la app
});

//builder.Services.AddTransient<Context>();
builder.Services.AddControllers();
builder.Services.AddScoped<LoginService>();
// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Login/login";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

//builder.Services.AddScoped<IServiceCollection>();


builder.Services.AddScoped<LoginController>();
//builder.Services.AddScoped<ISharedService, SharedService>();
//builder.Services.AddScoped<ConsultaController()>
//builder.Services.AddSingleton<ISharedService, SharedService>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

//INSTANCIA DE STARTUP CREADO 4/1/2024
startup.Configure(app, app.Lifetime);

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    //pattern: "{controller=Login}/{action=login}/{id?}");
    pattern: "{controller=Login}/{action=login}/{id?}");

app.Run();
