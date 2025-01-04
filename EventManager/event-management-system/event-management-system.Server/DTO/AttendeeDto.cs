using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace event_management_system.Server.DTO
{
    public class AttendeeDto
    {
        public int AttendeeId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}