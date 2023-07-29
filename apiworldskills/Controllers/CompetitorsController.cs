using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiworldskills.Models;

namespace apiworldskills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly WorldskillsContext _context;

        public CompetitorsController(WorldskillsContext context)
        {
            _context = context;
        }

        // GET: api/Competitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competitor>>> GetCompetitors()
        {
          if (_context.Competitors == null)
          {
              return NotFound();
          }
            return await _context.Competitors.ToListAsync();
        }

        // GET: api/Competitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competitor>> GetCompetitor(int? id)
        {
          if (_context.Competitors == null)
          {
              return NotFound();
          }
            var competitor = await _context.Competitors.FindAsync(id);

            if (competitor == null)
            {
                return NotFound();
            }

            return competitor;
        }

        // PUT: api/Competitors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetitor(int? id, Competitor competitor)
        {
            if (id != competitor.Id)
            {
                return BadRequest();
            }

            _context.Entry(competitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitorExists(id))
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

        // POST: api/Competitors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Competitor>> PostCompetitor(Competitor competitor)
        {
          if (_context.Competitors == null)
          {
              return Problem("Entity set 'WorldskillsContext.Competitors'  is null.");
          }
            _context.Competitors.Add(competitor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompetitorExists(competitor.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompetitor", new { id = competitor.Id }, competitor);
        }

        // DELETE: api/Competitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int? id)
        {
            if (_context.Competitors == null)
            {
                return NotFound();
            }
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
            {
                return NotFound();
            }

            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitorExists(int? id)
        {
            return (_context.Competitors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
