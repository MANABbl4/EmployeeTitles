using EmployeeTitles.BLL.Models;
using EmployeeTitles.DAL.Entities;
using EmployeeTitles.DAL.Repositories;

namespace EmployeeTitles.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeTitleRepository _employeeTitleRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,
            IEmployeeTitleRepository employeeTitleRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeTitleRepository = employeeTitleRepository;
        }

        public async Task<bool> AddAsync(EmployeeModel model)
        {
            var entity = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDay = model.BirthDay.Date
            };

            var addResult = await _employeeRepository.AddAsync(entity);

            var eployeeTitles = model.Titles
                .Select(x => new EmployeeTitle()
                {
                    EmployeeId = entity.Id,
                    TitleId = x.Id
                })
                .ToList();

            await _employeeTitleRepository.AddEmployeeTitlesAsync(eployeeTitles);

            return addResult;
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            return _employeeRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllAsync()
        {
            return (await _employeeRepository.GetAllAsync())
                .Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDay = x.BirthDay.Date,
                    Titles = x.EmployeeTitles.Select(y => new TitleModel()
                    {
                        Id = y.TitleId,
                        Name = y.Title.Name,
                        Grade = y.Title.Grade
                    })
                    .ToList()
                })
                .ToList();
        }

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            var entity = await _employeeRepository.GetByIdAsync(id);

            return new EmployeeModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDay = entity.BirthDay.Date,
                Titles = entity.EmployeeTitles.Select(x => new TitleModel()
                {
                    Id = x.TitleId,
                    Name = x.Title.Name,
                    Grade = x.Title.Grade
                })
                .ToList()
            };
        }

        public async Task<bool> UpdateAsync(EmployeeModel model)
        {
            var entity = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDay = model.BirthDay.Date
            };

            var updateResult = await _employeeRepository.UpdateAsync(entity);

            var currentEmployeeTitles = await _employeeTitleRepository.GetEmployeeTitlesAsync(model.Id);

            var addEployeeTitles = model.Titles
                .Where(x => !currentEmployeeTitles.Any(y => y.TitleId == x.Id))
                .Select(x => new EmployeeTitle()
                {
                    EmployeeId = model.Id,
                    TitleId = x.Id
                })
                .ToList();

            var deleteEployeeTitles = currentEmployeeTitles
                .Where(x => !model.Titles.Any(y => y.Id == x.TitleId))
                .ToList();

            if (addEployeeTitles.Any())
            {
                await _employeeTitleRepository.AddEmployeeTitlesAsync(addEployeeTitles);
            }

            if (deleteEployeeTitles.Any())
            {
                await _employeeTitleRepository.DeleteEmployeeTitlesAsync(deleteEployeeTitles);
            }

            return updateResult;
        }
    }
}
