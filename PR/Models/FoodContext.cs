using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PR.Models
{
    public partial class FoodContext : DbContext
    {
        public FoodContext()
        {
        }

        public FoodContext(DbContextOptions<FoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:MyDatabase"];
            optionsBuilder.UseSqlServer(strConn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__MenuItems__categ__4E88ABD4");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__MenuItems__users__4D94879B");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("datetime")
                    .HasColumnName("order_time");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total_price");

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK__Orders__table_id__59063A47");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Orders__users_id__5812160E");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MenuItemId).HasColumnName("menu_item_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.MenuItemId)
                    .HasConstraintName("FK__OrderItem__menu___5CD6CB2B");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__order__5BE2A6F2");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ReservationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("reservation_time");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK__Reservati__table__5535A963");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Reservati__users__5441852A");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.TableNumber).HasColumnName("table_number");

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Tables__users_id__5165187F");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
