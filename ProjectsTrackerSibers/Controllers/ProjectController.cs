using Microsoft.AspNetCore.Mvc;
using ProjectsTrackerSiber.Service.Interfaces;

namespace ProjectsTrackerSibers.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
		}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetAllProjects();
            if(projects.StatusCode== Domain.Enums.StatusCode.OK)
            {
                return View(projects.Data);
            }
            return RedirectToAction("Error",projects.Description) ;
        }   
    }
}
