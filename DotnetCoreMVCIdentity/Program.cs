using DotnetCoreMVCIdentity;
using DotnetCoreMVCIdentity.Data;
using DotnetCoreMVCIdentity.Models;
using DotnetCoreMVCIdentity.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Custom Code to Add DB and IdentityCore
//Register dbContext service
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConString")));
//To use database and adding identity together
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();
//Configure identity fields for custom validation
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireDigit = false;
});
//register services
//below first line is registering user claims, you can use anywhere
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
#endregion


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


#region Add Authentication Middleware
//To configure authentication, use authentication middleware
app.UseAuthentication();
#endregion


app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
