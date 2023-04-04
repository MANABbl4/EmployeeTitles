using EmployeeTitles.DAL.Entities;
using EmployeeTitles.DAL.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeTitles.DAL
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<EmployeeTitle> EmployeeTitles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new EmployeeConfiguration())
                .ApplyConfiguration(new TitleConfiguration())
                .ApplyConfiguration(new EmployeeTitleConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySQL(_configuration.GetConnectionString("main"));
    }
}