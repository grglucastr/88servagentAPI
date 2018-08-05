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
    public class HeatHumiditiesController : ControllerBase
    {
        private readonly ApiContext _context;

        public HeatHumiditiesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/HeatHumidities
        [HttpGet]
        public IEnumerable<HeatHumidity> GetHeatHumidity()
        {
            return _context.HeatHumidity;
        }

        // GET: api/HeatHumidities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeatHumidity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var heatHumidity = await _context.HeatHumidity.FindAsync(id);

            if (heatHumidity == null)
            {
                return NotFound();
            }

            return Ok(heatHumidity);
        }

        // PUT: api/HeatHumidities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeatHumidity([FromRoute] int id, [FromBody] HeatHumidity heatHumidity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heatHumidity.Id)
            {
                return BadRequest();
            }

            _context.Entry(heatHumidity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeatHumidityExists(id))
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

        // POST: api/HeatHumidities
        [HttpPost]
        public async Task<IActionResult> PostHeatHumidity([FromBody] HeatHumidity heatHumidity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HeatHumidity.Add(heatHumidity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeatHumidity", new { id = heatHumidity.Id }, heatHumidity);
        }

        // DELETE: api/HeatHumidities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeatHumidity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var heatHumidity = await _context.HeatHumidity.FindAsync(id);
            if (heatHumidity == null)
            {
                return NotFound();
            }

            _context.HeatHumidity.Remove(heatHumidity);
            await _context.SaveChangesAsync();

            return Ok(heatHumidity);
        }

        private bool HeatHumidityExists(int id)
        {
            return _context.HeatHumidity.Any(e => e.Id == id);
        }
    }
}