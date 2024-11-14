using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentPortal.Models.StudentAccountEntity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbcontext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<StudentUser, IdentityRole>(option =>
{
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 8;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = true;
    option.User.RequireUniqueEmail = true;
    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;


});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production s cenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
