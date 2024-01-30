using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTrackerSibers.Domain.Entity
{
    [Table("Employees")]
    public class Employee
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set;}
        public ICollection<TaskProj>? TaskProjs { get; set; } = new List<TaskProj>();
    }
}
