using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DrinkDiscovery_Revised.Areas.Identity.Data;
using DrinkDiscovery_Revised.Models;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DrinkDiscovery_Revised_ContextConnection") ?? throw new InvalidOperationException("Connection string 'DrinkDiscovery_Revised_ContextConnection' not found.");

builder.Services.AddDbContext<DrinkDiscovery_Revised_Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<DrinkDiscovery_Revised_User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DrinkDiscovery_Revised_Context>().AddDefaultTokenProviders(); ;

// repository add
builder.Services.AddScoped<DrinkDiscoveryAdminContext>();
builder.Services.AddScoped<IRepository, EfRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
