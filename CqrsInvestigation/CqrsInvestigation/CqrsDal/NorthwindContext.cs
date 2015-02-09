using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using CqrsDomain.Northwind.Model;


namespace Northwind.Repositories.Entity
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(string connStr) : base(connStr) { }

        #region Properties
        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrdersDetails { get; set; }

        public DbSet<Territory> Territories { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CqrsDomain.Northwind.Model.Product>().Property(p => p.ProductId).HasColumnName("ProductID");
            modelBuilder.Entity<CqrsDomain.Northwind.Model.Product>().Property(p => p.Name).HasColumnName("ProductName");

            modelBuilder.Entity<CqrsDomain.Northwind.Model.Category>().Property(c => c.CategoryId).HasColumnName("CategoryID");
            modelBuilder.Entity<CqrsDomain.Northwind.Model.Category>().Property(c => c.CategoryName).HasColumnName("CategoryName");

            modelBuilder.Entity<CqrsDomain.Northwind.Model.Supplier>().Property(s => s.Id).HasColumnName("SupplierID");
            modelBuilder.Entity<CqrsDomain.Northwind.Model.Supplier>().Property(s => s.Name).HasColumnName("CompanyName");

            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("OrderID");
            modelBuilder.Entity<Order>().Property(o => o.Date).HasColumnName("OrderDate");

            modelBuilder.Entity<Customer>().Property(c => c.Id).HasColumnName("CustomerID");
            modelBuilder.Entity<Customer>().Property(c => c.Name).HasColumnName("CompanyName");

            modelBuilder.Entity<Employee>().Property(e => e.Id).HasColumnName("EmployeeID");

            modelBuilder.Entity<OrderDetail>().HasKey(o => new { o.OrderId, o.ProductId });
            modelBuilder.Entity<OrderDetail>().ToTable("Order Details");

            modelBuilder.Entity<Territory>().Property(t => t.Id).HasColumnName("TerritoryID");
            modelBuilder.Entity<Territory>().Property(t => t.Description).HasColumnName("TerritoryDescription");
        }
        #endregion
    }
}
