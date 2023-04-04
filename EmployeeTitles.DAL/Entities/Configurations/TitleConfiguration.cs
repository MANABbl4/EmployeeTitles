using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTitles.DAL.Entities.Configurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(32).IsRequired();
            builder.Property(x => x.Grade).IsRequired();

            builder.HasMany(x => x.EmployeeTitles).WithOne(x => x.Title).HasForeignKey(ep => ep.TitleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
