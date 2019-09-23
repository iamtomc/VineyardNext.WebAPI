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
    [Route("api/[controller]")]
    [ApiController]
    public class GroupAddressesController : ControllerBase
    {
        private readonly VineyardNextContext _context;

        public GroupAddressesController(VineyardNextContext context)
        {
            _context = context;
        }

        // GET: api/GroupAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupAddresses>>> GetGroupAddresses()
        {
            return await _context.GroupAddresses.ToListAsync();
        }

        // GET: api/GroupAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupAddresses>> GetGroupAddresses(int id)
        {
            var groupAddresses = await _context.GroupAddresses.FindAsync(id);

            if (groupAddresses == null)
            {
                return NotFound();
            }

            return groupAddresses;
        }

        // PUT: api/GroupAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupAddresses(int id, GroupAddresses groupAddresses)
        {
            if (id != groupAddresses.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAddressesExists(id))
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

        // POST: api/GroupAddresses
        [HttpPost]
        public async Task<ActionResult<GroupAddresses>> PostGroupAddresses(GroupAddresses groupAddresses)
        {
            _context.GroupAddresses.Add(groupAddresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupAddresses", new { id = groupAddresses.Id }, groupAddresses);
        }

        // DELETE: api/GroupAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupAddresses>> DeleteGroupAddresses(int id)
        {
            var groupAddresses = await _context.GroupAddresses.FindAsync(id);
            if (groupAddresses == null)
            {
                return NotFound();
            }

            _context.GroupAddresses.Remove(groupAddresses);
            await _context.SaveChangesAsync();

            return groupAddresses;
        }

        private bool GroupAddressesExists(int id)
        {
            return _context.GroupAddresses.Any(e => e.Id == id);
        }
    }
}
