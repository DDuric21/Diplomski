using CRM.DbContext;
using CRM.Models;

namespace CRM.Data
{
    public class SeedData
    {
        public static void CreateSeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CrmDbContext>();

                try
                {
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                if (!context.Addresses.Any())
                {
                    context.Addresses.AddRange(new List<Address>
                    {
                        new Address
                        {
                            FullAddress = "Ulica Grada Chicaga 33, 10000, Zagreb"
                        },
                        new Address
                        {
                            FullAddress = "Trg Bana Josipa Jelačića 1, 10000, Zagreb"
                        },
                        new Address
                        {
                            FullAddress = "Avenija Dubrovnik 24, 10000, Zagreb"
                        }
                    });

                    context.SaveChanges();
                }

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>
                    {
                        new Customer
                        {
                            Name = "Test Name1",
                            AddressId = 1,
                            Birthday = new DateTime(1995,05,16,0,0,0)
                        },
                        new Customer
                        {
                            Name = "Test Name2",
                            AddressId = 2,
                            Birthday = new DateTime(1970,01,01,0,0,0)
                        },
                        new Customer
                        {
                            Name = "Test Name3",
                            AddressId = 3,
                            Birthday = new DateTime(2000,03,21,0,0,0)
                        }

                    });

                    context.SaveChanges();
                }

                if (!context.Assets.Any())
                {
                    context.AddRange(new List<Asset>
                    {
                        new Asset
                        {
                            Name = "Mobilna Voice Usluga",
                            Price = 100,
                            CurrencyID = 0
                        },
                        new Asset
                        {
                            Name = "Fiksna Usluga",
                            Price = 150,
                            CurrencyID = 0
                        },
                        new Asset
                        {
                            Name = "Najam Opreme",
                            Price = 20,
                            CurrencyID = 0
                        },
                    });

                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>
                    {
                        new User
                        {
                            UserName = "Pero Perić",
                            UserEmail = "pero.peric@nepostoji.rh",
                            UserRoleId = 2
                        },
                        new User
                        {
                            UserName = "Ivo Ivić",
                            UserEmail = "ivo.ivic@nepostoji.rh",
                            UserRoleId = 1
                        },
                        new User
                        {
                            UserName = "Admin Adminić",
                            UserEmail = "admin.adminic@nepostoji.rh",
                            UserRoleId = 0
                        }
                    });

                    context.SaveChanges();
                }

                if (!context.CustomerAssets.Any())
                {
                    context.CustomerAssets.AddRange(new List<CustomerAssets>
                    {
                        new CustomerAssets
                        {
                            CustomerID = 1,
                            AssetID = 1
                        },
                        new CustomerAssets
                        {
                            CustomerID = 1,
                            AssetID = 2
                        },
                        new CustomerAssets
                        {
                            CustomerID = 2,
                            AssetID = 2
                        },
                        new CustomerAssets
                        {
                            CustomerID = 3,
                            AssetID = 1
                        },
                        new CustomerAssets
                        {
                            CustomerID = 3,
                            AssetID = 3
                        }
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
