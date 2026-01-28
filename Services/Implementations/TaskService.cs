using ConstructionBackend1._0.Data;
using ConstructionBackend1._0.DTOs.Projects;
using ConstructionBackend1._0.DTOs.Tasks;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstructionBackend1._0.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ConstructionDbContext _context;

        public TaskService(ConstructionDbContext context)
        {
            _context = context;
        }

        //1.// CREATE TASK
        public async Task<TaskItem> CreateTask(CreateTaskDto task)
        {
            //// Optional validation (recommended)
            //var projectExists = await _context.Projects.AnyAsync(p => p.ProjectId == task.ProjectId);
            //var engineerExists = await _context.Users.AnyAsync(u => u.UserId == task.AssignedTo);

            //if (!projectExists || !engineerExists)
            //    throw new Exception("Invalid project or engineer");

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

            return newTask;
        }



        //2.// GET ALL TASKS
        //public async Task<IEnumerable<TaskItem>> GetAllTask()
        //{


        //    return await _context.Tasks.ToListAsync();
        //    //return await _context.Tasks
        //    //    .Include(t => t.Project)
        //    //    .Include(t => t.Engineer)
        //    //    .ToListAsync();
        //}
        public async Task<IEnumerable<ResponseTaskDto>> GetAllTask()
        {
            return await _context.Tasks
                .Select(t => new ResponseTaskDto
                {
                    TaskItemId = t.TaskItemId,
                    TaskName = t.TaskName,
                    Status = t.Status,
                    ProjectName = t.Project.ProjectName,
                    EngineerName = t.Engineer.FullName
                })
                .ToListAsync();
        }



        //3.// GET TASK BY ID
        public async Task<ResponseTaskDto?> GetTaskById(int id)
        {
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(t => t.Engineer)
                .FirstOrDefaultAsync(t => t.TaskItemId == id);

            if (task == null)
                return null;

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



        //4.// GET TASKS BY PROJECT
        public async Task<IEnumerable<TaskItem>> GetTaskByProjectId(int projectId)
        {
            return await _context.Tasks
                .Where(t => t.ProjectId == projectId)
                .Include(t => t.Engineer)
                .ToListAsync();
        }



        //5.// UPDATE TASK
        public async Task<bool> UpdateAsync(int id, UpdateTaskDto task)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskItemId == id);

            if (existingTask == null)
                return false;

            existingTask.TaskName = task.TaskName;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.DueDate = task.DueDate;
            existingTask.AssignedTo = task.AssignedTo;

            await _context.SaveChangesAsync();
            return true;
        }


        //6.// DELETE TASK
        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskItemId == id);

            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
