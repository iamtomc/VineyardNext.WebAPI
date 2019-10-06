using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public partial class Groups
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Track { get; set; }
        public bool IsFree { get; set; }
        public bool IsStaffRequired { get; set; }
        public bool IsFull { get; set; }
        public bool IsActive { get; set; }
        public int Cost { get; set; }
        public int MaxSize { get; set; }
        public int StaffingRequired { get; set; }
        public string RequiredMaterials { get; set; }
        public string LeaderComments { get; set; }
        public string DaysOfWeek { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
