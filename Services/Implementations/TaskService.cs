using ConstructionBackend1._0.Data;
using ConstructionBackend1._0.DTOs.Tasks;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConstructionBackend1._0.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ConstructionDbContext _context;
        private readonly ILogger<TaskService> _logger;

        public TaskService(ConstructionDbContext context, ILogger<TaskService> logger)
        {
            _context = context;
            _logger = logger;
        }

        //CREATE TASK
        public async Task<TaskItem> CreateTask(CreateTaskDto task)
        {
            _logger.LogInformation("Creating task {TaskName} for ProjectId={ProjectId}", task.TaskName, task.ProjectId);

            try
            {
                var newTask = new TaskItem
                {
                    TaskName = task.TaskName,
                    Description = task.Description,
                    StartDate = task.StartDate,
                    DueDate = task.DueDate,
                    ProjectId = task.ProjectId,
                    AssignedTo = task.AssignedTo,
                    Status = "Planned"
                };

                _context.Tasks.Add(newTask);


                await _context.SaveChangesAsync();

                _logger.LogInformation("Task created successfully with TaskItemId={TaskItemId}", newTask.TaskItemId);

                return newTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating task {TaskName}", task.TaskName);
                throw;
            }
        }

        //GET ALL TASKS
        public async Task<IEnumerable<ResponseTaskDto>> GetAllTask()
        {
            _logger.LogInformation("Fetching all tasks");

            try
            {
                var tasks = await _context.Tasks
                    .Select(t => new ResponseTaskDto
                    {
                        TaskItemId = t.TaskItemId,
                        TaskName = t.TaskName,
                        Status = t.Status,
                        ProjectName = t.Project.ProjectName,
                        EngineerName = t.Engineer.FullName
                    })
                    .ToListAsync();

                _logger.LogInformation("Fetched {Count} tasks", tasks.Count);

                return tasks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all tasks");
                throw;
            }
        }

        //GET TASK BY ID
        public async Task<ResponseTaskDto?> GetTaskById(int id)
        {
            _logger.LogInformation("Fetching task with Id={TaskId}", id);

            var task = await _context.Tasks.Include(t => t.Project).Include(t => t.Engineer).FirstOrDefaultAsync(t => t.TaskItemId == id);

            if (task == null)
            {
                _logger.LogWarning("Task not found with Id={TaskId}", id);
                return null;
            }

            _logger.LogInformation("Task found with Id={TaskId}", id);

            return new ResponseTaskDto
            {
                TaskItemId = task.TaskItemId,
                TaskName = task.TaskName,
                Status = task.Status,
                StartDate = task.StartDate,
                DueDate = task.DueDate,
                ProjectId = task.ProjectId,
                ProjectName = task.Project.ProjectName,
                EngineerId = task.AssignedTo,
                EngineerName = task.Engineer.FullName
            };
        }

        //GET TASKS BY PROJECT ID
        public async Task<IEnumerable<ResponseTaskDto>> GetTaskByProjectId(int projectId)
        {

            _logger.LogInformation("Fetching task for project Id={ProjectID}", projectId);

            var tasks= await _context.Tasks
                .Where(t => t.ProjectId == projectId)
                .Select(t => new ResponseTaskDto
                {
                    TaskItemId = t.TaskItemId,
                    TaskName = t.TaskName,
                    Status = t.Status,
                    ProjectId = t.ProjectId,
                    ProjectName = t.Project.ProjectName,
                    EngineerId = t.AssignedTo,
                    EngineerName = t.Engineer.FullName
                })
                .ToListAsync();

            return tasks;
        }

        //UPDATE TASK
        public async Task<bool> UpdateAsync(int id, UpdateTaskDto task)
        {
            _logger.LogInformation("Updating task with Id={TaskId}", id);

            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskItemId == id);

            if (existingTask == null)
            {
                _logger.LogWarning("Update failed. Task not found Id={TaskId}", id);
                return false;
            }

            existingTask.TaskName = task.TaskName;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.DueDate = task.DueDate;
            existingTask.AssignedTo = task.AssignedTo;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Task updated successfully Id={TaskId}", id);

            return true;
        }

        //DELETE TASK
        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting task with Id={TaskId}", id);

            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskItemId == id);

            if (task == null)
            {
                _logger.LogWarning("Delete failed. Task not found Id={TaskId}", id);
                return false;
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Task deleted successfully Id={TaskId}", id);

            return true;
        }
    }
}
