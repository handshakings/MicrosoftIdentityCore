using DotnetCoreMVCIdentity.Data;
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
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();
//injecting account repository
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
