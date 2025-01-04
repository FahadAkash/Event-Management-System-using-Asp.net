using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace event_management_system.Server.Model
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int EventId { get; set; } // Foreign Key
        public Event Event { get; set; } // Navigation Property
    }
}