using EmployeeTitles.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTitles.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> AddAsync(Employee entity)
        {
            _applicationDbContext.Employees.Add(entity);
            var saveResult = await _applicationDbContext.SaveChangesAsync();

            return saveResult > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            _applicationDbContext.Employees.Remove(new Employee { Id = id });
            var deleteResult = await _applicationDbContext.SaveChangesAsync();

            return deleteResult > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _applicationDbContext.Employees
                .Include(x => x.EmployeeTitles)
                .ThenInclude(x => x.Title)
                .ToListAsync();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            return _applicationDbContext.Employees
                .Include(x => x.EmployeeTitles)
                .ThenInclude(x => x.Title)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Employee entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                return false;
            }

            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.BirthDay = entity.BirthDay;

            await _applicationDbContext.SaveChangesAsync();

            return true;
        }
    }
}
