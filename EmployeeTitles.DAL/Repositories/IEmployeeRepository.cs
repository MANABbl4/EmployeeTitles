using EmployeeTitles.DAL.Entities;

namespace EmployeeTitles.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<bool> AddAsync(Employee entity);
        Task<bool> UpdateAsync(Employee entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
