namespace EmployeeTitles.DAL.Entities
{
    public sealed class Title
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TitleGrade Grade { get; set; }

        public ICollection<EmployeeTitle> EmployeeTitles { get; set; }
    }
}
