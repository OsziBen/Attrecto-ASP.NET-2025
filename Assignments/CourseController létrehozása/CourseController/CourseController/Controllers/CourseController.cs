using Microsoft.AspNetCore.Mvc;
using CourseController.Data;
using CourseController.Repositories;
using CourseController.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //public static List<Course>? Courses = new List<Course>();
        private ICourseRepository _repository;

        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IEnumerable<Course>> GetAsync()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _repository.UpdateAsync(id, data);

            return course == null ? NotFound() : NoContent();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
