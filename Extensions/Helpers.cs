using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApplication.Models;

namespace WebAPIApplication.Extensions
{
    public class Helpers
    {
        private readonly VineyardNextContext _context;

        public Helpers(VineyardNextContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrationFull(int Id)
        {
            Groups group = await _context.Groups.Where(g => g.Id == Id).FirstOrDefaultAsync();
            List<GroupMembers> members = await _context.GroupMembers.Where(m => m.GroupId == group.Id).ToListAsync();
            if (members.Count >= group.MaxSize)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsUnder15(int Id)
        {
            Members member = await _context.Members.FindAsync(Id);
            DateTime now = new DateTime( (DateTime.Now.Year - 15), DateTime.Now.Month, DateTime.Now.Day);
            Boolean over15 = member.Birthday.Value.CompareTo(now) == 1 ? false : true;
            return over15;
        }

        public Members SanitizeMember(Members member)
        {
            member.FirstName = "";
            member.LastName = "";
            member.FullName = "";
            member.Email = "";
            member.Birthday = null;
            member.Nickname = "";
            member.Picture = "";

            return member;
        }

    }
}
