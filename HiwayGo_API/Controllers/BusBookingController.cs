using HiwayGo_API.Entity;
using HiwayGo_API.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HiwayGo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusBookingController : ControllerBase
    {
        private readonly IBusBookingLogic _logic;

        public BusBookingController(IBusBookingLogic logic)
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

        [HttpGet("route/{routeId:guid}/count")]
        public async Task<IActionResult> CountForRoute(Guid routeId)
        {
            var count = await _logic.CountBookingsForRouteAsync(routeId);
            return Ok(new { routeId, count });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BusBooking booking)
        {
            var created = await _logic.CreateAsync(booking);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BusBooking booking)
        {
            if (booking == null || booking.Id != id) return BadRequest();
            var existing = await _logic.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _logic.UpdateAsync(booking);
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