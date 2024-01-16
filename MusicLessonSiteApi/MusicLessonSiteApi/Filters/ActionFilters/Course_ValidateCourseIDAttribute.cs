using MusicLessonSiteApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace MusicLessonSiteApi.Filters.ActionFilters
{
    public class Course_ValidateCourseIDAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var courseId = context.ActionArguments["Id"] as int?;
            if (courseId.HasValue)
            {


                if (courseId.Value <= 0)
                {
                    context.ModelState.AddModelError("courseId", "courseId is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!CourseRepository2.CourseExists(courseId.Value))
                {
                    context.ModelState.AddModelError("courseId", "CourseId does not exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    { Status = StatusCodes.Status404NotFound };
               
                    context.Result = new NotFoundObjectResult(context.ModelState);
                }
            }
        }
    }
}
