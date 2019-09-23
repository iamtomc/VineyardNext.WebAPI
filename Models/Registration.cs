using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApplication.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RegistrationStatus { get; set; }
    }
}
