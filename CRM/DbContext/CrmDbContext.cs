﻿using CRM.Models;
using Microsoft.EntityFrameworkCore;
namespace CRM.DbContext
{
    public class CrmDbContext : Microsoft.EntityFrameworkCore.DbContext //iz nekog razloga neće mi drugačije prepoznati
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Asset>();
            modelBuilder.Entity<CustomerAssets>().HasKey(
                x => new
                {
                    x.CustomerID,
                    x.AssetID
                });
        }
        
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAssets> CustomersAssets { get; set; }
    }
}
