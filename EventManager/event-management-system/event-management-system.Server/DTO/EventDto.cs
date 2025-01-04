using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace event_management_system.Server.DTO
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public required ICollection<AttendeeDto> Attendees { get; set; }
    }
}