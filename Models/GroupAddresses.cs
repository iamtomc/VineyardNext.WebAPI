using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class GroupAddresses
    {
        public GroupAddresses()
        {
            Addresses = new HashSet<Addresses>();
            Groups = new HashSet<Groups>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int GroupId { get; set; }
        public int AddressId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Groups> Groups { get; set; }
    }
}
