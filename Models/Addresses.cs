using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class Addresses
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AddressName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string AddressType { get; set; }
        public bool IsActive { get; set; }
        public string PrivacyFlag { get; set; }
    }
}
