using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _88servagentAPI.Models;

namespace _88servagentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ApiContext _context;

        public NotificationsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Notifications
        [HttpGet]
        public IEnumerable<Notification> GetNotification()
        {
            return _context.Notification;
        }

        // GET: api/Notifications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotification([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notification = await _context.Notification.FindAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        // PUT: api/Notifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotification([FromRoute] int id, [FromBody] Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notification.Id)
            {
                return BadRequest();
            }

            _context.Entry(notification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notifications
        [HttpPost]
        public async Task<IActionResult> PostNotification([FromBody] Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Notification.Add(notification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotification", new { id = notification.Id }, notification);
        }

        // DELETE: api/Notifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notification = await _context.Notification.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            _context.Notification.Remove(notification);
            await _context.SaveChangesAsync();

            return Ok(notification);
        }

        private bool NotificationExists(int id)
        {
            return _context.Notification.Any(e => e.Id == id);
        }
    }
}