using Microsoft.AspNetCore.Mvc;
using userEventsASP.NET.Models;
using userEventsASP.NET.Interfaces;
using AutoMapper;
using userEventsASP.NET.Pagination;

namespace userEventsASP.NET.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Tuple<List<User>, int>))]
        public IActionResult GetUsers([FromQuery] PaginationParams param)
        {
            Tuple<List<User>, int> users = _mapper.Map<Tuple<List<User>, int>>(_userRepository.GetUsers(param));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(Guid id)
        {
            User user = _mapper.Map<User>(_userRepository.GetUser(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult CreateUser([FromBody] User userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_userRepository.UserExists(userCreate.Email))
            {
                return BadRequest("User with this email exist. Please log in");
            }

            User userMap = _mapper.Map<User>(userCreate);

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully registred");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult UpdateUser(Guid id, [FromBody] User updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedUser.Id)
            {
                return BadRequest(ModelState);
            }

            User userMap = _mapper.Map<User>(updatedUser);

            if (!_userRepository.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Profile successfully updated");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteUser(Guid id)
        {
            User userToDelete = _userRepository.GetUser(id);

            if (!_userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return Ok("Profile successfully deleted");
        }
    }
}
