using ProjectsTrackerSibers.Domain.Entity;
using ProjectsTrackerSibers.Domain.Response;
using ProjectsTrackerSibers.Domain.ViewModels;

namespace ProjectsTrackerSiber.Service.Interfaces
{
	public interface IProjectService
	{
		 Task<IBaseResponse<IEnumerable<Project>>> GetAllProjects();
		Task<IBaseResponse<СreateProjectViewModel>> CreateProject(СreateProjectViewModel projectViewModel);
		Task<IBaseResponse<bool>> DeleteProject(Guid id);
		Task<IBaseResponse<Project>> GetProject(Guid id);
		Task<IBaseResponse<bool>> EditProject(EditProjectViewModel projectViewModel);
	}
}
