using Book_Store.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
           builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.FName).HasMaxLength(10);
            builder.Property(x => x.LName).HasMaxLength(10);

            builder.HasMany(x => x.Roles).WithMany(x => x.Users).UsingEntity("UserRoles");
            builder.HasMany(x=>x.UserBooks).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
