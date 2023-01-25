using Microsoft.EntityFrameworkCore;
using TorreControlRazeDAL.Model_Scaffold;
using Microsoft.AspNetCore.Identity;
using TorreControlRaze.Data;
using Microsoft.CodeAnalysis.Options;
using TorreControlRaze.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CspharmaInformacionalContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("EFCConexion"))
    );
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(Option =>
{
    Option.IdleTimeout = TimeSpan.FromMinutes(2);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
