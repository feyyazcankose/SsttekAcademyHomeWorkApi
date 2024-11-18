using SsttekAcademyHomeWorkApi.Models.Entities;

namespace SsttekAcademyHomeWorkApi.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Identity tablolarını da eklemek için base çağrısı yapılır.
            base.OnModelCreating(modelBuilder);

            // Book varlık yapılandırmaları
            modelBuilder.Entity<Book>().HasKey(b => b.Id);

            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Book>()
                .Property(b => b.PublicationYear)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(13);

            modelBuilder.Entity<Book>()
                .Property(b => b.Genre)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Book>()
                .Property(b => b.Publisher)
                .HasMaxLength(250);

            modelBuilder.Entity<Book>()
                .Property(b => b.PageCount)
                .IsRequired();
        }
    }
