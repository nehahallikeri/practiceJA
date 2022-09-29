using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainerCalenderApis.Data;

namespace TrainerCalenderApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int userId)
        {
            var list=await _context.Users
                .Where(c=> c.ID == userId)
                .ToListAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return await Get(user.ID);
        }
    }
}
