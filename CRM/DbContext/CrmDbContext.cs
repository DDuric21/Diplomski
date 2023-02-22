using CRM.Models;
using Microsoft.EntityFrameworkCore;
namespace CRM.DbContext
{
    public class CrmDbContext : Microsoft.EntityFrameworkCore.DbContext //iz nekog razloga neće mi drugačije prepoznati
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {

        }
        
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
