using Book_Store.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Book_Store.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Auther> Authers { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Users).Assembly);
            modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Auther>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Users>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(b => !b.IsDeleted);


        }

    }
}
