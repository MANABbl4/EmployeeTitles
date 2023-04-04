using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTitles.DAL.Entities.Configurations
{
    public class EmployeeTitleConfiguration : IEntityTypeConfiguration<EmployeeTitle>
    {
        public void Configure(EntityTypeBuilder<EmployeeTitle> builder)
        {
            builder.HasKey(x => new { x.EmployeeId, x.TitleId });

            builder.HasOne(x => x.Title).WithMany(x => x.EmployeeTitles).HasForeignKey(x => x.TitleId);
            builder.HasOne(x => x.Employee).WithMany(x => x.EmployeeTitles).HasForeignKey(x => x.EmployeeId);
        }
    }
}
