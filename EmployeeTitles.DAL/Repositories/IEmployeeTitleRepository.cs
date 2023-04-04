using EmployeeTitles.DAL.Entities;

namespace EmployeeTitles.DAL.Repositories
{
    public interface IEmployeeTitleRepository
    {
        Task<bool> AddEmployeeTitleAsync(EmployeeTitle entity);
        Task<bool> AddEmployeeTitlesAsync(IEnumerable<EmployeeTitle> entities);
        Task<bool> DeleteEmployeeTitleAsync(EmployeeTitle entity);
        Task<bool> DeleteEmployeeTitlesAsync(IEnumerable<EmployeeTitle> entities);
        Task<IEnumerable<EmployeeTitle>> GetEmployeeTitlesAsync(int employeeId);
    }
}
