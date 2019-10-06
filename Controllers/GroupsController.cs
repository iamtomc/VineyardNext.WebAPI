﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Models;

namespace WebAPIApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly VineyardNextContext _context;

        public GroupsController(VineyardNextContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groups>>> GetGroups()
        {
            List<Groups> groups = await _context.Groups.Where(g => g.IsActive == true).ToListAsync();
            return Ok(groups);
        }

        // GET: api/Groups/Inactive
        [HttpGet("Inactive")]
        public async Task<ActionResult<IEnumerable<Groups>>> GetInActiveGroups()
        {
            List<Groups> groups = await _context.Groups.Where(g => g.IsActive == false).ToListAsync();
            return Ok(groups);
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Groups>> GetGroups(int id)
        {
            var groups = await _context.Groups.FindAsync(id);

            if (groups == null)
            {
                return NotFound();
            }

            return groups;
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups(int id, [FromBody] Groups groups)
        {
            if (id != groups.Id)
            {
                return BadRequest();
            }

            _context.Entry(groups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupsExists(id))
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

        // POST: api/Groups
        [HttpPost]
        public async Task<ActionResult<Groups>> PostGroups([FromBody] Groups groups)
        {
            _context.Groups.Add(groups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroups", new { id = groups.Id }, groups);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Groups>> DeleteGroups(int id)
        {
            var groups = await _context.Groups.FindAsync(id);
            if (groups == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(groups);
            await _context.SaveChangesAsync();

            return groups;
        }

        private bool GroupsExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
