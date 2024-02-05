using ProjectsTrackerSibers.Domain.Entity;
using ProjectsTrackerSibers.Domain.Response;

namespace ProjectsTrackerSiber.Service.Interfaces
{
	public interface IProjectService
	{
		Task<IBaseResponse<IEnumerable<Project>>> GetAllProjects();
	}
}
