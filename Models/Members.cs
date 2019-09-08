using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class Members
    {
        public Members()
        {
            FamilyMembers = new HashSet<FamilyMembers>();
            GroupMembers = new HashSet<GroupMembers>();
            MemberAddresses = new HashSet<MemberAddresses>();
            MemberContacts = new HashSet<MemberContacts>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public bool? EmailVerified { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Locale { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Picture { get; set; }
        public string ProviderId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Privacy { get; set; }

        public virtual ICollection<FamilyMembers> FamilyMembers { get; set; }
        public virtual ICollection<GroupMembers> GroupMembers { get; set; }
        public virtual ICollection<MemberAddresses> MemberAddresses { get; set; }
        public virtual ICollection<MemberContacts> MemberContacts { get; set; }
    }
}
