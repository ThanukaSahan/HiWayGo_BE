using HiwayGo_API.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HiwayGo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleLogic _logic;

        public UserRoleController(IUserRoleLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _logic.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _logic.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("name/{roleName}")]
        public async Task<IActionResult> GetByName(string roleName)
        {
            var item = await _logic.GetByNameAsync(roleName);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HiwayGo_API.Entity.UserRole role)
        {
            var created = await _logic.CreateAsync(role);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] HiwayGo_API.Entity.UserRole role)
        {
            if (role == null || role.Id != id) return BadRequest();
            var existing = await _logic.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _logic.UpdateAsync(role);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removed = await _logic.DeleteAsync(id);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}