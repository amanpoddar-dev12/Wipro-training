using CarRental.Web.Data;
using CarRental.Web.Models;
using CarRental.Web.Repositories;
using CarRental.Web.Repositories.Impl;
using CarRental.Web.Services;
using CarRental.Web.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection
var connString = PropertyUtil.GetConnectionString(builder.Configuration, "DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(connString));

// Identity (UI + Roles)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
// .AddDefaultUI();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// DI for Repositories/Services
builder.Services.AddScoped<ICarLeaseRepository, CarLeaseRepository>();
builder.Services.AddScoped<ICarLeaseService, CarLeaseService>();

var app = builder.Build();

// Seed roles & admin on startup
using (var scope = app.Services.CreateScope())
{
    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string[] roles = new[] { "Admin", "Staff", "Customer" };
    foreach (var r in roles)
        if (!await roleMgr.RoleExistsAsync(r))
            await roleMgr.CreateAsync(new IdentityRole(r));

    var adminEmail = "admin@carrental.local";
    var admin = await userMgr.FindByEmailAsync(adminEmail);
    if (admin == null)
    {
        admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
        await userMgr.CreateAsync(admin, "Admin@12345");
        await userMgr.AddToRoleAsync(admin, "Admin");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Identity UI
app.Run();
