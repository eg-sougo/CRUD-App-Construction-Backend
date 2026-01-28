using ConstructionBackend1._0.DTOs.Engineers;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionBackend1._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IEngineerService _engineerService;

        public UserController(IEngineerService engineerService)
        {
            _engineerService = engineerService;
        }

        // GET: api/user/engineers
        [HttpGet("engineers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllEngineers()
        {
            var engineers = await _engineerService.GetAllEngineers();
            return Ok(engineers);
        }

        // GET: api/user/engineers/{id}
        [HttpGet("engineers/{id}")]
        public async Task<ActionResult<User>> GetEngineerById(int id)
        {
            var engineer = await _engineerService.GetEngineerById(id);

            if (engineer == null)
                return NotFound();

            return Ok(engineer);
        }

        // POST: api/user/engineers
        [HttpPost("engineers")]
        public async Task<ActionResult<User>> CreateEngineer(CreateEngineerDto dto)
        {
            var engineer = await _engineerService.CreateEngineer(dto);

            return CreatedAtAction(
                nameof(GetEngineerById),
                new { id = engineer.UserId },
                engineer
            );
        }

        // PUT: api/user/engineers/{id}
        [HttpPut("engineers/{id}")]
        public async Task<IActionResult> UpdateEngineer(int id, UpdateEngineerDto dto)
        {
            var updated = await _engineerService.UpdateEngineer(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/user/engineers/{id}
        [HttpDelete("engineers/{id}")]
        public async Task<IActionResult> DeleteEngineer(int id)
        {
            var deleted = await _engineerService.DeleteEngineer(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
