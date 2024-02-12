using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTrackerSibers.Domain.ViewModels
{
    public class СreateProjectViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Performer Company is required")]
        public string PerformerCompany { get; set; }

        [Required(ErrorMessage = "Customer Company is required")]
        public string CustomerCompany { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime StartProjDate { get; set; }


        [Required(ErrorMessage = "Priority is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Priority must be greater than 0")]
        public int Priority { get; set; }

        public Guid? ProjectManagerId { get; set; }

    }
}
