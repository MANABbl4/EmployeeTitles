namespace EmployeeTitles.DAL.Entities
{
    public sealed class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public ICollection<EmployeeTitle> EmployeeTitles { get; set; }
    }
}
