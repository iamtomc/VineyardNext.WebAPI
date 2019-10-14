using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApplication.Models;

namespace WebAPIApplication.Extensions
{
    public class PrivacyFilters
    {
        private readonly VineyardNextContext _context;

        public PrivacyFilters(VineyardNextContext context)
        {
            _context = context;
        }

        public bool InSameGroup(int idA, int idB)
        {
            List<GroupMembers> groupListA = _context.GroupMembers.Where(gm => gm.MemberId == idA).ToList();
            List<GroupMembers> groupListB = _context.GroupMembers.Where(gmA => gmA.MemberId == idB).ToList();
            foreach (GroupMembers item in groupListA)
            {
                foreach(GroupMembers checks in groupListB)
                {
                    if (item.GroupId == checks.GroupId)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


    }
}
