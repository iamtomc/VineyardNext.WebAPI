using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApplication.Models;

namespace WebAPIApplication.Extensions
{
    public class Converter
    {
        public static List<Groups> SanitizeGroups(List<Groups> groups)
        {
            foreach (var item in groups)
            {
                SanitizeGroup(item);
            }

            return groups;
        }

        public static Groups SanitizeGroup(Groups group)
        {
            group.GroupAddresses = null;
            group.GroupAddressesId = null;
            group.GroupMembers = null;
            group.GroupMembersId = null;

            return group;
        }
    }
}
