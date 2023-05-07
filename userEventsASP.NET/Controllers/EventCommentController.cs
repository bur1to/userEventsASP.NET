using AutoMapper;
using userEventsASP.NET.Models;
using userEventsASP.NET.Interfaces;
using userEventsASP.NET.Dto;
using Microsoft.AspNetCore.Mvc;

namespace userEventsASP.NET.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventCommentController : Controller
    {
        private readonly ICommentEventRepository _commentEventRepository;
        private readonly IMapper _mapper;
        public EventCommentController(ICommentEventRepository commentEventRepository, IMapper mapper)
        {
            _commentEventRepository = commentEventRepository;
            _mapper = mapper;
        }

        [HttpGet("{eventId}")]
        [ProducesResponseType(200, Type = typeof(List<EventComment>))]
        public IActionResult GetComments(Guid eventId)
        {
            List<EventComment> comments = _mapper.Map<List<EventComment>>(_commentEventRepository.GetComments(eventId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(comments);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult CreateComment([FromBody] EventComment commentCreated)
        {
            if (commentCreated == null)
            {
                return BadRequest(ModelState);
            }

            EventComment commentMap = _mapper.Map<EventComment>(commentCreated);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_commentEventRepository.CreateComment(commentMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Comment successfully created");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateComment(Guid id, [FromBody] EventComment updatedComment)
        {
            if (updatedComment == null)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedComment.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EventComment commentToUpdate = _mapper.Map<EventComment>(updatedComment);

            if (!_commentEventRepository.UpdateComment(commentToUpdate))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Comment successfully updated");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DeleteComment(Guid id)
        {
            EventComment commentToDelete = _commentEventRepository.GetComment(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_commentEventRepository.DeleteComment(commentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return Ok("Comment successfully deleted");
        }
    }
}
