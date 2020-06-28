using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CONTECH2.Models;

namespace CONTECH2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly ConTechDBContext _context;

        public LabelsController(ConTechDBContext context)
        {
            _context = context;
        }

        // GET: api/Labels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Labels>>> GetLabels()
        {
            return await _context.Labels.ToListAsync();
        }

        // GET: api/Labels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Labels>> GetLabels(long id)
        {
            var labels = await _context.Labels.FindAsync(id);

            if (labels == null)
            {
                return NotFound();
            }

            return labels;
        }

        // PUT: api/Labels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabels(long id, Labels labels)
        {
            if (id != labels.Id)
            {
                return BadRequest();
            }

            _context.Entry(labels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabelsExists(id))
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

        // POST: api/Labels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Labels>> PostLabels(Labels labels)
        {
            _context.Labels.Add(labels);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LabelsExists(labels.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLabels", new { id = labels.Id }, labels);
        }

        // DELETE: api/Labels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Labels>> DeleteLabels(long id)
        {
            var labels = await _context.Labels.FindAsync(id);
            if (labels == null)
            {
                return NotFound();
            }

            _context.Labels.Remove(labels);
            await _context.SaveChangesAsync();

            return labels;
        }

        private bool LabelsExists(long id)
        {
            return _context.Labels.Any(e => e.Id == id);
        }
    }
}
