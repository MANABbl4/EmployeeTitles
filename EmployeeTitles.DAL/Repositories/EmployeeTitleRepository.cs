using EmployeeTitles.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTitles.DAL.Repositories
{
    public class EmployeeTitleRepository : IEmployeeTitleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeTitleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> AddEmployeeTitleAsync(EmployeeTitle entity)
        {
            _applicationDbContext.EmployeeTitles.Add(entity);

            var addResult = await _applicationDbContext.SaveChangesAsync();

            return addResult > 0;
        }

        public async Task<bool> AddEmployeeTitlesAsync(IEnumerable<EmployeeTitle> entities)
        {
            _applicationDbContext.EmployeeTitles.AddRange(entities);

            var addResult = await _applicationDbContext.SaveChangesAsync();

            return addResult > 0;
        }

        public async Task<bool> DeleteEmployeeTitleAsync(EmployeeTitle entity)
        {
            _applicationDbContext.EmployeeTitles.Remove(entity);

            var deleteResult = await _applicationDbContext.SaveChangesAsync();

            return deleteResult > 0;
        }

        public async Task<bool> DeleteEmployeeTitlesAsync(IEnumerable<EmployeeTitle> entities)
        {
            _applicationDbContext.EmployeeTitles.RemoveRange(entities);

            var deleteResult = await _applicationDbContext.SaveChangesAsync();

            return deleteResult > 0;
        }

        public async Task<IEnumerable<EmployeeTitle>> GetEmployeeTitlesAsync(int employeeId)
        {
            return await _applicationDbContext.EmployeeTitles
                .Where(x => x.EmployeeId == employeeId)
                .ToListAsync();
        }
    }
}
