﻿using ProjectsTrackerSiber.Service.Interfaces;
using ProjectsTrackerSibers.DAL.Interfaces;
using ProjectsTrackerSibers.Domain.Entity;
using ProjectsTrackerSibers.Domain.Response;
using ProjectsTrackerSibers.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using ProjectsTrackerSibers.Domain.ViewModels;

namespace ProjectsTrackerSiber.Service.Implementations
{
	public class ProjectService : IProjectService
	{
		private readonly IBaseRepository<Project> _projectRepository;
		public ProjectService(IBaseRepository<Project> projectRepository) {
			_projectRepository = projectRepository;
		}
		public async Task<IBaseResponse<Project>> GetProject (Guid id)
		{
			var baseResponce = new BaseResponse<Project>();
			try
			{
				var project =await _projectRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
				if(project == null)
				{
					baseResponce.Description = "Project by id not found";
					baseResponce.StatusCode = StatusCode.NullExeption;
					return baseResponce;
				}
				else
				{
					baseResponce.Data= project;
					baseResponce.StatusCode = StatusCode.OK;
					return baseResponce;
				}

			}catch (Exception ex)
			{
				baseResponce.Description= ex.Message;
				baseResponce.StatusCode = StatusCode.InternalServerError;
				return baseResponce;
			}
		}
		public async Task<IBaseResponse<IEnumerable<Project>>> GetAllProjects()
		{
			var baseResponce= new BaseResponse<IEnumerable<Project>>();
			try
			{
				var Projects = await _projectRepository.GetAll().ToListAsync();
				if (Projects.Count() == 0)
				{
					baseResponce.Description = "There is no elements in Projects table";
					baseResponce.StatusCode = StatusCode.OK; 
					return baseResponce;
				}
				baseResponce.Data = Projects;
				baseResponce.StatusCode = StatusCode.OK;
				return baseResponce;
			}
			catch(Exception ex)
			{
				return new BaseResponse<IEnumerable<Project>>()
				{
					Description = $"[GetAllProjects] : {ex.Message}"
				};
			}
		}

		public async Task<IBaseResponse<bool>> DeleteProject(Guid id)
		{
			var baseResponce = new BaseResponse<bool>();
			try
			{
                var project =  await _projectRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (project == null)
                {
                    baseResponce.Description = "Project by id not found";
                    //baseResponce.StatusCode
                    return baseResponce;
                }
                else
                {	
                    baseResponce.Data =  await _projectRepository.Delete(project); ;
                    return baseResponce;
                }
            }
            catch(Exception ex)
			{
                baseResponce.Description = ex.Message;
                baseResponce.StatusCode = StatusCode.InternalServerError;
				return baseResponce;
			}
		}

		public async Task<IBaseResponse<СreateProjectViewModel>> CreateProject(СreateProjectViewModel projectViewModel)
		{
			var baseResponce = new BaseResponse<СreateProjectViewModel>();
			try
			{
				var project = new Project
                {
					Name = projectViewModel.Name,
					PerformerCompany = projectViewModel.PerformerCompany,
					Priority = projectViewModel.Priority,
					CustomerCompany = projectViewModel.CustomerCompany,
					StartProjDate = projectViewModel.StartProjDate,
					ProjectManagerId = projectViewModel.ProjectManagerId,
				};
				await _projectRepository.Create(project);
				baseResponce.StatusCode = StatusCode.OK;
				return baseResponce; 
			}
			catch(Exception ex)
			{
                baseResponce.Description = ex.Message;
                baseResponce.StatusCode = StatusCode.InternalServerError;
                return baseResponce;
            }
		}

        public async Task<IBaseResponse<bool>> EditProject(EditProjectViewModel viewModel)
        {
			var baseResponce = new BaseResponse<bool>();
			try
			{
				var project = await _projectRepository.GetAll().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

				if (project == null)
				{
					baseResponce.StatusCode = StatusCode.NullExeption;
					baseResponce.Description = "there is no project like that";
					return baseResponce;
				}
				project.Name = viewModel.Name;
				project.PerformerCompany = viewModel.PerformerCompany;
				project.CustomerCompany = viewModel.CustomerCompany;
				project.StartProjDate = viewModel.StartProjDate;
				project.EndtProjDate = viewModel.EndtProjDate;
				project.Priority = viewModel.Priority;
				project.ProjectManagerId = viewModel.ProjectManagerId;

				// Сохраняем изменения в базе данных
				baseResponce.Data=await _projectRepository.Edit(project);
				baseResponce.StatusCode = StatusCode.OK;
				return baseResponce;
			}
			catch (Exception ex)
			{
				baseResponce.Description = ex.Message;
				baseResponce.StatusCode = StatusCode.InternalServerError;
				return baseResponce;
			}
		}
    }
}
