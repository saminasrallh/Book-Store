using Book_Store.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Configuration
{
    public class AutherConfigration : IEntityTypeConfiguration<Auther>
    {
        public void Configure(EntityTypeBuilder<Auther> builder)
        {
            builder.ToTable("Authers");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.IsDeleted).HasDefaultValue(false);

         
        }
    }
}
