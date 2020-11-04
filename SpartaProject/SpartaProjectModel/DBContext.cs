using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class BloggingContext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SpartaProject;");
    }

    public class Seller
	{
        public int SellerId { get; set; }
        public string Name { get; set; }

	}

    public class Customer
	{
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
	}

    public class Product
	{
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
	}

    public class Order
	{
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
	}
}