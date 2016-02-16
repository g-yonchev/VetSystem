using System;
using VetSystem.Data.Common.Models;

namespace VetSystem.Data.Models
{
    public class Task : BaseModel<int>
    {
        public string Title { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string StartTimezone{ get; set; }

        public string EndTimezone { get; set; }

        public string Description { get; set; }

        public bool IsAllDay { get; set; }

        public string OwnerID { get; set; }

        public virtual User Owner { get; set; }

        public string Recurrence1 { get; set; }

        public string Recurrence2 { get; set; }

        public string RecurrenceException { get; set; }
    }
}
