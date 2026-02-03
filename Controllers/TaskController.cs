using ConstructionBackend1._0.DTOs.Projects;
using ConstructionBackend1._0.DTOs.Tasks;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionBackend1._0.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // 1️⃣ GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTask();
            return Ok(tasks);
        }

        // 2️⃣ GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseTaskDto>> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskById(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // 3️⃣ GET: api/tasks/project/3
        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasksByProject(int projectId)
        {
            var tasks = await _taskService.GetTaskByProjectId(projectId);
            return Ok(tasks);
        }

        // 4️⃣ POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(CreateTaskDto dto)
        {
            var task = await _taskService.CreateTask(dto);

            return CreatedAtAction(
                nameof(GetTaskById),
                new { id = task.TaskItemId },
                task
            );
        }

        // 5️⃣ PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto dto)
        {
            var updated = await _taskService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // 6️⃣ DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
