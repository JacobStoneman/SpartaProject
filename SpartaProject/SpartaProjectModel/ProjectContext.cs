using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel;
using SpartaProjectModel.Services;

namespace SpartaProjectDB
{
    public class ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SpartaProject;");
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int AccountType { get; set; }

        public override string ToString() => Name;
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
        public List<Order> Orders { get; } = new List<Order>();
        public List<Review> Reviews { get; } = new List<Review>();
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public float AverageRating { get; set; }
        public List<Review> Reviews { get; } = new List<Review>();

        public override string ToString() => Name;

        public float GetAverageRating()
        {
            ReviewService reviewService = new ReviewService(new ProjectContext());
            List<Review> allReviews = reviewService.GetAllProductReviews(ProductId);
            float avRating = 0;

            if (allReviews.Count == 0)
            {
                avRating = -1;
            }
            else
            {
                foreach (Review r in allReviews)
                {
                    avRating += r.Rating;
                }
                avRating /= allReviews.Count();
            }
            return avRating;
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
            ProductService productService = new ProductService(new ProjectContext());
            Product prod = productService.GetProductById(ProductId);
            return $"Order: {OrderId} - {prod.Name} - Ship Date: {ShipDate.Year}/{ShipDate.Month}/{ShipDate.Day}";
        }
    }

    public class Review
    {
        public int ReviewId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            CustomerService customerService = new CustomerService(new ProjectContext());
            Customer customer = customerService.GetCustomerById(CustomerId);
            User user = customerService.GetUserById(customer.UserId);
            return $"{user}: {Comment} - {Rating}/5";
        }
    }
}