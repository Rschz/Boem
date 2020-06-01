using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Boem.Models;

namespace Boem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingsController : ControllerBase
    {
        private readonly bolsa_empleosContext _context;

        public JobPostingsController(bolsa_empleosContext context)
        {
            _context = context;
        }

        // GET: api/JobPostings
        [HttpGet]
        public IEnumerable<JobPosting> GetJobPosting()
        {
            return _context.JobPosting;
        }

        // GET: api/JobPostings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobPosting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobPosting = await _context.JobPosting.Include( x => x.Category)
                                                      .Include(x => x.JobTypeNavigation)
                                                      .Include(x => x.Personal)
                                                      .FirstOrDefaultAsync(x => x.JobPostingId == id);

            if (jobPosting == null)
            {
                return NotFound();
            }

            return Ok(jobPosting);
        }

        // PUT: api/JobPostings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobPosting([FromRoute] int id, [FromBody] JobPosting jobPosting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobPosting.JobPostingId)
            {
                return BadRequest();
            }

            _context.Entry(jobPosting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostingExists(id))
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

        // POST: api/JobPostings
        [HttpPost]
        public async Task<IActionResult> PostJobPosting([FromBody] JobPosting jobPosting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobPosting.Add(jobPosting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobPosting", new { id = jobPosting.JobPostingId }, jobPosting);
        }

        // DELETE: api/JobPostings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobPosting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobPosting = await _context.JobPosting.FindAsync(id);
            if (jobPosting == null)
            {
                return NotFound();
            }

            _context.JobPosting.Remove(jobPosting);
            await _context.SaveChangesAsync();

            return Ok(jobPosting);
        }

        private bool JobPostingExists(int id)
        {
            return _context.JobPosting.Any(e => e.JobPostingId == id);
        }
    }
}