using EmployeeTitles.DAL.Entities;

namespace EmployeeTitles.DAL.Repositories
{
    public interface ITitleRepository
    {
        Task<IEnumerable<Title>> GetAllAsync();
        Task<Title> GetByIdAsync(int id);
        Task<bool> AddAsync(Title entity);
        Task<bool> UpdateAsync(Title entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<int> GetTitleEmployeesCountAsync(int id);
    }
}
