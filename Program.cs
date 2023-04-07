using Microsoft.EntityFrameworkCore;
using NetCoreIdentity.CustomDescriber;
using NetCoreIdentity.Data.Context;
using NetCoreIdentity.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
}).AddErrorDescriber<CustomErrorDescriber>().AddEntityFrameworkStores<ApplicationContext>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    opt.Cookie.Name = "Cookies";
    opt.ExpireTimeSpan = TimeSpan.FromSeconds(1);
    opt.LoginPath = new PathString("/Home/SignIn");
});



builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseSqlServer("YourConnectionString");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=SignIn}/{id?}");

app.Run();
