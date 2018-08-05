using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _88servagentAPI.Models;
using _88servagentAPI.DTO;

namespace _88servagentAPI.Controllers
{
    [Route("api/temperatures")]
    [ApiController]
    public class HeatHumiditiesController : ControllerBase
    {
        private readonly ApiContext _context;

        public HeatHumiditiesController(ApiContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
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
        public ActionResult<HeatHumidityDTO> PostHeatHumidity([FromBody] HeatHumidityDTO heatHumidityDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Device device =  _context.Device.Find(heatHumidityDTO.DeviceId);
            if (device == null) return NotFound(device);

            PreventiveAction preventiveAction = PreventiveAction.None;
            if(heatHumidityDTO.PreventiveAction == 1)
            {
                preventiveAction = PreventiveAction.IncreaseTemperature;
            }
            else if(heatHumidityDTO.PreventiveAction == 2)
            {
                preventiveAction = PreventiveAction.DecreaseTemperature;
            }

            HeatHumidity heatHumidity = new HeatHumidity()
            {
                Temperature = heatHumidityDTO.Temperature,
                TemperatureUnit = "°C",
                Humidity = heatHumidityDTO.Humidity,
                PreventiveAction = preventiveAction,
                DateTime = DateTime.Now
            };

            heatHumidity.Device = device;
            _context.HeatHumidity.Add(heatHumidity);
            _context.SaveChanges();
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