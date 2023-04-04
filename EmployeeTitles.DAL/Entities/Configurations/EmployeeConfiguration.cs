using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTitles.DAL.Entities.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(32).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(32).IsRequired();
            builder.Property(x => x.BirthDay).IsRequired();

            builder.HasMany(x => x.EmployeeTitles).WithOne(x => x.Employee).HasForeignKey(ep => ep.EmployeeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
