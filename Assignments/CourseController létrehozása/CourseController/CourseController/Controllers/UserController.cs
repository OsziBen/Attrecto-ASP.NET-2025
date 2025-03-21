using Microsoft.AspNetCore.Mvc;
using CourseController.Data;
using CourseController.Repositories;
using CourseController.Interfaces;
using CourseController.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //public static List<User>? Users = new List<User>();
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            return await _userService.GetAllAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return user == null ? NotFound() : user;
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = await _userService.GetByIdAsync(int.Parse(userId));

            return user == null ? NotFound() : user;
        }

        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> PostAsync([FromBody] UserDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try{
                await _userService.CreateAsync(data);

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> PutAsync(int id, [FromBody] UserDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.UpdateAsync(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }

        // GET api/<UserController>
        [HttpGet("adults")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAdultUsersAsync()
        {
            var users = await _userService.GetAllAdultUsersAsync();

            return users.Any() ? Ok(users) : NotFound();
        }
    }
}
