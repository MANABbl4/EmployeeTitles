using EmployeeTitles.BLL.Models;

namespace EmployeeTitles.BLL.Services
{
    public interface ITitleService
    {
        Task<IEnumerable<TitleModel>> GetAllAsync();
        Task<TitleModel> GetByIdAsync(int id);
        Task<bool> AddAsync(TitleModel model);
        Task<bool> UpdateAsync(TitleModel model);
        Task<bool> DeleteByIdAsync(int id);
    }
}
