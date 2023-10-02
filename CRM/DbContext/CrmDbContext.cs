using CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.DbContext
{
    public class CrmDbContext : Microsoft.EntityFrameworkCore.DbContext //iz nekog razloga neće mi drugačije prepoznati
    {
        public static CrmDbContext _context;

        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {
            _context = this;
        }

        public static CrmDbContext CreateNewContext()
        {
            if(_context != null)
            {
                return _context;
            }
            else
            {
                var builder = WebApplication.CreateBuilder();
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                var optionsBuilder = new DbContextOptionsBuilder();
                var options = (DbContextOptions<CrmDbContext>) optionsBuilder.UseSqlServer(connectionString).Options;

                _context = new CrmDbContext(options);

                return _context;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Asset>();
            modelBuilder.Entity<CustomerAssets>();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<CustomerAssets> CustomerAssets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
