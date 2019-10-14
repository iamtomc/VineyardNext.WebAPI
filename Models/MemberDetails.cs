using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApplication.Models
{
    public class MemberDetails
    {
        public Members Member { get; set; }
        public List<Addresses> Addresses { get; set; }
        public List<ContactMethods> Contacts { get; set; }
        public List<Groups> Groups { get; set; }
    }
}
