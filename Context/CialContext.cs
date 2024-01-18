using CialMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CialMVC.Context
{
    public class CialContext : IdentityDbContext
    {
        public CialContext(DbContextOptions<CialContext> options) : base(options) { }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
