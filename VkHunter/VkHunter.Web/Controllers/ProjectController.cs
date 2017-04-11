using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using VkHunter.Domain.Entities;
using VkHunter.DTO;
using VkHunter.Web.Constants;

namespace VkHunter.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/project")]
    public class ProjectController : BaseController
    {
        public ProjectController()
        {
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var projectEntities = DataManager.Projects.GetAll();
                var projectsDTO = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResponseDTO>>(projectEntities);
                return Ok(projectsDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(ProjectController)} | {nameof(GetAll)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpGet]
        [Route("getById")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var projectEntitie = DataManager.Projects.GetById(id);
                var projectDTO = Mapper.Map<Project, ProjectResponseDTO>(projectEntitie);
                return Ok(projectDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(ProjectController)} | {nameof(GetById)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(ProjectRequestDTO project)
        {
            if (!ModelState.IsValid || project.Id != 0)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var projectEntity = Mapper.Map<ProjectRequestDTO, Project>(project);
                var entity = DataManager.Projects.Create(projectEntity);
                DataManager.Save();

                var projectDTO = Mapper.Map<Project, ProjectResponseDTO>(entity);
                return Ok(projectDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(ProjectController)} | {nameof(Create)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(ProjectRequestDTO project)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var projectEntity = DataManager.Projects.GetById(project.Id);

                var entity = Mapper.Map(project, projectEntity);
                DataManager.Projects.Update(entity);
                DataManager.Save();

                var projectDTO = Mapper.Map<Project, ProjectResponseDTO>(entity);
                return Ok(projectDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(ProjectController)} | {nameof(Update)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = DataManager.Projects.Delete(id);
                DataManager.Save();

                var projectDTO = Mapper.Map<Project, ProjectResponseDTO>(entity);
                return Ok(projectDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(ProjectController)} | {nameof(Delete)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPost]
        [Route("createProject")]
        public IHttpActionResult CreateProject(CreateProjectRequestDTO project)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var entity = DataManager.Projects.AddProjectAndQueries(project.Name, project.Queries);
                DataManager.Save();

                var projectDTO = Mapper.Map<Project, ProjectResponseDTO>(entity);
                return Ok(projectDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(ProjectController)} | {nameof(Create)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }
    }
}
