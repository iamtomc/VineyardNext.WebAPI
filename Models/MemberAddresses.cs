﻿using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class MemberAddresses
    {
        public MemberAddresses()
        {
            Addresses = new HashSet<Addresses>();
            Auth0 = new HashSet<Auth0>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int MemberId { get; set; }
        public int AddressId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Members Member { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Auth0> Auth0 { get; set; }
    }
}
