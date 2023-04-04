using EmployeeTitles.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTitles.DAL.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TitleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> AddAsync(Title entity)
        {
            _applicationDbContext.Titles.Add(entity);
            var saveResult = await _applicationDbContext.SaveChangesAsync();

            return saveResult > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            _applicationDbContext.Titles.Remove(new Title { Id = id });
            var deleteResult = await _applicationDbContext.SaveChangesAsync();

            return deleteResult > 0;
        }

        public async Task<IEnumerable<Title>> GetAllAsync()
        {
            return await _applicationDbContext.Titles.ToListAsync();
        }

        public Task<Title> GetByIdAsync(int id)
        {
            return _applicationDbContext.Titles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Title entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                return false;
            }

            dbEntity.Grade = entity.Grade;
            dbEntity.Name = entity.Name;

            await _applicationDbContext.SaveChangesAsync();

            return true;
        }

        public Task<int> GetTitleEmployeesCountAsync(int id)
        {
            return _applicationDbContext.EmployeeTitles.Where(x => x.TitleId == id).CountAsync();
        }
    }
}
