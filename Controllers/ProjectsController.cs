using ConstructionBackend1._0.DTOs.Engineers;
using ConstructionBackend1._0.DTOs.Projects;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Implementations;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace ConstructionBackend1._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            var Projects = await _projectService.GetAllProjects();
            return Ok(Projects);
        }

        // GET: api/projects/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {

            var Project = await _projectService.GetProjectById(id);

            if (Project == null)
                return NotFound();

            return Ok(Project);
        }

        // POST: api/projects
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(CreateProjectDto Dto)
        {
            var Project = await _projectService.CreateProject(Dto);

            if(Project==null)
                return BadRequest();


            return CreatedAtAction(
                nameof(GetProjectById),
                new { id = Project.ProjectId },
                Project
            );
        }

        // PUT: api/projects
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, UpdateProjectDto dto)
        {
            var updated = await _projectService.UpdateProject(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/projects
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var Project = await _projectService.DeleteProject(id);

            if (!Project)
            {
                return NotFound();

            }
            return NoContent();

        }

    }
}

