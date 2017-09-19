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
    [Route("api/EmployeeTerritories")]
    public class EmployeeTerritoriesController : Controller
    {
        private readonly NorthwindContext _context;

        public EmployeeTerritoriesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeTerritories
        [HttpGet]
        public IEnumerable<EmployeeTerritories> GetEmployeeTerritories()
        {
            return _context.EmployeeTerritories;
        }

        // GET: api/EmployeeTerritories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeTerritories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeTerritories = await _context.EmployeeTerritories.SingleOrDefaultAsync(m => m.EmployeeId == id);

            if (employeeTerritories == null)
            {
                return NotFound();
            }

            return Ok(employeeTerritories);
        }

        // PUT: api/EmployeeTerritories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeTerritories([FromRoute] int id, [FromBody] EmployeeTerritories employeeTerritories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeTerritories.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeTerritories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTerritoriesExists(id))
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

        // POST: api/EmployeeTerritories
        [HttpPost]
        public async Task<IActionResult> PostEmployeeTerritories([FromBody] EmployeeTerritories employeeTerritories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmployeeTerritories.Add(employeeTerritories);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeTerritoriesExists(employeeTerritories.EmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeTerritories", new { id = employeeTerritories.EmployeeId }, employeeTerritories);
        }

        // DELETE: api/EmployeeTerritories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeTerritories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeTerritories = await _context.EmployeeTerritories.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeTerritories == null)
            {
                return NotFound();
            }

            _context.EmployeeTerritories.Remove(employeeTerritories);
            await _context.SaveChangesAsync();

            return Ok(employeeTerritories);
        }

        private bool EmployeeTerritoriesExists(int id)
        {
            return _context.EmployeeTerritories.Any(e => e.EmployeeId == id);
        }
    }
}