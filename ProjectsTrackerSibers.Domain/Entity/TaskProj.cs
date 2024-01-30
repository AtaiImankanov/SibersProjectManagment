using ProjectsTrackerSibers.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTrackerSibers.Domain.Entity
{
    [Table("Tasks")]
    public class TaskProj
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public StatusTask Status { get; set; } //Enum
        public int Priority { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
