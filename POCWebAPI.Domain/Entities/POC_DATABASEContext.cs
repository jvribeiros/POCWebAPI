using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace POCWebAPI.Domain.Entities
{
    public partial class POC_DATABASEContext : DbContext
    {
        public POC_DATABASEContext()
        {
        }

        public POC_DATABASEContext(DbContextOptions<POC_DATABASEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvailableAsset> AvailableAssets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersAsset> UsersAssets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;User ID=sqlserveruser;Password=abc123;Database=POC_DATABASE;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableAsset>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Symbol).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<UsersAsset>(entity =>
            {
                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.UsersAssets)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AvailableAssets_UsersAssets");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersAssets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UsersAssets");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
