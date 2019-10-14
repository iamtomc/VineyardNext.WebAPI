using System;
using WebAPIApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIApplication.Models
{
    public partial class VineyardNextContext : DbContext
    {
        public VineyardNextContext()
        {
        }

        public VineyardNextContext(DbContextOptions<VineyardNextContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Auth0> Auth0 { get; set; }
        public virtual DbSet<ContactMethods> ContactMethods { get; set; }
        public virtual DbSet<FamilyMembers> FamilyMembers { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<GroupAddresses> GroupAddresses { get; set; }
        public virtual DbSet<GroupMembers> GroupMembers { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<MemberAddresses> MemberAddresses { get; set; }
        public virtual DbSet<MemberContacts> MemberContacts { get; set; }
        public virtual DbSet<Members> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=VineyardNext;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<Auth0>(entity =>
            {
                entity.Property(e => e.Auth0FamilyName)
                    .HasColumnName("Auth0.familyName")
                    .HasMaxLength(100);

                entity.Property(e => e.Auth0GivenName)
                    .HasColumnName("Auth0.givenName")
                    .HasMaxLength(100);

                entity.Property(e => e.Auth0Name)
                    .HasColumnName("Auth0.name")
                    .HasMaxLength(200);

                entity.Property(e => e.Auth0Nickname)
                    .HasColumnName("Auth0.nickname")
                    .HasMaxLength(150);

                entity.Property(e => e.Auth0Sub)
                    .HasColumnName("Auth0.sub")
                    .HasMaxLength(200);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");
            });

            modelBuilder.Entity<ContactMethods>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<FamilyMembers>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<GroupAddresses>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<GroupMembers>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<MemberAddresses>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<MemberContacts>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Locale).HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(150);

                entity.Property(e => e.Picture).HasMaxLength(250);

                entity.Property(e => e.ProviderId).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });
        }
    }
}
