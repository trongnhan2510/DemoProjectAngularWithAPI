using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    public class StoreManagementDbContext : DbContext
    {
        public StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> options) : base(options)
        {

        }
        #region DbSet
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Customer
            modelBuilder.Entity<Customer>(e =>
            {
                e.ToTable("Customer");
                e.HasKey(x => x.Customer_ID);
                e.Property(x => x.Customer_Name).IsRequired().HasMaxLength(200);
                e.Property(x => x.Address).IsRequired().HasMaxLength(500);
                e.Property(x => x.Telephone).IsRequired().HasMaxLength(15);
            });
            //Employee
            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("Employee");
                e.HasKey(x => x.Employee_ID);
                e.Property(x => x.Employee_Name).IsRequired().HasMaxLength(200);
                e.Property(x => x.Address).IsRequired().HasMaxLength(500);
                e.Property(x => x.DateOfBirth).IsRequired();
                e.Property(x => x.TelePhone).IsRequired().HasMaxLength(15);
            });

            modelBuilder.Entity<Order>()
            .HasOne<Employee>(s => s.Employee)
            .WithMany(g => g.Orders)
            .HasForeignKey(s => s.Employee_ID);
            modelBuilder.Entity<Order>()
            .HasOne<Customer>(s => s.Customer)
            .WithMany(g => g.Orders)
            .HasForeignKey(s => s.Customer_ID);

            //User
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(x => x.User_ID);
                e.HasIndex(x => x.Username).IsUnique();
                e.Property(x => x.Password).IsRequired();
            });
        }
    }
}
