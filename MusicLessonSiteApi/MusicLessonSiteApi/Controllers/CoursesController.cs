using Microsoft.AspNetCore.Mvc;
using MusicLessonSiteApi.Models;
using MusicLessonSiteApi.Models.Repositories;
using MusicLessonSiteApi.Filters.ActionFilters;
using MusicLessonSiteApi.Filters.ExeptionFilters;

namespace MusicLessonSiteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    { 
        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(CourseRepository2.GetCourses());
        }
        [HttpGet("{id}")]
        [Course_ValidateCourseID]
        public IActionResult GetCoursesById(int id)
        {
           return Ok(CourseRepository2.GetCourseById(id));
        }
        [HttpPost]
        [Course_CreateCourse]
        public IActionResult CreateCourse([FromForm] Course course)
        {
            CourseRepository2.AddCourse(course);
            return CreatedAtAction(nameof(GetCoursesById),
                new { id = course.Id }, course);
        }
        [HttpPut("{id}")]
        [Course_CreateCourse]
        [Course_ValidateCourseID]
        [Course_HandleUpdateExeptionAttribute3]
        public IActionResult UpdateCourse(int id, Course course)
        {
            CourseRepository2.UpdateCourse(course);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Course_ValidateCourseID]
        public IActionResult   DeleteCourse(int id)
        {
            var course = CourseRepository2.GetCourseById(id);
            CourseRepository2.DeleteCourse(id);
            return Ok(course);
        }
    }

}
