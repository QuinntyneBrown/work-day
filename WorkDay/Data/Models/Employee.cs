using System;
using System.Collections.Generic;

namespace WorkDay.Data.Models
{
    public class Employee: ILoggable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public ICollection<TimeOff> TimeOffs { get; set; } = new HashSet<TimeOff>();
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
