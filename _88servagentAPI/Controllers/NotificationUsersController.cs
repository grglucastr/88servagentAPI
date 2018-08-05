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
    public class NotificationUsersController : ControllerBase
    {
        private readonly ApiContext _context;

        public NotificationUsersController(ApiContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/NotificationUsers
        [HttpGet]
        public IEnumerable<NotificationUser> GetNotificationUser()
        {
            return _context.NotificationUser;
        }

        // GET: api/NotificationUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notificationUser = await _context.NotificationUser.FindAsync(id);

            if (notificationUser == null)
            {
                return NotFound();
            }

            return Ok(notificationUser);
        }

        // PUT: api/NotificationUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationUser([FromRoute] int id, [FromBody] NotificationUser notificationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificationUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(notificationUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationUserExists(id))
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

        // POST: api/NotificationUsers
        [HttpPost]
        public async Task<IActionResult> PostNotificationUser([FromBody] NotificationUser notificationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NotificationUser.Add(notificationUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificationUser", new { id = notificationUser.Id }, notificationUser);
        }

        // DELETE: api/NotificationUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notificationUser = await _context.NotificationUser.FindAsync(id);
            if (notificationUser == null)
            {
                return NotFound();
            }

            _context.NotificationUser.Remove(notificationUser);
            await _context.SaveChangesAsync();

            return Ok(notificationUser);
        }

        private bool NotificationUserExists(int id)
        {
            return _context.NotificationUser.Any(e => e.Id == id);
        }
    }
}