using EmployeeTitles.BLL.Models;

namespace EmployeeTitles.BLL.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetAllAsync();
        Task<EmployeeModel> GetByIdAsync(int id);
        Task<bool> AddAsync(EmployeeModel model);
        Task<bool> UpdateAsync(EmployeeModel model);
        Task<bool> DeleteByIdAsync(int id);
    }
}
