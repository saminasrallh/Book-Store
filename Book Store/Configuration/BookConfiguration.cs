using Book_Store.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
       

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Created).HasDefaultValue(DateTime.Now);
            builder.Property(x=>x.CreatedBy).HasMaxLength(10);
            builder.Property(x=>x.UpdateBy).HasMaxLength(10);
          

            builder.HasMany(x=>x.BookCategory).WithMany(x => x.Books).UsingEntity("Categores_Book");
            builder.HasOne(x => x.Auther).WithMany(x => x.books).HasForeignKey(x => x.AutherId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.UserBook).WithOne(x => x.Book).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
