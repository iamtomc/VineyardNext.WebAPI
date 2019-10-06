using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class MemberContacts
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int MemberId { get; set; }
        public int ContactId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
