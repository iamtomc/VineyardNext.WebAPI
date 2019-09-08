using System;
using System.Configuration;
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

                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["VineyardNext"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.HasOne(d => d.GroupAddresses)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.GroupAddressesId);

                entity.HasOne(d => d.MemberAddresses)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.MemberAddressesId);
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

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Auth0)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Auth0_MemberAddresses");
            });

            modelBuilder.Entity<ContactMethods>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.HasOne(d => d.MemberContacts)
                    .WithMany(p => p.ContactMethods)
                    .HasForeignKey(d => d.MemberContactsId);
            });

            modelBuilder.Entity<FamilyMembers>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.FamilyMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FamilyMembers_Members");
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

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMembers_Members");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.HasOne(d => d.GroupAddresses)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupAddressesId);

                entity.HasOne(d => d.GroupMembers)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupMembersId);
            });

            modelBuilder.Entity<MemberAddresses>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberAddresses)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberAddresses_Members");
            });

            modelBuilder.Entity<MemberContacts>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberContacts)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberContacts_Members");
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
