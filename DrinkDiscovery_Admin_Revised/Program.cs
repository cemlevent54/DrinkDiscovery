using DrinkDiscovery_Admin_Revised.IdentityInfos;
using DrinkDiscovery_Admin_Revised.Models;
//using DrinkDiscovery_Revised.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using DrinkDiscovery_Admin_Revised.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var identityconnectionString = builder.Configuration.GetConnectionString("DrinkDiscovery_Admin_Revised_ContextConnection") ?? throw new InvalidOperationException("Connection string 'DrinkDiscovery_Admin_Revised_ContextConnection' not found.");

builder.Services.AddDbContext<DrinkDiscovery_Admin_Revised_Context>(options => options.UseSqlServer(identityconnectionString));
//builder.Services.AddDefaultIdentity<DrinkDiscovery_Admin_Revised_User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DrinkDiscovery_Admin_Revised_Context>();
// Add services to the container.
// Identity Framework
builder.Services.AddDefaultIdentity<DrinkDiscovery_Admin_Revised_User>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;  // Optional: require email confirmation
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DrinkDiscovery_Admin_Revised_Context>();
    


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Context>();
builder.Services.AddScoped<IRepository, EfRepository>();
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(identityconnectionString));
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
