using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ST4MPCRM.Models
{
    public partial class ST4MPContext : DbContext
    {
        public ST4MPContext()
        {
        }

        public ST4MPContext(DbContextOptions<ST4MPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
                //optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                   // .HasAnnotation("CustomerID",null)
                    .ValueGeneratedNever();

                entity.Property(e => e.EmailAddress).HasMaxLength(256);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Shops>(entity =>
            {
                entity.HasKey(e => e.ShopId);

                entity.Property(e => e.ShopId)
                    //.HasAnnotation("ShopID", null)
                    .ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(60);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    //.HasAnnotation("WebsiteURL",null)
                    .HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
