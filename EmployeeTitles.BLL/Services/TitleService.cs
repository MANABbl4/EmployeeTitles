using EmployeeTitles.BLL.Models;
using EmployeeTitles.DAL.Repositories;

namespace EmployeeTitles.BLL.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;

        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public Task<bool> AddAsync(TitleModel model)
        {
            return _titleRepository.AddAsync(new DAL.Entities.Title()
            {
                Name = model.Name,
                Grade = model.Grade
            });
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var employeesCount = await _titleRepository.GetTitleEmployeesCountAsync(id);

            if (employeesCount < 1)
            {
                return await _titleRepository.DeleteByIdAsync(id);
            }

            return false;
        }

        public async Task<IEnumerable<TitleModel>> GetAllAsync()
        {
            return (await _titleRepository.GetAllAsync())
                .Select(x => new TitleModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Grade = x.Grade
                })
                .ToList();
        }

        public async Task<TitleModel> GetByIdAsync(int id)
        {
            var entity = await _titleRepository.GetByIdAsync(id);

            return new TitleModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Grade = entity.Grade
            };
        }

        public Task<bool> UpdateAsync(TitleModel model)
        {
            return _titleRepository.UpdateAsync(new DAL.Entities.Title()
            {
                Id = model.Id,
                Name = model.Name,
                Grade = model.Grade
            });
        }
    }
}
