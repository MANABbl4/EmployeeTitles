using EmployeeTitles.DAL.Entities;

namespace EmployeeTitles.BLL.Models
{
    public class TitleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TitleGrade Grade { get; set; }
    }
}
