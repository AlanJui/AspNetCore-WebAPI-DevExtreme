using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Produces("application/json")]
    [Route("api/Territories")]
    public class TerritoriesController : Controller
    {
        private readonly NorthwindContext _context;

        public TerritoriesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Territories
        [HttpGet]
        public IEnumerable<Territory> GetTerritories()
        {
            return _context.Territories;
        }

        // GET: api/Territories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTerritory([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var territory = await _context.Territories.SingleOrDefaultAsync(m => m.TerritoryId == id);

            if (territory == null)
            {
                return NotFound();
            }

            return Ok(territory);
        }

        // PUT: api/Territories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerritory([FromRoute] string id, [FromBody] Territory territory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != territory.TerritoryId)
            {
                return BadRequest();
            }

            _context.Entry(territory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerritoryExists(id))
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

        // POST: api/Territories
        [HttpPost]
        public async Task<IActionResult> PostTerritory([FromBody] Territory territory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Territories.Add(territory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TerritoryExists(territory.TerritoryId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTerritory", new { id = territory.TerritoryId }, territory);
        }

        // DELETE: api/Territories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerritory([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var territory = await _context.Territories.SingleOrDefaultAsync(m => m.TerritoryId == id);
            if (territory == null)
            {
                return NotFound();
            }

            _context.Territories.Remove(territory);
            await _context.SaveChangesAsync();

            return Ok(territory);
        }

        private bool TerritoryExists(string id)
        {
            return _context.Territories.Any(e => e.TerritoryId == id);
        }
    }
}