using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainerCalenderApis.Data;
using TrainerCalenderApis.Interfaces;

namespace TrainerCalenderApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = _userRepository.GetUsers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(list);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            if (!_userRepository.UserExists(userId))
            {
                return NotFound();
            };
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user =_userRepository.GetUser(userId);
            return Ok(user);
        }
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();
        //    return await Get(user.ID);
        //}
    }
}
