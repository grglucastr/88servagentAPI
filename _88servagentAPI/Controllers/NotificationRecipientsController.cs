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
    public class NotificationRecipientsController : ControllerBase
    {
        private readonly ApiContext _context;

        public NotificationRecipientsController(ApiContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/NotificationRecipients
        [HttpGet]
        public IEnumerable<NotificationRecipient> GetNotificationRecipient()
        {
            return _context.NotificationRecipient;
        }

        // GET: api/NotificationRecipients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationRecipient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notificationRecipient = await _context.NotificationRecipient.FindAsync(id);

            if (notificationRecipient == null)
            {
                return NotFound();
            }

            return Ok(notificationRecipient);
        }

        // PUT: api/NotificationRecipients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationRecipient([FromRoute] int id, [FromBody] NotificationRecipient notificationRecipient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificationRecipient.Id)
            {
                return BadRequest();
            }

            _context.Entry(notificationRecipient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationRecipientExists(id))
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

        // POST: api/NotificationRecipients
        [HttpPost]
        public async Task<IActionResult> PostNotificationRecipient([FromBody] NotificationRecipient notificationRecipient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NotificationRecipient.Add(notificationRecipient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificationRecipient", new { id = notificationRecipient.Id }, notificationRecipient);
        }

        // DELETE: api/NotificationRecipients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationRecipient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notificationRecipient = await _context.NotificationRecipient.FindAsync(id);
            if (notificationRecipient == null)
            {
                return NotFound();
            }

            _context.NotificationRecipient.Remove(notificationRecipient);
            await _context.SaveChangesAsync();

            return Ok(notificationRecipient);
        }

        private bool NotificationRecipientExists(int id)
        {
            return _context.NotificationRecipient.Any(e => e.Id == id);
        }
    }
}