using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ryzhanovskiy.University.Tinder.Core;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Core.Services;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Ryzhanovskyi.University.Tinder.Web.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

/*services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});*/

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.Cookie.Name = "AshProgHelpCookie";

    });


services.AddIdentity<User, IdentityRole>(
    options =>
    {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
    }).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IProfileService, ProfileService>();

services.AddTransient<IEmailSender, EmailSender>();
services.AddControllersWithViews();

builder.Services.RegisterCoreConfiguration(builder.Configuration);
builder.Services.RegisterCoreDependencies();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy();

app.MapRazorPages();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
