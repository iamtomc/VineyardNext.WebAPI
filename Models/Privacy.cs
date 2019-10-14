using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApplication.Models
{
    public class Privacy
    {
        public int Id{ get; set; }
        public int MemberId { get; set; }
        public Setting[] Settings { get; set; }
    }

    public enum AccessLevel
    {
        Pastors,
        Ministry,
        GroupLeader,
        GroupMember,
        Friends,
        Family,
        Self
    }

    public class Setting
    {
        public string Name { get; set; }
        public PrivacySetting[] PrivacySettings { get; set; }
    }

    public class PrivacySetting
    {
        public AccessLevel Access { get; set; }
        public bool Value { get; set; }
    }
}
