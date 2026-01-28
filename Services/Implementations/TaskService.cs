using ConstructionBackend1._0.DTOs.Tasks;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConstructionBackend1._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITaskService taskService, ILogger<TasksController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetAllTasks()
        {
            _logger.LogInformation("GET api/tasks called");

            var tasks = await _taskService.GetAllTask();

            _logger.LogInformation("GET api/tasks completed");

            return Ok(tasks);
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseTaskDto>> GetTaskById(int id)
        {
            _logger.LogInformation("GET api/tasks/{Id} called", id);

            var task = await _taskService.GetTaskById(id);

            if (task == null)
            {
                _logger.LogWarning("Task not found with Id={Id}", id);
                return NotFound();
            }

            return Ok(task);
        }

        // GET: api/tasks/project/3
        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasksByProject(int projectId)
        {
            _logger.LogInformation("GET api/tasks/project/{ProjectId} called", projectId);

            var tasks = await _taskService.GetTaskByProjectId(projectId);

            return Ok(tasks);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(CreateTaskDto dto)
        {
            _logger.LogInformation("POST api/tasks called for ProjectId={ProjectId}", dto.ProjectId);

            var task = await _taskService.CreateTask(dto);

            _logger.LogInformation("Task created via API with Id={TaskId}", task.TaskItemId);

            return CreatedAtAction(nameof(GetTaskById), new { id = task.TaskItemId }, task);
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto dto)
        {
            _logger.LogInformation("PUT api/tasks/{Id} called", id);

            var updated = await _taskService.UpdateAsync(id, dto);

            if (!updated)
            {
                _logger.LogWarning("Update failed. Task not found Id={Id}", id);
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            _logger.LogInformation("DELETE api/tasks/{Id} called", id);

            var deleted = await _taskService.DeleteAsync(id);

            if (!deleted)
            {
                _logger.LogWarning("Delete failed. Task not found Id={Id}", id);
                return NotFound();
            }

            return NoContent();
        }
    }
}
