using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class ContactMethods
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public int Preference { get; set; }
        public string Contact { get; set; }
        public string IsActive { get; set; }
        public string PrivacyFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int? MemberContactsId { get; set; }

        public virtual MemberContacts MemberContacts { get; set; }
    }
}
