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
    [Route("api/contactmethods")]
    [ApiController]
    public class ContactMethodsController : ControllerBase
    {
        private readonly VineyardNextContext _context;

        public ContactMethodsController(VineyardNextContext context)
        {
            _context = context;
        }

        // GET: api/ContactMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactMethods>>> GetContactMethods()
        {
            return await _context.ContactMethods.ToListAsync();
        }

        // GET: api/ContactMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactMethods>> GetContactMethods(int id)
        {
            var contactMethods = await _context.ContactMethods.FindAsync(id);

            if (contactMethods == null)
            {
                return NotFound();
            }

            return contactMethods;
        }

        // PUT: api/ContactMethods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactMethods(int id, ContactMethods contactMethods)
        {
            if (id != contactMethods.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactMethods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactMethodsExists(id))
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

        // POST: api/ContactMethods
        [HttpPost]
        public async Task<ActionResult<ContactMethods>> PostContactMethods(ContactMethods contactMethods)
        {
            _context.ContactMethods.Add(contactMethods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactMethods", new { id = contactMethods.Id }, contactMethods);
        }

        // DELETE: api/ContactMethods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactMethods>> DeleteContactMethods(int id)
        {
            var contactMethods = await _context.ContactMethods.FindAsync(id);
            if (contactMethods == null)
            {
                return NotFound();
            }

            _context.ContactMethods.Remove(contactMethods);
            await _context.SaveChangesAsync();

            return contactMethods;
        }

        private bool ContactMethodsExists(int id)
        {
            return _context.ContactMethods.Any(e => e.Id == id);
        }
    }
}
