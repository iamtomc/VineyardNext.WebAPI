using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    [Route("api/familymembers")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly VineyardNextContext _context;

        public FamilyMembersController(VineyardNextContext context)
        {
            _context = context;
        }

        // GET: api/FamilyMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyMembers>>> GetFamilyMembers()
        {
            return await _context.FamilyMembers.ToListAsync();
        }

        // GET: api/FamilyMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyMembers>> GetFamilyMembers(int id)
        {
            var familyMembers = await _context.FamilyMembers.FindAsync(id);

            if (familyMembers == null)
            {
                return NotFound();
            }

            return familyMembers;
        }

        // PUT: api/FamilyMembers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilyMembers(int id, FamilyMembers familyMembers)
        {
            if (id != familyMembers.Id)
            {
                return BadRequest();
            }

            _context.Entry(familyMembers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyMembersExists(id))
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

        // POST: api/FamilyMembers
        [HttpPost]
        public async Task<ActionResult<FamilyMembers>> PostFamilyMembers(FamilyMembers familyMembers)
        {
            _context.FamilyMembers.Add(familyMembers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamilyMembers", new { id = familyMembers.Id }, familyMembers);
        }

        // DELETE: api/FamilyMembers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FamilyMembers>> DeleteFamilyMembers(int id)
        {
            var familyMembers = await _context.FamilyMembers.FindAsync(id);
            if (familyMembers == null)
            {
                return NotFound();
            }

            _context.FamilyMembers.Remove(familyMembers);
            await _context.SaveChangesAsync();

            return familyMembers;
        }

        private bool FamilyMembersExists(int id)
        {
            return _context.FamilyMembers.Any(e => e.Id == id);
        }
    }
}
