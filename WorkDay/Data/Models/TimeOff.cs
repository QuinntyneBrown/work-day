using System;

namespace WorkDay.Data.Models
{
    public class TimeOff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsDeleted { get; set; }
    }
}
