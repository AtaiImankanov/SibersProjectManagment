using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsTrackerSiber.Service.Interfaces;
using ProjectsTrackerSibers.DAL.Repositories;
using ProjectsTrackerSibers.Domain.Entity;
using ProjectsTrackerSibers.Domain.ViewModels;

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
        public async Task<IActionResult> Create()
        {
            //var managers = await _managerService.GetManagers();

            //// Проверяем, что список менеджеров не является null перед добавлением в ViewBag
            //if (managers != null)
            //{
            //    ViewBag.Managers = managers;
            //}
            //else
            //{
            //    ViewBag.Managers = new List<Manager>(); // Если список менеджеров null, создаем пустой список
            //}
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(СreateProjectViewModel newItem)
        {
            if (ModelState.IsValid)
            {
                var response = await _projectService.CreateProject(newItem);
                if (response.StatusCode == Domain.Enums.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Error", response.Description);
            }
            return View(newItem);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
			var project = await _projectService.GetProject(id);

			if (project.Data == null)
			{
				return NotFound();
			}
			//var managers = await _managerService.GetManagers();

			//// Проверяем, что список менеджеров не является null перед добавлением в ViewBag
			//if (managers != null)
			//{
			//    ViewBag.Managers = managers;
			//}
			//else
			//{
			//    ViewBag.Managers = new List<Manager>(); // Если список менеджеров null, создаем пустой список
			//}



			if (project.StatusCode == Domain.Enums.StatusCode.OK)
			{
				var viewModel = new EditProjectViewModel
				{
					Id = project.Data.Id,
					ProjectManagerId = project.Data.ProjectManagerId,
					//ProjectManagers =managers,
					Name = project.Data.Name,
					PerformerCompany = project.Data.PerformerCompany,
					CustomerCompany = project.Data.CustomerCompany,
					StartProjDate = project.Data.StartProjDate,
					EndtProjDate = project.Data.EndtProjDate,
					Priority = project.Data.Priority
				};
				return View(viewModel);
			}
			return RedirectToAction("Error", project.Description);
		}
		[HttpPost]
		public async Task<ActionResult> Edit(EditProjectViewModel proj)
		{

			if (ModelState.IsValid)
			{
				var response = await _projectService.EditProject(proj);
				if (response.StatusCode == Domain.Enums.StatusCode.OK)
				{
					return RedirectToAction("Index");
				}
				return RedirectToAction("Error", response.Description);
			}

			return View(proj);

		}
	}
}
