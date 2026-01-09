using HiwayGo_API.Entity;
using HiwayGo_API.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HiwayGo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusDetailController : ControllerBase
    {
        private readonly IBusDetailLogic _logic;

        public BusDetailController(IBusDetailLogic logic)
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

        [HttpGet("owner/{ownerId:guid}")]
        public async Task<IActionResult> GetByOwner(Guid ownerId)
        {
            var item = await _logic.GetByOwnerAsync(ownerId);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BusDetail detail)
        {
            var created = await _logic.CreateAsync(detail);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BusDetail detail)
        {
            if (detail == null || detail.Id != id) return BadRequest();
            var existing = await _logic.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _logic.UpdateAsync(detail);
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