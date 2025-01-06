using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using event_management_system.Server.DbManage;
using event_management_system.Server.DTO;
using event_management_system.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace event_management_system.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventMangementController : ControllerBase
    {
        private readonly EventDbContext _context;
       

        public EventMangementController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var events = await _context.Events
                .Include(e => e.Attendee)
                .Select(e => new EventDto
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Location = e.Location,
                    Attendees = e.Attendee.Select(a => new AttendeeDto
                    {
                        AttendeeId = a.AttendeeId,
                        Name = a.Name,
                        Email = a.Email
                    }).ToList()
                }).ToListAsync();

            return Ok(events);
        }

        // [HttpPost]
        // public async Task<ActionResult<EventDto>> PostEvent(Event MainEvent)
        // {
        //     _context.Events.Add(MainEvent);
        //     await _context.SaveChangesAsync();
        //     return CreatedAtAction("GetEvent", new { id = MainEvent.EventId }, MainEvent);
        // }
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var @event = await _context.Events
                .Include(e => e.Attendee)
                .Where(e => e.EventId == id)
                .Select(e => new EventDto
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Location = e.Location,
                    Attendees = e.Attendee.Select(a => new AttendeeDto
                    {
                        AttendeeId = a.AttendeeId,
                        Name = a.Name,
                        Email = a.Email
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(EventDto eventDto)
        {
            // Map DTO to Entity
            var @event = new Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                StartDate = eventDto.StartDate,
                EndDate = eventDto.EndDate,
                Location = eventDto.Location,
                Attendee = eventDto.Attendees.Select(a => new Attendee
                {
                    Name = a.Name,
                    Email = a.Email
                }).ToList()
            };

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            // Map Entity to DTO for Response
            var createdEventDto = new EventDto
            {
                EventId = @event.EventId,
                Title = @event.Title,
                Description = @event.Description,
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                Location = @event.Location,
                Attendees = @event.Attendee.Select(a => new AttendeeDto
                {
                    AttendeeId = a.AttendeeId,
                    Name = a.Name,
                    Email = a.Email
                }).ToList()
            };
            _context.ChangeTracker.Entries();

            return CreatedAtAction(nameof(GetEvent), new { id = createdEventDto.EventId }, createdEventDto);
        }




    }
}