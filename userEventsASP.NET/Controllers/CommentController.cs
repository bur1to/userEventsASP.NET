using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using userEventsAndBlogs.Models;
using userEventsAndBlogs.Dto;
using userEventsAndBlogs.Interfaces;

namespace userEventsAndBlogs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentController(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        [HttpGet("{blogId}")]
        [ProducesResponseType(200, Type = typeof(List<Comment>))]
        public IActionResult GetComments(Guid blogId)
        {
            var comments = _mapper.Map<List<Comment>>(_commentRepository.GetComments(blogId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(comments);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult CreateComment([FromBody] Comment commentCreate)
        {
            if (commentCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentMap = _mapper.Map<Comment>(commentCreate);

            if (!_commentRepository.CreateComment(commentMap))
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
        public IActionResult UpdateBlog(Guid id, [FromBody] Comment updatedComment)
        {
            if (updatedComment == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentMap = _mapper.Map<Comment>(updatedComment);

            if (!_commentRepository.UpdateComment(commentMap))
            {
                ModelState.AddModelError("", "Something went wrongwhile updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Comment successfully updated");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBlog(Guid id)
        {
            var commentToDelete = _commentRepository.GetComment(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_commentRepository.DeleteComment(commentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return Ok("Comment successfully deleted");
        }
    }
}
