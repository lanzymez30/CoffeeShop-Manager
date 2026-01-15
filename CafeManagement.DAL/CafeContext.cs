using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CafeManagement.Entity.Entities;
using System.Configuration;
using System;

namespace CafeManagement.DAL
{
    public class CafeContext : DbContext
    {
        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Table> Tables => Set<Table>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public DbSet<Shift> Shifts => Set<Shift>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connStr = ConfigurationManager.ConnectionStrings["CafeDB"]?.ConnectionString
                                 ?? "Data Source=.;Initial Catalog=CafeDB_VJU2025;Integrated Security=True;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Config quan hệ
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Order>().HasOne(o => o.Table).WithMany(t => t.Orders).HasForeignKey(o => o.TableId);
            modelBuilder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(od => od.OrderId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.Product).WithMany(p => p.OrderDetails).HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { AppUserId = 1, UserName = "admin", PasswordHash = "1", Role = "Admin", FullName = "Nguyễn Từ Lân", IsActive = true, CreatedDate = DateTime.Now },
                new AppUser { AppUserId = 2, UserName = "staff", PasswordHash = "1", Role = "Staff", FullName = "Nhân viên", IsActive = true, CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Cà phê Việt Nam", Description = "Đậm đà bản sắc", IsActive = true },
                new Category { CategoryId = 2, CategoryName = "Trà Trái Cây Trend", Description = "Mát lạnh", IsActive = true },
                new Category { CategoryId = 3, CategoryName = "Trà Sữa & Kem", Description = "Béo ngậy", IsActive = true },
                new Category { CategoryId = 4, CategoryName = "Đá Xay & Smoothie", Description = "Sảng khoái", IsActive = true }
            );

            modelBuilder.Entity<Product>().HasData(
                // Cà phê
                new Product { ProductId = 1, ProductName = "Cà phê Muối Huế", CategoryId = 1, Price = 29000, IsAvailable = true },
                new Product { ProductId = 2, ProductName = "Cà phê Trứng Hà Nội", CategoryId = 1, Price = 35000, IsAvailable = true },
                new Product { ProductId = 3, ProductName = "Bạc Xỉu Cốt Dừa", CategoryId = 1, Price = 32000, IsAvailable = true },
                new Product { ProductId = 4, ProductName = "Cold Brew Cam Vàng", CategoryId = 1, Price = 45000, IsAvailable = true },
                new Product { ProductId = 5, ProductName = "Cà phê Sữa Hạt Dẻ", CategoryId = 1, Price = 39000, IsAvailable = true },
                new Product { ProductId = 6, ProductName = "Latte Khoai Môn", CategoryId = 1, Price = 42000, IsAvailable = true },
                new Product { ProductId = 7, ProductName = "Cà Phê Dừa Đá Xay", CategoryId = 1, Price = 39000, IsAvailable = true },
                new Product { ProductId = 8, ProductName = "Espresso Tonic", CategoryId = 1, Price = 35000, IsAvailable = true },

                // Trà Trái Cây
                new Product { ProductId = 9, ProductName = "Trà Mãng Cầu Xiêm", CategoryId = 2, Price = 35000, IsAvailable = true },
                new Product { ProductId = 10, ProductName = "Trà Măng Cụt Hoa Đậu Biếc", CategoryId = 2, Price = 45000, IsAvailable = true },
                new Product { ProductId = 11, ProductName = "Trà Ổi Hồng Muối Ớt", CategoryId = 2, Price = 35000, IsAvailable = true },
                new Product { ProductId = 12, ProductName = "Trà Dâu Tằm Pha Lê", CategoryId = 2, Price = 39000, IsAvailable = true },
                new Product { ProductId = 13, ProductName = "Trà Nhãn Sen Vàng", CategoryId = 2, Price = 42000, IsAvailable = true },
                new Product { ProductId = 14, ProductName = "Trà Lựu Đỏ Hạt Chia", CategoryId = 2, Price = 39000, IsAvailable = true },
                new Product { ProductId = 15, ProductName = "Trà Vải Hoa Hồng", CategoryId = 2, Price = 39000, IsAvailable = true },
                new Product { ProductId = 16, ProductName = "Trà Đào Cam Sả", CategoryId = 2, Price = 35000, IsAvailable = true },
                new Product { ProductId = 17, ProductName = "Lục Trà Kiwi Táo Xanh", CategoryId = 2, Price = 38000, IsAvailable = true },
                new Product { ProductId = 18, ProductName = "Trà Hibiscus Dâu Tây", CategoryId = 2, Price = 38000, IsAvailable = true },

                // Trà Sữa
                new Product { ProductId = 19, ProductName = "Trà Sữa Nướng Vân Nam", CategoryId = 3, Price = 45000, IsAvailable = true },
                new Product { ProductId = 20, ProductName = "Sữa Tươi Trân Châu Đường Đen", CategoryId = 3, Price = 40000, IsAvailable = true },
                new Product { ProductId = 21, ProductName = "Trà Sữa Oolong Lài Kem Cheese", CategoryId = 3, Price = 42000, IsAvailable = true },
                new Product { ProductId = 22, ProductName = "Trà Sữa Than Tre Nhật Bản", CategoryId = 3, Price = 45000, IsAvailable = true },
                new Product { ProductId = 23, ProductName = "Matcha Latte Kem Trứng", CategoryId = 3, Price = 45000, IsAvailable = true },
                new Product { ProductId = 24, ProductName = "Trà Sữa Thái Xanh", CategoryId = 3, Price = 30000, IsAvailable = true },
                new Product { ProductId = 25, ProductName = "Hồng Trà Macchiato", CategoryId = 3, Price = 35000, IsAvailable = true },
                new Product { ProductId = 26, ProductName = "Sữa Tươi Kem Trứng Nướng", CategoryId = 3, Price = 45000, IsAvailable = true },

                // Đá Xay
                new Product { ProductId = 27, ProductName = "Cookie Đá Xay Bạc Hà", CategoryId = 4, Price = 49000, IsAvailable = true },
                new Product { ProductId = 28, ProductName = "Sinh Tố Bơ Dừa Sáp", CategoryId = 4, Price = 55000, IsAvailable = true },
                new Product { ProductId = 29, ProductName = "Sữa Chua Hy Lạp Granola", CategoryId = 4, Price = 45000, IsAvailable = true },
                new Product { ProductId = 30, ProductName = "Chanh Tuyết Cốt Dừa", CategoryId = 4, Price = 35000, IsAvailable = true }
            );

            modelBuilder.Entity<Table>().HasData(
               new Table { TableId = 1, TableName = "Bàn 1", Capacity = 4, Status = "Available" },
               new Table { TableId = 2, TableName = "Bàn 2", Capacity = 4, Status = "Available" },
               new Table { TableId = 3, TableName = "Bàn 3", Capacity = 4, Status = "Available" },
               new Table { TableId = 4, TableName = "Bàn 4", Capacity = 6, Status = "Available" },
               new Table { TableId = 5, TableName = "Bàn 5", Capacity = 8, Status = "Available" },
               new Table { TableId = 6, TableName = "Bàn 6", Capacity = 2, Status = "Available" },
               new Table { TableId = 7, TableName = "Bàn 7", Capacity = 2, Status = "Available" },
               new Table { TableId = 8, TableName = "Bàn 8", Capacity = 10, Status = "Available" }
           );
        }
    }
}