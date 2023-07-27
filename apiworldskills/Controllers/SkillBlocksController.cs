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
    public class SkillBlocksController : ControllerBase
    {
        private readonly WorldskillsContext _context;

        public SkillBlocksController(WorldskillsContext context)
        {
            _context = context;
        }

        // GET: api/SkillBlocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillBlock>>> GetSkillBlocks()
        {
          if (_context.SkillBlocks == null)
          {
              return NotFound();
          }
            return await _context.SkillBlocks.ToListAsync();
        }

        // GET: api/SkillBlocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillBlock>> GetSkillBlock(int? id)
        {
          if (_context.SkillBlocks == null)
          {
              return NotFound();
          }
            var skillBlock = await _context.SkillBlocks.FindAsync(id);

            if (skillBlock == null)
            {
                return NotFound();
            }

            return skillBlock;
        }

        // PUT: api/SkillBlocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillBlock(int? id, SkillBlock skillBlock)
        {
            if (id != skillBlock.Id)
            {
                return BadRequest();
            }

            _context.Entry(skillBlock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillBlockExists(id))
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

        // POST: api/SkillBlocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SkillBlock>> PostSkillBlock(SkillBlock skillBlock)
        {
          if (_context.SkillBlocks == null)
          {
              return Problem("Entity set 'WorldskillsContext.SkillBlocks'  is null.");
          }
            _context.SkillBlocks.Add(skillBlock);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkillBlockExists(skillBlock.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSkillBlock", new { id = skillBlock.Id }, skillBlock);
        }

        // DELETE: api/SkillBlocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillBlock(int? id)
        {
            if (_context.SkillBlocks == null)
            {
                return NotFound();
            }
            var skillBlock = await _context.SkillBlocks.FindAsync(id);
            if (skillBlock == null)
            {
                return NotFound();
            }

            _context.SkillBlocks.Remove(skillBlock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillBlockExists(int? id)
        {
            return (_context.SkillBlocks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
