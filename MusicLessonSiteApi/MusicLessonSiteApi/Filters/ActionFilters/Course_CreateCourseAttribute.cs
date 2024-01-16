using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicLessonSiteApi.Models;
using MusicLessonSiteApi.Models.Repositories;

namespace MusicLessonSiteApi.Filters.ActionFilters
{
    public class Course_CreateCourseAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!context.ActionArguments.TryGetValue("course", out var actionArgument) || !(actionArgument is Course course))
            {
                context.ModelState.AddModelError("Course", "Course is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingCourse = CourseRepository2.GetCourseByProperties(course.Instrument, course.PlayerLevel);

                if (existingCourse != null)
                {
                    context.ModelState.AddModelError("Course", "Course with the same properties already exists");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
