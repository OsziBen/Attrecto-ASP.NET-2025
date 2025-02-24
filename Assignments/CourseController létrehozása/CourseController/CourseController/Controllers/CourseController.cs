using Microsoft.AspNetCore.Mvc;
using CourseController.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public static List<Course>? Courses = new List<Course>();

        // GET: api/<CourseController>
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            if (Courses is null || !Courses.Any())
            {
                return NotFound();
            }

            return Ok(Courses);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var course = Courses.FirstOrDefault(x => x.Id == id);

            if (course is null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult Post([FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Courses.Add(data);

            return NoContent();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = Courses.FirstOrDefault(x => x.Id == id);

            if (course is null)
            {
                return NotFound();
            }

            course.Name = data.Name;
            course.Description = data.Description;

            return NoContent();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var course = Courses.FirstOrDefault(x => x.Id == id);

            if (course is null)
            {
                return NotFound();
            }

            Courses.Remove(course);

            return NoContent();
        }
    }
}
