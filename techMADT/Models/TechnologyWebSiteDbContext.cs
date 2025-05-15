using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace techMADT.Models;

public partial class TechnologyWebSiteDbContext : DbContext
{
    public TechnologyWebSiteDbContext()
    {
    }

    public TechnologyWebSiteDbContext(DbContextOptions<TechnologyWebSiteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<LoginType> LoginTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8DJL0C5\\SQLEXPRESS;Database=technologyWebSiteDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.AddressId)
                .ValueGeneratedNever()
                .HasColumnName("addressID");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .HasColumnName("city");
            entity.Property(e => e.Discrict)
                .HasMaxLength(20)
                .HasColumnName("discrict");
            entity.Property(e => e.FullAddress)
                .HasMaxLength(120)
                .HasColumnName("fullAddress");
            entity.Property(e => e.Neighbourhood)
                .HasMaxLength(20)
                .HasColumnName("neighbourhood");
            entity.Property(e => e.Street)
                .HasMaxLength(20)
                .HasColumnName("street");
            entity.Property(e => e.UsId).HasColumnName("usID");

            entity.HasOne(d => d.Us).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Users");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.BrandId)
                .ValueGeneratedNever()
                .HasColumnName("brandID");
            entity.Property(e => e.BrandName)
                .HasMaxLength(20)
                .HasColumnName("brandName");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.Property(e => e.CartId)
                .ValueGeneratedNever()
                .HasColumnName("cartID");
            entity.Property(e => e.UsId).HasColumnName("usID");

            entity.HasOne(d => d.Us).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Users");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.ToTable("CartItem");

            entity.Property(e => e.CartItemId)
                .ValueGeneratedNever()
                .HasColumnName("cartItemID");
            entity.Property(e => e.CartId).HasColumnName("cartID");
            entity.Property(e => e.PrId).HasColumnName("prID");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartItem_Cart");

            entity.HasOne(d => d.Pr).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.PrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartItem_Products");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId);

            entity.Property(e => e.CatId)
                .ValueGeneratedNever()
                .HasColumnName("catID");
            entity.Property(e => e.CatName)
                .HasMaxLength(50)
                .HasColumnName("catName");
        });

        modelBuilder.Entity<LoginType>(entity =>
        {
            entity.HasKey(e => e.UsType);

            entity.ToTable("loginType");

            entity.Property(e => e.UsType).HasColumnName("usType");
            entity.Property(e => e.TypeName)
                .HasMaxLength(15)
                .HasColumnName("typeName");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrId);

            entity.Property(e => e.OrId)
                .ValueGeneratedNever()
                .HasColumnName("orID");
            entity.Property(e => e.OrDate)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("orDate");
            entity.Property(e => e.OrPieces).HasColumnName("orPieces");
            entity.Property(e => e.OrStatus)
                .HasMaxLength(25)
                .HasColumnName("orStatus");
            entity.Property(e => e.OrTotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("orTotalPrice");
            entity.Property(e => e.UsId).HasColumnName("usID");

            entity.HasOne(d => d.Us).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.DetailsId);

            entity.Property(e => e.DetailsId)
                .ValueGeneratedNever()
                .HasColumnName("detailsID");
            entity.Property(e => e.OrId).HasColumnName("orID");
            entity.Property(e => e.Pieces).HasColumnName("pieces");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Or).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PayId);

            entity.Property(e => e.PayId)
                .ValueGeneratedNever()
                .HasColumnName("payID");
            entity.Property(e => e.CreatedDate)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("createdDate");
            entity.Property(e => e.OrId).HasColumnName("orID");
            entity.Property(e => e.PayMethod)
                .HasMaxLength(25)
                .HasColumnName("payMethod");
            entity.Property(e => e.PayStatus)
                .HasMaxLength(20)
                .HasColumnName("payStatus");

            entity.HasOne(d => d.Or).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_Orders");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PrId);

            entity.Property(e => e.PrId)
                .ValueGeneratedNever()
                .HasColumnName("prID");
            entity.Property(e => e.BrandId).HasColumnName("brandID");
            entity.Property(e => e.CatId).HasColumnName("catID");
            entity.Property(e => e.PrName)
                .HasMaxLength(20)
                .HasColumnName("prName");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Brands");

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsId);

            entity.Property(e => e.UsId).HasColumnName("usID");
            entity.Property(e => e.UsCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("usCreatedDate");
            entity.Property(e => e.UsEmail)
                .HasMaxLength(50)
                .HasColumnName("usEmail");
            entity.Property(e => e.UsName)
                .HasMaxLength(25)
                .HasColumnName("usName");
            entity.Property(e => e.UsNickname)
                .HasMaxLength(50)
                .HasColumnName("usNickname");
            entity.Property(e => e.UsPassword)
                .HasMaxLength(15)
                .HasColumnName("usPassword");
            entity.Property(e => e.UsSurname)
                .HasMaxLength(25)
                .HasColumnName("usSurname");
            entity.Property(e => e.UsType).HasColumnName("usType");

            entity.HasOne(d => d.UsTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UsType)
                .HasConstraintName("FK_Users_loginType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
