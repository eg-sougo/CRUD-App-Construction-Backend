using ConstructionBackend1._0.DTOs.Projects;
using ConstructionBackend1._0.DTOs.Tasks;
using ConstructionBackend1._0.Models;

namespace ConstructionBackend1._0.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<ResponseTaskDto>> GetAllTask();
        Task<ResponseTaskDto?> GetTaskById(int id);
        Task<IEnumerable<TaskItem>> GetTaskByProjectId(int projectId);
        Task<TaskItem> CreateTask(CreateTaskDto task);
        Task<bool> UpdateAsync(int id, UpdateTaskDto task);
        Task<bool> DeleteAsync(int id);


    }
}
