namespace EmployeeTitles.BLL.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public IEnumerable<TitleModel> Titles { get; set; }
    }
}
