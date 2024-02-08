using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsTrackerSiber.Service.Interfaces;
using ProjectsTrackerSibers.Domain.Entity;

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
            if (projects.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View(projects.Data);
            }
            return RedirectToAction("Error", projects.Description);
        }

        [HttpGet]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var response = await _projectService.GetProject(id);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error", response.Description);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var response = await _projectService.DeleteProject(id);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", response.Description);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            return View();
        }
    }
}
