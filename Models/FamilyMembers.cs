using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class FamilyMembers
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public int MemberId { get; set; }
        public bool IsMember { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Members Member { get; set; }
    }
}
