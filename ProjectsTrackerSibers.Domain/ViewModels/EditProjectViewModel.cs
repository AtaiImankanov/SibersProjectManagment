using ProjectsTrackerSibers.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTrackerSibers.Domain.ViewModels
{
	public class EditProjectViewModel
	{
		public Guid Id { get; set; }

		public Guid? ProjectManagerId { get; set; }

		public string Name { get; set; }
		public string PerformerCompany { get; set; }
		public string CustomerCompany { get; set; }
		public DateTime StartProjDate { get; set; }
		public DateTime EndtProjDate { get; set; }
		public int Priority { get; set; }
	}
}
