using FinalExp.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExp.Data.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt) {}

       public DbSet<Blog> Blogs { get; set; }
       public DbSet<AppUser> Users { get; set; }
    }
}
