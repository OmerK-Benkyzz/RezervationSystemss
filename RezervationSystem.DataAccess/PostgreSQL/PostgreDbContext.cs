using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RezervationSystem.Core.GlobalVariablesFolder;
using RezervationSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RezervationSystem.DataAccess.PostgreSQL
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext()
        {

        }
        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(MyGlobalVariablesStatic.connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("Customers");
                entity.Property(e => e.Ad).HasColumnName("MusteriAd").IsRequired();
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId").HasDefaultValue(0).IsRequired();
                entity.Property(e => e.Cocuksayisi).HasColumnName("Cocuksayisi").IsRequired();
                entity.Property(e => e.HasChildren).HasColumnName("HasChildren").IsRequired();
                entity.Property(e => e.KisiSayisi).HasColumnName("KisiSayisi").IsRequired();
                entity.Property(e => e.Soyad).HasColumnName("MusteriSoyad").IsRequired();
                entity.HasOne(d => d.rooms).WithOne(p => p.customers).HasForeignKey<Rooms>(p => p.MusteriId).HasConstraintName("Customer_Room_fk");
            });
            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.ToTable("Rooms");
                entity.Property(e => e.RezervasyonBaslangic).HasColumnName("RezervasyonBaslangic").IsRequired();
                entity.Property(e => e.RezervasyonBitis).HasColumnName("RezervasyonBitis").IsRequired();
                entity.Property(e => e.RoomId).HasColumnName("MusteriId").HasDefaultValue(0).IsRequired();
                entity.Property(e => e.dolumu).HasColumnName("isfull").IsRequired();
            });
        }

        //private void entity(EntityTypeBuilder<Customers> obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
