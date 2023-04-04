namespace EmployeeTitles.DAL.Entities
{
    public sealed class EmployeeTitle
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TitleId { get; set; }
        public Title Title { get; set; }
    }
}
