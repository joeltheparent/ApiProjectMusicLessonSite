using MusicLessonSiteApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace MusicLessonSiteApi.Filters.ExeptionFilters
{
    public class Class_HandleUpdateExeptionAttribute3 : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strCourseId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strCourseId, out int courseId))
            {
                if (!CourseRepository2.CourseExists(courseId))
                {
                    context.ModelState.AddModelError("courseId", "Course does not exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }

        }
    }

}