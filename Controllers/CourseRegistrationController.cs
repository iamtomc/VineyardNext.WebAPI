using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class CourseRegistrationController : ControllerBase
    {
        private readonly VineyardNextContext _context;

        public CourseRegistrationController(VineyardNextContext context)
        {
            _context = context;
        }

        // POST: api/RegisterCourse/5
        [HttpPost("{id}")]
        public async Task<ActionResult<Registration>> Register(int id, [FromBody] Registration registration)
        {
            Groups group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            Members member = MemberRegistered(registration.Email, registration.FirstName, registration.LastName);

            if (member == null)
            {
                member = new Members();
                member.FirstName = registration.FirstName;
                member.LastName = registration.LastName;
                member.Email = registration.Email;
                member.FullName = registration.FullName;

                _context.Members.Add(member);
                // _context.SaveChangesAsync();
                // member = MemberRegistered(registration.Email, registration.FirstName, registration.LastName);
            }

            IEnumerable<GroupMembers> enrolled = await _context.GroupMembers.Where(g => g.GroupId == registration.GroupId).ToListAsync();

            // Check if member previously enrolled in specific group;
            if (MemberEnrolled(member.Id, id))
            {
                return NoContent();
            }

            GroupMembers addMember = new GroupMembers();
            addMember.MemberId = member.Id;
            addMember.Member = member;
            addMember.GroupId = id;
            addMember.CreatedDate = System.DateTime.Now;
            addMember.UpdatedDate = System.DateTime.Now;
            addMember.CreatedBy = User.Identity.Name;
            addMember.UpdatedBy = User.Identity.Name;

            _context.GroupMembers.Add(addMember);
            await _context.SaveChangesAsync();

            return Ok(registration);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> MemberRegistrations(int id)
        {
            List<GroupMembers> groupMemberships = await _context.GroupMembers.Include(g => g.Groups).ToListAsync();

            if (groupMemberships == null)
            {
                return NotFound();
            }

            return Ok(groupMemberships);
        }

        private bool MemberEnrolled(int MemberId, int GroupId)
        {
            return _context.GroupMembers.Any(gm => gm.GroupId == GroupId && gm.MemberId == MemberId);
        }

        private Members MemberRegistered(string Email, string FirstName, string LastName)
        {
            return _context.Members.Where(m => m.Email == Email || (m.FirstName == FirstName && m.LastName == LastName)).FirstOrDefault();
        }
    }
}