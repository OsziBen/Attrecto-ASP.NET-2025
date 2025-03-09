using Microsoft.AspNetCore.Mvc;
using CourseController.Data;
using CourseController.Repositories;
using CourseController.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //public static List<User>? Users = new List<User>();
        private IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _repository.UpdateAsync(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }

        // GET api/<UserController>
        [HttpGet("adults")]
        public async Task<ActionResult<IEnumerable<User>>> GetAdultUsersAsync()
        {
            var users = await _repository.GetAllAdultUsersAsync();

            return users.Any() ? Ok(users) : NotFound();
        }
    }
}
