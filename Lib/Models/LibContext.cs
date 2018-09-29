using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class LibContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Library> Libraries { get; set; }

        public LibContext(DbContextOptions<LibContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>()
                .HasKey(t => new { t.BookId, t.AuthorId });

            modelBuilder.Entity<Library>()
                .HasOne(sc => sc.Author)
                .WithMany(s => s.Libraries)
                .HasForeignKey(sc => sc.AuthorId);

            modelBuilder.Entity<Library>()
                .HasOne(sc => sc.Book)
                .WithMany(c => c.Libraries)
                .HasForeignKey(sc => sc.BookId);
        }
    }
}
