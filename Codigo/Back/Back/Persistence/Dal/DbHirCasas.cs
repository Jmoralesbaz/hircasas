using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HirCasa.Back.Persistence.Dao;

#nullable disable

namespace HirCasa.Back.Persistence.Dal
{
    public partial class DbHirCasa : DbContext
    {
        public DbHirCasa()
        {
        }

        public DbHirCasa(DbContextOptions<DbHirCasa> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
        public virtual DbSet<SalesHeader> SalesHeaders { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Item__46E78A0C");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Folio)
                    .HasName("PK__Invoice__BAB84EF6C5480AF1");

                entity.Property(e => e.Folio).IsUnicode(false);

                entity.Property(e => e.CodigoPostal)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RazonSocial).IsUnicode(false);

                entity.Property(e => e.RegimenFiscal).IsUnicode(false);

                entity.Property(e => e.Rfc).IsUnicode(false);

                entity.Property(e => e.UsoCfdi).IsUnicode(false);

                entity.HasOne(d => d.SaleNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Sale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoice__Sale__5FB337D6");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Asset).HasDefaultValueSql("((1))");

                entity.Property(e => e.Item1).IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Asset).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<SalesDetail>(entity =>
            {
                entity.HasKey(e => new { e.Sale, e.Item })
                    .HasName("PK__Sales_De__4899057821AEB906");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales_Deta__Item__70DDC3D8");

                entity.HasOne(d => d.SaleNavigation)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.Sale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales_Deta__Sale__6FE99F9F");
            });

            modelBuilder.Entity<SalesHeader>(entity =>
            {
                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.SalesHeaders)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales_Hea__Perso__4AB81AF0");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.Token).IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sessions__IdUser__5812160E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Asset).HasDefaultValueSql("((1))");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Rol).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__Person__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
