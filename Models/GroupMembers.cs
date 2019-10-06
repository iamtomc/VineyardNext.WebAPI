using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class GroupMembers
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int MemberId { get; set; }
        public int GroupId { get; set; }
    }
}
