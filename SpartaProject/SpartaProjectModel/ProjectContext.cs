using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel;

namespace SpartaProjectDB
{
    public class ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SpartaProject;");
    }

    public class User
	{
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int AccountType { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}

    public class Seller
	{
        public int SellerId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 

	}

    public class Customer
	{
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Order> Orders { get; set; }
	}

    public class Product
	{
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return Name;
        }
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
        [DefaultValue(false)] public bool Shipped { get; set; }

		public override string ToString()
		{
            using (ProjectContext db = new ProjectContext())
            {
                Product prod = db.Products.Where(p => p.ProductId == ProductId).FirstOrDefault();
                return $"Order: {OrderId} - {prod.Name} - Ship Date: {ShipDate.Year}/{ShipDate.Month}/{ShipDate.Day}";
            }
		}
	}
}