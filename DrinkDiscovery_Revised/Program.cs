using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DrinkDiscovery_Revised.Areas.Identity.Data;
using DrinkDiscovery_Revised.Models;
using DrinkDiscovery_Revised.Controllers;
using DrinkDiscovery_Revised.SMTP;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DrinkDiscovery_Revised_ContextConnection") ?? throw new InvalidOperationException("Connection string 'DrinkDiscovery_Revised_ContextConnection' not found.");
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddDbContext<DrinkDiscovery_Revised_Context>(options => options.UseSqlServer(connectionString, sqlServerOptions =>
{
    sqlServerOptions.CommandTimeout(60); // Set the timeout to 60 seconds or more
}));

builder.Services.AddDefaultIdentity<DrinkDiscovery_Revised_User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DrinkDiscovery_Revised_Context>().AddDefaultTokenProviders(); ;

// repository add
builder.Services.AddScoped<DrinkDiscoveryAdminContext>();
builder.Services.AddScoped<IRepository, EfRepository>();
// Register your custom UserService
builder.Services.AddScoped<UserService>();
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
