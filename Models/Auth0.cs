using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class Auth0
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Auth0Sub { get; set; }
        public string Auth0GivenName { get; set; }
        public string Auth0FamilyName { get; set; }
        public string Auth0Nickname { get; set; }
        public string Auth0Name { get; set; }
        public bool? Merged { get; set; }

        public virtual MemberAddresses Member { get; set; }
    }
}
