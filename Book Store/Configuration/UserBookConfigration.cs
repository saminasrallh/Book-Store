using Book_Store.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Configuration
{
    public class UserBookConfigration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> builder)
        {
            builder.ToTable("UserBook");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RentalTime).HasDefaultValue(DateTime.Now);
            builder.Property(x=>x.deadline).HasDefaultValue(DateTime.Now.AddMonths(1));
            builder.Property(x=>x.ReturnTime).HasDefaultValue(null);
        }
    }
}
