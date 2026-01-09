using HiwayGo_API.Entity;
using HiwayGo_API.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HiwayGo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _logic;

        public UserController(IUserLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("GetAll")]
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

        [HttpGet("nic/{nic}")]
        public async Task<IActionResult> GetByNic(string nic)
        {
            var item = await _logic.GetByNicAsync(nic);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var created = await _logic.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] User user)
        {
            if (user == null || user.Id != id) return BadRequest();
            var existing = await _logic.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _logic.UpdateAsync(user);
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