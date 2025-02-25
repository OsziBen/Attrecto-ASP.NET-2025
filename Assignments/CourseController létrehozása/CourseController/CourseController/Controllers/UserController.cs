using Microsoft.AspNetCore.Mvc;
using CourseController.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User>? Users = new List<User>();

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            if (Users is null || !Users.Any())
            {
                return NotFound();
            }

            return Ok(Users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Users.Add(data);

            return NoContent();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            Users.Remove(user);

            return NoContent();
        }
    }
}
