using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class Members
    {
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
        public DateTimeOffset? Birthday { get; set; }
    }
}
