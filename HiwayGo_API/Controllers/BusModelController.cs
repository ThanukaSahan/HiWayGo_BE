using HiwayGo_API.Entity;
using HiwayGo_API.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HiwayGo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusModelController : ControllerBase
    {
        private readonly IBusModelLogic _logic;

        public BusModelController(IBusModelLogic logic)
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

        [HttpGet("model/{model}")]
        public async Task<IActionResult> GetByModel(string model)
        {
            var item = await _logic.GetByModelAsync(model);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BusModel model)
        {
            var created = await _logic.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BusModel model)
        {
            if (model == null || model.Id != id) return BadRequest();
            var existing = await _logic.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _logic.UpdateAsync(model);
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