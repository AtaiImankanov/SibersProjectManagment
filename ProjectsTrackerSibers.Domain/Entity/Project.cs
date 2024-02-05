using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTrackerSibers.Domain.Entity
{
    [Table("Projects")]
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PerformerCompany { get; set; }
        public string CustomerCompany { get; set; }
        public DateTime StartProjDate { get; set; }
        public DateTime EndtProjDate { get; set; }
        public int Priority { get; set; }

        public Guid? ProjectManagerId { get; set; }
        public Employee? ProjectManager { get; set; }

        public ICollection<TaskProj>? Tasks { get; set; } = new List<TaskProj>();

    }

}
