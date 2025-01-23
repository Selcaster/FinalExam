using System;
using FinalExam.BL;
using FinalExam.DAL;
using FinalExam.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using FinalExam.BL.Services;
using FinalExam.Core.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
});
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddIdentity<User, IdentityRole>(opt => {
    opt.SignIn.RequireConfirmedEmail = true;
    opt.Password.RequiredLength = 3;
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequiredUniqueChars = 3;
    opt.SignIn.RequireConfirmedPhoneNumber = false;
    opt.SignIn.RequireConfirmedEmail = false;
    opt.SignIn.RequireConfirmedAccount = false;
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
})
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection(SmtpOptions.Name));
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Account/Login";
    opt.AccessDeniedPath = "/Home/AccessDenied";
});
builder.Services.AddControllersWithViews();
builder.Services.AddService();
builder.Services.AddRepositories();
builder.Services.AddAutoMapper();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute("login", pattern:
    "login", new
    {
        Controller = "Account",
        Action = "Login",
    });

app.MapControllerRoute("register", pattern:
    "register", new
    {
        Controller = "Account",
        Action = "Register"
    });
app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id:guid?}");

app.Run();