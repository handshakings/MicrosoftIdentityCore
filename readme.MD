# Asp.Net Core Identity

It is a universal framework to provide security to any .net application. It is microsoft .net core built in mechanism used to
* Create, Read, Update and Delete Users Accounts
* Account confirmation
* Authentication and Authorization
* Password Recovery
* Two factor Authentication with SMS
* Supports external login providers like Microsoft, Facebook, Google etc
* and much more


## Install below nuget packages
First two for database Code First and third for Adp.netcore Identity:-
* Microsoft.Entityframeworkcore.Tools
* Microsoft.Entityframeworkcore.SqlServer
* Microsoft.Aspnetcore.Identity.EntityFrameworkCore


## Add Database and IdentityCore
* Create folder named as Data and add new class named MyDbContext. Write constructore as below
```c#
public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {}
    }
```
* Add connection string in appsetting.json as 
```json
"ConnectionStrings": {
    "MyConString": "server=.; database=MyDb; Trusted_Connection=true"
  }
```
* Inject DbContext service and IdentityCore service in program.cs file as
```c#
//Register dbContext service
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConString")));
//To use database and adding identity together
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();
```
and add authentication middleware in program.cs file as
```c#
//To configure authentication, use authentication middleware
app.UseAuthentication();
```

## Add Migration and Update Dtabase as
Open package manager console and run below commands
(Note that you can add any number of migrations, all will be updated in single database tables)
* add-migration MyMigration
* update-database

## Microsoft IdentityCore
By default, there is build in Identity class, you can use. However it may not contains properties you need to validate for signup/login. For example firstName, LastName not exist in Identity class.
For this 
* Create your own class as ApplicationUser.cs and inherit it from IdentityCore class.
* In program.cs, change IdentityUser to ApplicationUser
* Pass ApplicationUser to IdentityDbContext class in MyDbContext.cs class. 
* change all IdentityUser to ApplicationUser in AccountRepository.cs
* create input fields for firstName and lastName in signup.cshtml
* add new migration with another name as addedApplicationUser and update database

