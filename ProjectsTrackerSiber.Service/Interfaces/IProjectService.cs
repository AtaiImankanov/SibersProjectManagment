using ProjectsTrackerSibers.Domain.Entity;
using ProjectsTrackerSibers.Domain.Response;

namespace ProjectsTrackerSiber.Service.Interfaces
{
	public interface IProjectService
	{
		 Task<IBaseResponse<IEnumerable<Project>>> GetAllProjects();
		Task<IBaseResponse<ProjectViewModel>> CreateProject(ProjectViewModel projectViewModel);
		Task<IBaseResponse<bool>> DeleteProject(Guid id);
		Task<IBaseResponse<Project>> GetProject(Guid id);
		Task<IBaseResponse<Project>> EditProject(Guid id);
	}
}
