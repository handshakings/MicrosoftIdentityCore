using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreMVCIdentity.Data
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {}
    }
}
