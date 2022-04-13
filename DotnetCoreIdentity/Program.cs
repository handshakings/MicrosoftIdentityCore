using DotnetCoreIdentity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Register dbContext service
builder.Services.AddDbContext<AuthDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConString")));
//To use database and adding identity together
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//To configure authentication, use authentication middleware
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
