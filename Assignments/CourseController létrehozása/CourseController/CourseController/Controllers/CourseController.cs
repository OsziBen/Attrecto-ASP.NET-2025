using Microsoft.AspNetCore.Mvc;
using CourseController.Data;
using CourseController.Repositories;
using CourseController.Interfaces;
using CourseController.Dtos;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //public static List<Course>? Courses = new List<Course>();
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/<CourseController>
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<FilteredCourseDto>> GetAsync()
        {
            return await _courseService.GetAllAsync();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<FilteredCourseDto>> GetAsync(int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<CourseController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> PostAsync([FromBody] CourseDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _courseService.CreateAsync(data);

                return NoContent();
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }              
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CourseDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseService.UpdateAsync(id, data);

            return course == null ? NotFound() : NoContent();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _courseService.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
