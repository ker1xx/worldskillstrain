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
    public class CompetitionSkillsController : ControllerBase
    {
        private readonly WorldskillsContext _context;

        public CompetitionSkillsController(WorldskillsContext context)
        {
            _context = context;
        }

        // GET: api/CompetitionSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitionSkill>>> GetCompetitionSkills()
        {
          if (_context.CompetitionSkills == null)
          {
              return NotFound();
          }
            return await _context.CompetitionSkills.ToListAsync();
        }

        // GET: api/CompetitionSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitionSkill>> GetCompetitionSkill(int? id)
        {
          if (_context.CompetitionSkills == null)
          {
              return NotFound();
          }
            var competitionSkill = await _context.CompetitionSkills.FindAsync(id);

            if (competitionSkill == null)
            {
                return NotFound();
            }

            return competitionSkill;
        }

        // PUT: api/CompetitionSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetitionSkill(int? id, CompetitionSkill competitionSkill)
        {
            if (id != competitionSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(competitionSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionSkillExists(id))
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

        // POST: api/CompetitionSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompetitionSkill>> PostCompetitionSkill(CompetitionSkill competitionSkill)
        {
          if (_context.CompetitionSkills == null)
          {
              return Problem("Entity set 'WorldskillsContext.CompetitionSkills'  is null.");
          }
            _context.CompetitionSkills.Add(competitionSkill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompetitionSkillExists(competitionSkill.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompetitionSkill", new { id = competitionSkill.Id }, competitionSkill);
        }

        // DELETE: api/CompetitionSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitionSkill(int? id)
        {
            if (_context.CompetitionSkills == null)
            {
                return NotFound();
            }
            var competitionSkill = await _context.CompetitionSkills.FindAsync(id);
            if (competitionSkill == null)
            {
                return NotFound();
            }

            _context.CompetitionSkills.Remove(competitionSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionSkillExists(int? id)
        {
            return (_context.CompetitionSkills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
