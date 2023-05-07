using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using userEventsASP.NET.Models;
using userEventsASP.NET.Dto;
using userEventsASP.NET.Interfaces;
using userEventsASP.NET.Pagination;

namespace userEventsASP.NET.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Tuple<List<Event>, int>))]
        public IActionResult GetEvents([FromQuery] PaginationParams param)
        {
            Tuple<List<Event>, int> events = _mapper.Map<Tuple<List<Event>, int>>(_eventRepository.GetEvents(param));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(events);
        }

        [HttpGet("{userId}/userEvents")]
        [ProducesResponseType(200, Type = typeof(Tuple<List<Event>, int>))]
        public IActionResult GetEvents(Guid userId, [FromQuery] PaginationParams param)
        {
            Tuple<List<Event>, int> userEvents = _mapper.Map<Tuple<List<Event>, int>>(_eventRepository.GetEvents(userId, param));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(userEvents);
        }

        [HttpGet("{eventId}/event")]
        [ProducesResponseType(200, Type = typeof(Event))]
        [ProducesResponseType(400)]
        public IActionResult GetEvent(Guid eventId)
        {
            EventDto evnt = _mapper.Map<EventDto>(_eventRepository.GetEvent(eventId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(evnt);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEvent([FromBody] Event eventCreate)
        {
            if (eventCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Event eventMap = _mapper.Map<Event>(eventCreate);

            if (!_eventRepository.CreateEvent(eventMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Event successfully created");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEvent(Guid id, [FromBody] Event updatedEvent)
        {
            if (updatedEvent == null)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedEvent.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Event eventMap = _mapper.Map<Event>(updatedEvent);

            if (!_eventRepository.UpdateEvent(eventMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Event successfully updated");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEvent(Guid id)
        {
            Event eventToDelete = _eventRepository.GetEvent(id);

            if (!_eventRepository.DeleteEvent(eventToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting event");
            }

            return Ok("Event successfully deleted");
        }
    }
}