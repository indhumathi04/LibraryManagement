using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryManagementSystem.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminDetail> AdminDetails { get; set; } = null!;
        public virtual DbSet<BooksAvailable> BooksAvailables { get; set; } = null!;
        public virtual DbSet<BooksTransaction> BooksTransactions { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Library;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminDetail>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__adminDet__AD0500A6822C5836");

                entity.ToTable("adminDetail");

                entity.Property(e => e.AdminId).HasColumnName("adminId");

                entity.Property(e => e.AdminEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adminEmail");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("adminName");

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("adminPassword");
            });

            modelBuilder.Entity<BooksAvailable>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__booksAva__8BE5A10D8E65DC14");

                entity.ToTable("booksAvailable");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.Author)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("author");

                entity.Property(e => e.BookDescription)
                    .IsUnicode(false)
                    .HasColumnName("bookDescription");

                entity.Property(e => e.DateAdded)
                    .HasColumnType("date")
                    .HasColumnName("dateAdded");

                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genre");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<BooksTransaction>(entity =>
            {
                entity.HasKey(e => e.TransId)
                    .HasName("PK__booksTra__DB107FA702C0DC94");

                entity.ToTable("booksTransaction");

                entity.Property(e => e.TransId).HasColumnName("transId");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("dueDate");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("date")
                    .HasColumnName("issueDate");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BooksTransactions)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__booksTran__bookI__35BCFE0A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BooksTransactions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__booksTran__userI__34C8D9D1");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__userDeta__CB9A1CFF55442344");

                entity.ToTable("userDetail");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
