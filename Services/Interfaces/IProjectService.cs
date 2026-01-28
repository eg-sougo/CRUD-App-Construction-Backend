using ConstructionBackend1._0.DTOs.Projects;
using ConstructionBackend1._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionBackend1._0.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>>GetAllProjects();
        Task<Project?> GetProjectById(int id);
        Task<Project> CreateProject(CreateProjectDto proj);
        Task<bool> UpdateProject(int id, UpdateProjectDto proj);
        Task<bool> DeleteProject(int id);
    }
}
