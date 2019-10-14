using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Models;

namespace WebAPIApplication
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly VineyardNextContext _context;

        public MembersController(VineyardNextContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<Members>> GetMembers(int id)
        {            
            var members = await _context.Members.FindAsync(id);

            if (members == null)
            {
                return NotFound();
            }

            return members;
        }

        // Post: api/Members/5/details
        [HttpPost("{id}/details")]
        //[Authorize]
        public async Task<ActionResult<MemberDetails>> GetMemberDetails(int Id, [FromBody] Members member)
        {
            MemberDetails deets = new MemberDetails();
            deets.Addresses = new List<Addresses>();
            deets.Contacts = new List<ContactMethods>();
            deets.Groups = new List<Groups>();

            if (Id == member.Id)
            {
                deets.Member = await _context.Members.Where(m => m.Id == member.Id).FirstOrDefaultAsync();

                if (deets.Member == null)
                {
                    return NotFound();
                }

                var addresses = await _context.MemberAddresses.Join(_context.Addresses,
                      memAddy => memAddy.AddressId,
                      addy => addy.Id,
                      (memAddy, addy) => new
                      {
                          Addresses = addy,
                          MemberAddresses = memAddy

                      }).Where(a => a.MemberAddresses.MemberId == member.Id).ToListAsync();
                Console.WriteLine(addresses);
                if (addresses.Count > 0)
                {
                    foreach (var item in addresses)
                    {
                        deets.Addresses.Add(item.Addresses);
                    }
                }

                var groups = await _context.GroupMembers.Join(_context.Groups,
                    memGroups => memGroups.GroupId,
                    groupList => groupList.Id,
                    (memGroups, groupList) => new
                    {
                        GroupMembers = memGroups,
                        Groups = groupList
                    }).Where(a => a.GroupMembers.MemberId == member.Id).ToListAsync();
                Console.WriteLine(groups);
                if (groups.Count > 0)
                {
                    foreach (var item in groups)
                    {
                        deets.Groups.Add(item.Groups);
                    }
                }

                var contacts = await _context.MemberContacts.Join(_context.ContactMethods,
                    memContacts => memContacts.ContactId,
                    contactList => contactList.Id,
                    (memContacts, contactList) => new
                    {
                        MemberContacts = memContacts,
                        ContactMethods = contactList
                    }).Where(a => a.MemberContacts.MemberId == member.Id).ToListAsync();

                if (contacts.Count > 0)
                {
                    foreach (var item in contacts)
                    {
                        deets.Contacts.Add(item.ContactMethods);
                    }
                }

                return Ok(deets);
            }

            return NotFound();
            
        }


        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembers(int id, Members members)
        {
            if (id != members.Id)
            {
                return BadRequest();
            }

            _context.Entry(members).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersExists(id))
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

        // POST: api/Members
        [HttpPost]
        public async Task<ActionResult<Members>> PostMembers(Members members)
        {
            _context.Members.Add(members);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembers", new { id = members.Id }, members);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Members>> DeleteMembers(int id)
        {
            var members = await _context.Members.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }

            _context.Members.Remove(members);
            await _context.SaveChangesAsync();

            return members;
        }

        private bool MembersExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
