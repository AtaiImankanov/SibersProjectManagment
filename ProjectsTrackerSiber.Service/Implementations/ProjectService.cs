﻿using ProjectsTrackerSiber.Service.Interfaces;
using ProjectsTrackerSibers.DAL.Interfaces;
using ProjectsTrackerSibers.Domain.Entity;
using ProjectsTrackerSibers.Domain.Response;
using ProjectsTrackerSibers.Domain.Enums;

namespace ProjectsTrackerSiber.Service.Implementations
{
	public class ProjectService : IProjectService
	{
		private readonly IProjectRepository _projectRepository;
		public ProjectService(IProjectRepository projectRepository) {
			_projectRepository = projectRepository;
		}
		public async Task<IBaseResponse<Project>> GetProject (Guid id)
		{
			var baseResponce = new BaseResponse<Project>();
			try
			{
				var project =await _projectRepository.Get(id);
				if(project == null)
				{
					baseResponce.Description = "Project by id not found";
					//baseResponce.StatusCode
					return baseResponce;
				}
				else
				{
					baseResponce.Data= project;
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
				var Projects = await _projectRepository.Select();
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
                var project = await _projectRepository.Get(id);
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

		public async Task<IBaseResponse<ProjectViewModel>> CreateProject (ProjectViewModel projectViewModel)
		{
			var baseResponce = new BaseResponse<ProjectViewModel>();
			try
			{
				var project = new Project
				{
					Name = projectViewModel.Name,
					PerformerCompany = projectViewModel.PerformerCompany,
					Priority = projectViewModel.Priority,
					CustomerCompany = projectViewModel.CustomerCompany,
					StartProjDate = projectViewModel.StartProjDate,
					EndtProjDate = projectViewModel.EndtProjDate,
					ProjectManagerId = projectViewModel.ProjectManagerId,
					ProjectManager = projectViewModel.ProjectManager,
				};
				await _projectRepository.Create(project);

				return baseResponce;
			}
			catch(Exception ex)
			{
                baseResponce.Description = ex.Message;
                baseResponce.StatusCode = StatusCode.InternalServerError;
                return baseResponce;
            }
		}
	}
}