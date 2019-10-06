using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class Friends
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int FriendId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
