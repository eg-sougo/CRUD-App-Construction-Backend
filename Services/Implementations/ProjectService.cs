using ConstructionBackend1._0.Data;
using ConstructionBackend1._0.DTOs.Projects;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace ConstructionBackend1._0.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly ILogger<ProjectService> _logger;
        private readonly ConstructionDbContext _context;

        public ProjectService (ConstructionDbContext context, ILogger<ProjectService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public  async Task<IEnumerable<Project>> GetAllProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            _logger.LogInformation("List Of Projects Returned"); 
            return projects;
        }

        public async Task<Project?> GetProjectById(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(proj => proj.ProjectId == id);
            _logger.LogInformation("Project By Id Returned");
            return project;
        }
        public async Task<Project?> CreateProject(CreateProjectDto proj)
        {
            var newProject = new Project
            {
                ProjectName = proj.ProjectName,
                Description = proj.Description,
                StartDate = proj.StartDate,
                EndDate = proj.EndDate,
                CreatorID = proj.CreatorID,
                Status = "Planned"
            };

            var creatorExists = await _context.Users.AnyAsync(u => u.UserId == proj.CreatorID);
            if (!creatorExists)
                return null;

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();
            return newProject;

        }

        public async Task<bool> DeleteProject(int id)
        {
            var proj= await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);

            if (proj == null)
                return false;

             _context.Projects.Remove(proj);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateProject(int id, UpdateProjectDto proj)
        {
            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);

            if (existingProject == null)
                return false;

            existingProject.ProjectName = proj.ProjectName;
            existingProject.Description = proj.Description;
            existingProject.Status = proj.Status;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
