using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using userEventsAndBlogs.Models;
using userEventsAndBlogs.Dto;
using userEventsAndBlogs.Interfaces;
using userEventsAndBlogs.Pagination;

namespace userEventsAndBlogs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogController(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Tuple<List<Blog>, int>))]
        public IActionResult GetBlogs([FromQuery] PaginationParams param)
        {
            var blogs = _mapper.Map<Tuple<List<Blog>, int>>(_blogRepository.GetBlogs(param));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(blogs);
        }

        [HttpGet("{userId}/userBlogs")]
        [ProducesResponseType(200, Type = typeof(Tuple<List<Blog>, int>))]
        public IActionResult GetBlogs(Guid userId, [FromQuery] PaginationParams param)
        {
            var userBlogs = _mapper.Map<Tuple<List<Blog>, int>>(_blogRepository.GetBlogs(userId, param));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(userBlogs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Blog))]
        public IActionResult GetBlog(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = _mapper.Map<BlogDto>(_blogRepository.GetBlog(id));

            return Ok(blog);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult CreateBlog([FromBody] Blog blogCreate)
        {
            if (blogCreate == null)
            {
                return BadRequest(ModelState);
            
            }

            blogCreate.PostDate = DateTime.Now;

            var blogMap = _mapper.Map<Blog>(blogCreate);

            if (!_blogRepository.CreateBlog(blogMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Blog successfully posted");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBlog(Guid id, [FromBody] Blog updatedBlog)
        {
            if (updatedBlog == null)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedBlog.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogMap = _mapper.Map<Blog>(updatedBlog);

            if (!_blogRepository.UpdateBlog(blogMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Blog successfully updated");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBlog(Guid id)
        {
            var blogToDelete = _blogRepository.GetBlog(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_blogRepository.DeleteBlog(blogToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return Ok("Blog successfully deleted");
        }
    }
}
